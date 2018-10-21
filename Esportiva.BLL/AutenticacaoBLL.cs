using Esportiva.BLL.Interfaces;
using Esportiva.DAL.Interfaces;
using Esportiva.MOD;
using System.Threading.Tasks;

namespace Esportiva.BLL
{
    public class AutenticacaoBLL : IAutenticacaoBLL
    {
        private IAutenticacaoDAL _autenticacaoDAL;
        public AutenticacaoBLL(IAutenticacaoDAL autenticacao)
        {
            _autenticacaoDAL = autenticacao;
        }

        public async Task CadastrarUsuario(LoginMOD login)
        {
            await _autenticacaoDAL.CadastrarUsuario(login);
        }

        public async Task<LoginMOD> RetornarUsuario(string usuario)
        {
            return await _autenticacaoDAL.RetornarUsuario(usuario);
        }

        public async Task<bool> ValidaExclusaoPartida(int codigoPartida, string user)
        {
            var codigoUsuario = (await RetornarUsuario(user))?.Id;
            if (codigoUsuario.HasValue)
                return await _autenticacaoDAL.ValidaExclusaoPartida(codigoUsuario, codigoPartida);
            return false;
        }

        public async Task<bool> ValidaUsuario(LoginMOD usuario)
        {
            return await _autenticacaoDAL.ValidaUsuario(usuario);
        }
    }
}
