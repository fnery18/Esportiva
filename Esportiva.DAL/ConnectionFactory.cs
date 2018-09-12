using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Esportiva.DAL
{
    public class ConnectionFactory
    {
        public static async Task<DbConnection> RetornarConexaoAsync()
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["esportiva"].ConnectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}