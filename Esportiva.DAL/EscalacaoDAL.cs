using Dapper;
using Esportiva.DAL.Interfaces;
using Esportiva.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esportiva.DAL
{
    public class EscalacaoDAL : IEscalacaoDAL
    {
        public async Task<bool> CadastrarJogador(JogadorMOD jogadorMOD)
        {
            using (var connection = await ConnectionFactory.RetornarConexaoAsync())
            {
                #region QUERY
                const string query = @"
                                INSERT INTO 
                                    Jogadores 
                                VALUES 
                                    (@Nome, @Sobrenome, @Posicao, @DataNascimento, @CodigoTime, @NumeroCamisa, @Apelido, @Altura)";
                #endregion
                return await connection.ExecuteAsync(query, jogadorMOD) > 0;
            }
        }

        public async Task<bool> EditarJogador(JogadorMOD jogadorMOD, string usuario)
        {
            using (var connection = await ConnectionFactory.RetornarConexaoAsync())
            {
                #region "QUERY"
                const string query = @"
                                UPDATE 
                                    Jogadores 
                                SET 
                                    Nome = @Nome, Sobrenome = @Sobrenome, 
                                    DataNascimento = @DataNascimento, NumeroCamisa = @NumeroCamisa, Aplido = @Apelido, Altura = @Altura
                                WHERE
                                    Id = @Id";
                #endregion
                // trocar pra dar inner join em usuario e so alterar where usuario = usuario
                return await connection.ExecuteAsync(query, jogadorMOD) > 0;
            }
        }

        public async Task<int> RetornarCodigoTime(string usuario)
        {
            using (var connection = await ConnectionFactory.RetornarConexaoAsync())
            {
                #region "QUERY"
                const string query = @"
                                SELECT 
	                                Times.Id 
                                FROM 
	                                Times 
                                INNER JOIN Usuarios ON Times.Usuario_id = Usuarios.Id
                                WHERE 
                                    Usuarios.Usuario = @usuario";
                #endregion

                return await connection.QueryFirstOrDefaultAsync<int>(query, new { usuario });
            }
        }

        public async Task<List<JogadorMOD>> RetornarJogadores(int codigoTime, int codigoUsuario)
        {
            using (var connection = await ConnectionFactory.RetornarConexaoAsync())
            {
                #region QUERY
                const string query = @"
                                SELECT
	                                * 
                                FROM
	                                Jogadores
                                INNER JOIN Times ON Jogadores.Time_Id = Times.Id
                                WHERE 
                                    Jogadores.Time_id = @codigoTime AND Times.Usuario_id = @codigoUsuario";
                #endregion

                return await connection.QueryAsync<JogadorMOD>(query, new { codigoUsuario, codigoTime }) as List<JogadorMOD>;
            }
        }
    }
}
