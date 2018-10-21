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

        public async Task<bool> CadastrarTime(TimeMOD time, string usuario, bool adversario)
        {
            //codigo usuario = 1 signifca adversario
            if (adversario)
            {
                await _administrativoDAL.CadastrarTime(time, codigoUsuario: 1);
                return true;
            }

            var codigoUsuario = (await _autenticacaoBLL.RetornarUsuario(usuario))?.Id;
            var quantidadeTime = await _administrativoDAL.RetornarTimes(codigoUsuario ?? 1);

            if (quantidadeTime != null)
            {
                if (quantidadeTime.Count < quantidadeTimesPermitido)
                {
                    await _administrativoDAL.CadastrarTime(time, codigoUsuario ?? 1);
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

        public async Task<bool> ExcluirTime(int codigoTime, string usuario, bool adversario)
        {
            var codigoUsuario = adversario ? 1 : (await _autenticacaoBLL.RetornarUsuario(usuario))?.Id;
            return await _administrativoDAL.ExcluirTime(codigoTime, codigoUsuario ?? 1);
        }

        public async Task<TimeMOD> RetornarTime(int codigoTime, string usuario)
        {
            var codigoUsuario = (await _autenticacaoBLL.RetornarUsuario(usuario))?.Id;
            var retorno = await _administrativoDAL.RetornarTime(codigoTime, codigoUsuario ?? 1);

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
            await _administrativoDAL.AlterarTime(novoTime, nomeTime, codigoUsuario ?? 1);
        }
        #endregion


        public async Task<List<AcontecimentosMOD>> RetornarAcontecimentos(int codigoTime, string user)
        {
            return await _administrativoDAL.RetornarAcontecimentos(codigoTime, user);
        }

        public async Task<List<PartidasMOD>> RetornarPartidas(int codigoTime, string user)
        {
            return await _administrativoDAL.RetornarPartidas(codigoTime, user);
        }

        public async Task<bool> ExcluirPartida(int codigoPartida, string user)
        {

            var podeExcluir = await _autenticacaoBLL.ValidaExclusaoPartida(codigoPartida, user);
            if (podeExcluir)
                return await _administrativoDAL.ExcluirPartida(codigoPartida);
            return false;
        }

        public async Task<bool> CadastrarPartida(PartidasMOD partida)
        {

            return await _administrativoDAL.CadastrarPartida(partida);
        }

        public async Task<List<TimeMOD>> RetornarTimesAdversarios(LoginMOD usuario, int codigoTime)
        {
            if (usuario != null && codigoTime > 0)
                return await _administrativoDAL.RetornarTimesAdversarios(usuario.Id, codigoTime);
            return new List<TimeMOD>();
        }

        public async Task<List<JogadorMOD>> RetornarJogadores(LoginMOD usuario, int codigoTime)
        {
            if (usuario != null)
                return await _administrativoDAL.RetornarJogadores(usuario.Id, codigoTime);

            return new List<JogadorMOD>();
        }

        public async Task<List<TipoAcontecimentoMOD>> RetornarTipoAcontecimento()
        {
            return await _administrativoDAL.RetornarTipoAcontecimento();
        }

        public async Task<bool> CadastrarAcontecimento(AcontecimentosMOD acontecimento, string user)
        {
            var usuario = await _autenticacaoBLL.RetornarUsuario(user);


            if (usuario != null)
            {
                var autorizado = await _autenticacaoBLL.ValidaDonoTime(usuario.Id, acontecimento.Time_Id);
                if (autorizado)
                {
                    await _administrativoDAL.CadastrarAcontecimento(acontecimento);
                    return true;
                }
            }

            return false;
        }
    }
}
