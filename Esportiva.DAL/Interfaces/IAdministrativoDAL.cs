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
    }
}
