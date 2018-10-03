using Esportiva.MOD;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Esportiva.BLL.Interfaces
{
    public interface ITimeBLL
    {
        Task<List<TimeMOD>> RetornarTimes(LoginMOD usuario);
        Task<bool> CadastrarTime(TimeMOD timeMOD, string usuario);
        Task<bool> ExcluirTime(int codigoTime, string usuario);
        Task<TimeMOD> RetornarTime(int codigoTime, string usuario);
        Task<bool> RetornarTimeExiste(string nome);
        Task AlterarTime(TimeMOD novoTime, string nome, string usuario);
    }
}
