using controle_financeiro_api.Model;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System.Data;

namespace controle_financeiro_api.Repository
{
    public class HistoricoRepository : IHistoricoRepository
    {
        private readonly string _connectionString;

        public HistoricoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Historico>> Listar(int usuarioId, int mes)
        {
            using IDbConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            string query = "SELECT * FROM Historico H " +
                           "WHERE H.Usuario_Id = @UsuarioId " +
                           "AND MONTH(H.Data) = @Mes";

            return await conn.QueryAsync<Historico>(query, new { UsuarioId = usuarioId, Mes = mes });
        }

        public async Task<bool> Criar(Historico historico)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            using IDbTransaction tran = connection.BeginTransaction();
            await connection.InsertAsync(historico, tran);
            tran.Commit();
            return true;
        }
    }
}
