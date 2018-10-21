using Dapper;
using Esportiva.DAL.Interfaces;
using Esportiva.MOD;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Esportiva.DAL
{
    public class AdministrativoDAL : IAdministrativoDAL
    {

        #region TIME
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

        #endregion

        public async Task<List<AcontecimentosMOD>> RetornarAcontecimentos(int codigoTime, string user)
        {
            using (var connection = await ConnectionFactory.RetornarConexaoAsync())
            {
                #region query
                const string query = @"
                                SELECT 
	                                Acontecimentos.Id as IdAcontecimento, 
	                                Jogadores.Id as IdJogadores, Jogadores.Nome, Jogadores.Sobrenome, Jogadores.Posicao, Jogadores.DataNascimento, Times.Nome as Time, Jogadores.NumeroCamisa, Jogadores.Apelido, Jogadores.Altura,
	                                Partidas.Id as IdPartidas, Partidas.NomePartida, Partidas.DataPartida, Partidas.Time1_Id, Times.Nome, Partidas.Time2_Id, Adversario.Nome, Partidas.LocalCompeticao, Partidas.Competicao,
	                                Times.Id as IdTimes, Times.Nome,Times.Sigla, Times.Cor1, Times.Cor2, Times.Cor3, Times.Nacionalidade, Times.DataFundacao,
	                                TipoAcontecimento.Id as IdTipoAcontecimento, TipoAcontecimento.Nome, TipoAcontecimento.Icone
                                FROM 
	                                Acontecimentos	
                                INNER JOIN Times ON Acontecimentos.Time_Id = Times.Id
                                INNER JOIN Usuarios ON Times.Usuario_id = Usuarios.Id
                                INNER JOIN Jogadores ON Acontecimentos.Jogador_Id = Jogadores.Id
                                INNER JOIN TipoAcontecimento ON Acontecimentos.TipoAcontecimento_Id = Acontecimentos.TipoAcontecimento_Id
                                INNER JOIN Partidas ON Acontecimentos.Partida_Id = Partidas.Id
                                INNER JOIN Times as Adversario ON Partidas.Time2_Id = Times.Id

                                WHERE 
	                                Usuarios.Usuario = @user AND Times.Id = @codigoTime";
                #endregion

                var acontecimentos = await connection.QueryAsync<AcontecimentosMOD, JogadorMOD, PartidasMOD, TimeMOD, TipoAcontecimentoMOD, AcontecimentosMOD>(query,
                    (acontecimento, jogador, partida, time, tipoacontecimento) =>
                    {
                        acontecimento.Jogador = jogador;
                        acontecimento.Partida = partida;
                        acontecimento.Time = time;
                        acontecimento.TipoAcontecimento = tipoacontecimento;
                        return acontecimento;
                    }, new
                    {
                        user,
                        codigoTime
                    }, splitOn: "IdJogadores, IdPartidas, IdTimes, IdTipoAcontecimento") as List<AcontecimentosMOD>;

                return acontecimentos;
            }
        }

        public async Task<List<PartidasMOD>> RetornarPartidas(int codigoTime, string user)
        {
            using (var connection = await ConnectionFactory.RetornarConexaoAsync())
            {
                #region query
                const string query = @"
                                SELECT
	                                Partidas.Id, Partidas.NomePartida, Partidas.DataPartida, Partidas.LocalCompeticao,
	                                Time1_Id as IdTime1, Times.Nome, Times.Sigla, Times.Usuario_id, Times.Nacionalidade, Times.DataFundacao, Times.Cor1, Times.Cor2, Times.Cor3,
	                                Time2_Id as IdTime2, TimeAdversario.Nome, TimeAdversario.Sigla, TimeAdversario.Usuario_id, TimeAdversario.Nacionalidade, TimeAdversario.DataFundacao, TimeAdversario.Cor1, TimeAdversario.Cor2, TimeAdversario.Cor3
                                FROM 
	                                Partidas
                                INNER JOIN Times ON Partidas.Time1_Id = Times.Id
                                INNER JOIN Times as TimeAdversario ON Partidas.Time2_Id = TimeAdversario.Id
								INNER JOIN Usuarios ON Times.Usuario_id = Usuarios.Id
                                WHERE
                                    Times.Id = @codigoTime AND Usuarios.Usuario = @user";
                #endregion

                var partidas = await connection.QueryAsync<PartidasMOD, TimeMOD, TimeMOD, PartidasMOD>(query,
                    (partida, time, timeadversario) =>
                    {
                        partida.Time1 = time;
                        partida.Time2 = timeadversario;
                        return partida;
                    }, new
                    {
                        user,
                        codigoTime
                    }, splitOn: "IdTime1, IdTime2") as List<PartidasMOD>;

                return partidas;
            }
        }

        public async Task<bool> ExcluirPartida(int codigoPartida)
        {
            using (var connection = await ConnectionFactory.RetornarConexaoAsync())
            {
                #region query
                const string query = @"
                                DELETE FROM 
                                    Partidas
                                WHERE 
                                    Id = @codigoPartida";
                #endregion

                return await connection.ExecuteAsync(query, new { codigoPartida }) > 0;
            }
        }

        public async Task<List<TimeMOD>> RetornarTimesAdversarios(int codigoUsuario, int codigoTime)
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
	                                Usuario_id != @codigoUsuario OR Id != @codigoTime";
                #endregion

                return await connection.QueryAsync<TimeMOD>(query, new { codigoUsuario, codigoTime }) as List<TimeMOD>;
            }


        }

        public async Task<bool> CadastrarPartida(PartidasMOD partida)
        {
            using (var connection = await ConnectionFactory.RetornarConexaoAsync())
            {
                #region query
                const string query = @"
                    INSERT INTO
	                    Partidas
                    VALUES
	                    (@NomePartida, @DataPartida, @IdTime1, @IdTime2, @LocalCompeticao, @Competicao)";
                #endregion

                return await connection.ExecuteAsync(query, partida) > 0;
            }


        }
    }
}
