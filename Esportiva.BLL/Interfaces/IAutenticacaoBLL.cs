using Esportiva.MOD;
using System.Threading.Tasks;

namespace Esportiva.BLL.Interfaces
{
    public interface IAutenticacaoBLL
    {
        Task<bool> ValidaUsuario(LoginMOD usuario);
        Task CadastrarUsuario(LoginMOD loginMOD);
        Task<LoginMOD> RetornarUsuario(string usuario);
    }
}
