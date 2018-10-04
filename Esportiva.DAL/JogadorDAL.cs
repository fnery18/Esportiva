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
    public class JogadorDAL : IJogadorDAL
    {
        private IJogadorDAL _jogadorDAL;
        public JogadorDAL(IJogadorDAL jogador)
        {
            _jogadorDAL = jogador;
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
                                INNER JOIN Times on Times.Id = Jogadores.Time_Id
                                WHERE 
	                                Times.Usuario_id = @codigoUsuario";
                #endregion

                return await connection.QueryAsync<JogadorMOD>(query, new { codigoTime, codigoUsuario }) as List<JogadorMOD>;
            }
        }
    }
}
