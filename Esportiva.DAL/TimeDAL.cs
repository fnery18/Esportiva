using Dapper;
using Esportiva.DAL.Interfaces;
using Esportiva.MOD;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Esportiva.DAL
{
    public class TimeDAL : ITimeDAL
    {
        public async Task AlterarTime(TimeMOD novoTime, string nomeTime, int codigoUsuario)
        {
            using (var connection = await ConnectionFactory.RetornarConexaoAsync())
            {
                #region QUERY
                const string query = @"
                                UPDATE 
                                    Times 
                                SET 
                                    Nome = @Nome, Sigla = @Sigla, Cor1 = @Cor1, 
                                    Cor2 = @Cor2, Cor3 = @Cor3, Nacionalidade = @Nacionalidade, 
                                    DataFundacao = @DataFundacao
                                WHERE
                                    Usuario_id = @codigoUsuario AND Nome = @nomeTime";
                #endregion

                await connection.ExecuteAsync(query, new
                {
                    novoTime.Nome,
                    novoTime.Sigla,
                    novoTime.Cor1,
                    novoTime.Cor2,
                    novoTime.Cor3,
                    novoTime.Nacionalidade,
                    novoTime.DataFundacao,
                    codigoUsuario,
                    nomeTime
                });

            }
        }

        public async Task CadastrarTime(TimeMOD time, int codigoUsuario)
        {
            using (var connection = await ConnectionFactory.RetornarConexaoAsync())
            {
                #region QUERY
                const string query = @"
                                INSERT INTO 
                                    Times 
                                VALUES 
                                    (@Nome, @Cor1, @Cor2, @Cor3, @Sigla, @Nacionalidade, @DataFundacao, @codigoUsuario)";
                #endregion

                await connection.ExecuteAsync(query,
                    new
                    {
                        time.Nome,
                        time.Sigla,
                        time.Cor1,
                        time.Cor2,
                        time.Cor3,
                        time.Nacionalidade,
                        DataFundacao = time.DataFundacao,
                        codigoUsuario
                    });
            }
        }

        public async Task<bool> ExcluirTime(int codigoTime, int codigoUsuario)
        {
            using (var connection = await ConnectionFactory.RetornarConexaoAsync())
            {
                #region QUERY
                const string query = @"
                            DELETE FROM 
                                Times 
                            WHERE 
                                Id = @codigoTime AND Usuario_id = @codigoUsuario";
                #endregion

                return await connection.ExecuteAsync(query, new { codigoTime, codigoUsuario }) > 0;
            }
        }

        public async Task<TimeMOD> RetornarTime(string nome)
        {
            using (var connection = await ConnectionFactory.RetornarConexaoAsync())
            {
                #region QUERY
                const string query = @"
                                SELECT 
                                    * 
                                FROM 
                                    Times 
                                WHERE Nome = @nome";
                #endregion

                return await connection.QueryFirstOrDefaultAsync<TimeMOD>(query, new { nome });

            }
        }

        public async Task<TimeMOD> RetornarTime(int codigoTime, int codigoUsuario)
        {
            using (var connection = await ConnectionFactory.RetornarConexaoAsync())
            {
                #region QUERY
                const string query = @"
                                SELECT 
                                    * 
                                FROM 
                                    Times 
                                WHERE 
                                    Id = @codigoTime AND Usuario_id = @codigoUsuario";
                #endregion

                return await connection.QueryFirstOrDefaultAsync<TimeMOD>(query, new { codigoTime, codigoUsuario });
            }
        }

        public async Task<List<TimeMOD>> RetornarTimes(int id)
        {
            using (var connection = await ConnectionFactory.RetornarConexaoAsync())
            {
                #region QUERY
                const string query = @"
                                SELECT 
                                    * 
                                FROM 
                                    Times 
                                WHERE 
                                    Usuario_id = @id";
                #endregion

                return await connection.QueryAsync<TimeMOD>(query, new { id }) as List<TimeMOD>;
            }
        }
    }
}
