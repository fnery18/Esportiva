using Esportiva.MOD;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Esportiva.BLL.Interfaces
{
    public interface IAdministrativoBLL
    {
        Task<List<TimeMOD>> RetornarTimes(LoginMOD usuario);
        Task<bool> CadastrarTime(TimeMOD timeMOD, string usuario, bool adversario);
        Task<bool> ExcluirTime(int codigoTime, string usuario, bool adversario);
        Task<TimeMOD> RetornarTime(int codigoTime, string usuario);
        Task<bool> RetornarTimeExiste(string nome);
        Task AlterarTime(TimeMOD novoTime, string nome, string usuario);
        Task<List<AcontecimentosMOD>> RetornarAcontecimentos(int codigoTime, string user);
        Task<List<PartidasMOD>> RetornarPartidas(int codigoTime, string user);
        Task<bool> ExcluirPartida(int codigoPartida, string user);
        Task<bool> CadastrarPartida(PartidasMOD partida);
        Task<List<TimeMOD>> RetornarTimesAdversarios(LoginMOD usuario, int codigoTime);
    }
}
