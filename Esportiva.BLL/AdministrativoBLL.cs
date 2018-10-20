using Esportiva.BLL.Interfaces;
using Esportiva.DAL.Interfaces;
using Esportiva.MOD;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace Esportiva.BLL
{

    public class Administrativo : IAdministrativoBLL
    {
        private IAdministrativoDAL _administrativoDAL;
        private int quantidadeTimesPermitido = int.Parse(ConfigurationManager.AppSettings["quantidadeTimeLimite"]);
        private IAutenticacaoBLL _autenticacaoBLL;
        public Administrativo(IAdministrativoDAL administrativoDAL, IAutenticacaoBLL autenticacaoBLL)
        {
            _administrativoDAL = administrativoDAL;
            _autenticacaoBLL = autenticacaoBLL;
        }

        #region TIME

        public async Task<bool> CadastrarTime(TimeMOD time, string usuario)
        {
            var codigoUsuario = (await _autenticacaoBLL.RetornarUsuario(usuario))?.Id;

            var quantidadeTime = await _administrativoDAL.RetornarTimes(codigoUsuario ?? 0);

            if (quantidadeTime != null)
            {
                if (quantidadeTime.Count < quantidadeTimesPermitido)
                {
                    await _administrativoDAL.CadastrarTime(time, codigoUsuario ?? 0);
                    return true;
                }
            }
            return false;
        }

        public async Task<List<TimeMOD>> RetornarTimes(LoginMOD usuario)
        {
            if (usuario != null)
            {
                var times = await _administrativoDAL.RetornarTimes(usuario.Id);

                if (times != null)
                    return times;
            }
            return new List<TimeMOD>();


        }

        public async Task<bool> ExcluirTime(int codigoTime, string usuario)
        {
            var codigoUsuario = (await _autenticacaoBLL.RetornarUsuario(usuario))?.Id;
            return await _administrativoDAL.ExcluirTime(codigoTime, codigoUsuario ?? 0);
        }

        public async Task<TimeMOD> RetornarTime(int codigoTime, string usuario)
        {
            var codigoUsuario = (await _autenticacaoBLL.RetornarUsuario(usuario))?.Id;
            var retorno = await _administrativoDAL.RetornarTime(codigoTime, codigoUsuario ?? 0);

            var time = new TimeMOD();

            if (retorno != null)
                time = retorno;

            return time;
        }

        public async Task<bool> RetornarTimeExiste(string nome)
        {
            return await _administrativoDAL.RetornarTime(nome) != null;
        }

        public async Task AlterarTime(TimeMOD novoTime, string nomeTime, string usuario)
        {
            var codigoUsuario = (await _autenticacaoBLL.RetornarUsuario(usuario))?.Id;
            await _administrativoDAL.AlterarTime(novoTime, nomeTime, codigoUsuario ?? 0);
        }
        #endregion


        public async Task<List<AcontecimentosMOD>> RetornarAcontecimentos(int codigoTime, string user)
        {
            return await _administrativoDAL.RetornarAcontecimentos(codigoTime, user);
        }
    }
}
