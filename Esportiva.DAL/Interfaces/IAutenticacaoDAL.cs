using System.Threading.Tasks;
using Esportiva.MOD;

namespace Esportiva.DAL.Interfaces
{
    public interface IAutenticacaoDAL
    {
        Task<bool> ValidaUsuario(LoginMOD usuario);
        Task CadastrarUsuario(LoginMOD login);
        Task<LoginMOD> RetornarUsuario(string usuario);
        Task<bool> ValidaExclusaoPartida(int? codigoUsuario, int codigoPartida);
    }
}
