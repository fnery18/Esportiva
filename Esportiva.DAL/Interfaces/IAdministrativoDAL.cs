using Esportiva.MOD;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Esportiva.DAL.Interfaces
{
    public interface IAdministrativoDAL
    {
        Task<List<TimeMOD>> RetornarTimes(int id);
        Task CadastrarTime(TimeMOD time, int codigoUsuario);
        Task<bool> ExcluirTime(int codigoTime, int codigoUsuario);
        Task<TimeMOD> RetornarTime(int codigoTime, int codigoUsuario);
        Task<TimeMOD> RetornarTime(string nome);
        Task AlterarTime(TimeMOD novoTime, string nomeTime, int codigoUsuario);
        Task<List<AcontecimentosMOD>> RetornarAcontecimentos(int codigoTime, string user);
        Task<List<PartidasMOD>> RetornarPartidas(int codigoTime, string user);
        Task<bool> ExcluirPartida(int codigoPartida);
        Task<List<TimeMOD>> RetornarTimesAdversarios(int id, int codigoTime);
        Task<bool> CadastrarPartida(PartidasMOD partida);
        Task<List<JogadorMOD>> RetornarJogadores(int id, int codigoTime);
        Task<List<TipoAcontecimentoMOD>> RetornarTipoAcontecimento();
        Task CadastrarAcontecimento(AcontecimentosMOD acontecimento);
    }
}
