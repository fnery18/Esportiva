using Dapper;
using Esportiva.DAL.Interfaces;
using Esportiva.MOD;
using System.Threading.Tasks;

namespace Esportiva.DAL
{
    public class AutenticacaoDAL : IAutenticacaoDAL
    {
        public async Task CadastrarUsuario(LoginMOD login)
        {
            using (var connection = await ConnectionFactory.RetornarConexaoAsync())
            {
                #region QUERY

                const string query = @"
                                INSERT INTO 
                                    Usuarios 
                                VALUES 
                                    (@Usuario, @Senha)";
                #endregion

                await connection.ExecuteAsync(query, login);
            }
        }

        public async Task<LoginMOD> RetornarUsuario(string usuario)
        {
            using (var connection = await ConnectionFactory.RetornarConexaoAsync())
            {
                #region QUERY
                const string query = @"
                                SELECT 
                                    * 
                                FROM 
                                    Usuarios 
                                WHERE 
                                    Usuario = @usuario";
                #endregion

                return await connection.QueryFirstOrDefaultAsync<LoginMOD>(query, new { usuario });
            }
        }

        public async Task<bool> ValidaUsuario(LoginMOD usuario)
        {
            using (var connection = await ConnectionFactory.RetornarConexaoAsync())
            {
                #region QUERY
                const string query = @"
                                SELECT 
                                    * 
                                FROM 
                                    Usuarios 
                                WHERE 
                                    Usuario = @Usuario AND Senha = @Senha";
                #endregion

                return await connection.QueryFirstOrDefaultAsync<LoginMOD>(query, usuario) != null;
            }
        }
    }
}
