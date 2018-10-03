using Esportiva.BLL.Interfaces;
using Esportiva.DAL.Interfaces;
using Esportiva.MOD;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Esportiva.BLL
{

    public class TimeBLL : ITimeBLL
    {
        private ITimeDAL _timeDAL;
        private const int quantidadeTimesPermitido = 1;
        private IAutenticacaoBLL _autenticacaoBLL;
        public TimeBLL(ITimeDAL timeDAL, IAutenticacaoBLL autenticacaoBLL)
        {
            _timeDAL = timeDAL;
            _autenticacaoBLL = autenticacaoBLL;
        }

        public async Task<bool> CadastrarTime(TimeMOD time, string usuario)
        {
            var codigoUsuario = (await _autenticacaoBLL.RetornarUsuario(usuario))?.Id;

            var quantidadeTime = await _timeDAL.RetornarTimes(codigoUsuario ?? 0);

            if (quantidadeTime != null)
            {
                if (quantidadeTime.Count < quantidadeTimesPermitido)
                {
                    await _timeDAL.CadastrarTime(time, codigoUsuario ?? 0);
                    return true;
                }
            }
            return false;
        }

        public async Task<List<TimeMOD>> RetornarTimes(LoginMOD usuario)
        {
            if (usuario != null)
            {
                var times = await _timeDAL.RetornarTimes(usuario.Id);

                if (times != null)
                    return times;
            }
            return new List<TimeMOD>();


        }

        public async Task<bool> ExcluirTime(int codigoTime, string usuario)
        {
            var codigoUsuario = (await _autenticacaoBLL.RetornarUsuario(usuario))?.Id;
            return await _timeDAL.ExcluirTime(codigoTime, codigoUsuario ?? 0);
        }

        public async Task<TimeMOD> RetornarTime(int codigoTime, string usuario)
        {
            var codigoUsuario = (await _autenticacaoBLL.RetornarUsuario(usuario))?.Id;
            var retorno = await _timeDAL.RetornarTime(codigoTime, codigoUsuario ?? 0);

            var time = new TimeMOD();

            if (retorno != null)
                time = retorno;

            return time;
        }

        public async Task<bool> RetornarTimeExiste(string nome)
        {
            return await _timeDAL.RetornarTime(nome) != null;
        }

        public async Task AlterarTime(TimeMOD novoTime, string nomeTime, string usuario)
        {
            var codigoUsuario = (await _autenticacaoBLL.RetornarUsuario(usuario))?.Id;
            await _timeDAL.AlterarTime(novoTime, nomeTime, codigoUsuario ?? 0);
        }
    }
}
