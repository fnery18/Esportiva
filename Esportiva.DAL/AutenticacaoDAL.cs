﻿using Dapper;
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

        public async Task<bool> ValidaDonoTime(int codigoUsuario, int time_Id)
        {
            using (var connection = await ConnectionFactory.RetornarConexaoAsync())
            {
                #region query
                const string query = @"
                                SELECT 
                                    * 
                                FROM 
                                    Times 
                                WHERE 
                                    Id = @time_Id AND Usuario_Id = @codigoUsuario";
                #endregion

                return await connection.QueryFirstOrDefaultAsync<TimeMOD>(query, new { codigoUsuario, time_Id }) != null;
            }
        }

        public async Task<bool> ValidaExclusaoPartida(int? codigoUsuario, int codigoPartida)
        {
            using (var connection = await ConnectionFactory.RetornarConexaoAsync())
            {
                #region query
                const string query = @"
                                SELECT
	                                *
                                FROM
	                                Partidas
                                INNER JOIN Times ON Times.Id = Partidas.Time1_Id
                                INNER JOIN Usuarios ON Times.Usuario_id = Usuarios.Id
                                WHERE 
                                    Partidas.Id = @codigoPartida AND Usuarios.Id = @codigoUsuario";
                #endregion

                return await connection.QueryFirstOrDefaultAsync<PartidasMOD>(query, new { codigoPartida, codigoUsuario }) != null;
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
