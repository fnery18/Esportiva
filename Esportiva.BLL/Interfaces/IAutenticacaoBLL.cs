using Esportiva.MOD;
using System.Threading.Tasks;

namespace Esportiva.BLL.Interfaces
{
    public interface IAutenticacaoBLL
    {
        Task<bool> ValidaUsuario(LoginMOD usuario);
        Task CadastrarUsuario(LoginMOD loginMOD);
        Task<LoginMOD> RetornarUsuario(string usuario);
        Task<bool> ValidaExclusaoPartida(int codigoPartida, string user);
        Task<bool> ValidaDonoTime(int codigoUsuario, int time_Id);
    }
}
