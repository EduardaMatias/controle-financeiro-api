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

        public async Task<Historico> Obter(int usuarioId)
        {
            using IDbConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            string query = "SELECT * FROM Historico WHERE Usuario_Id = @UsuarioId";

            return await conn.QueryFirstOrDefaultAsync<Historico>(query, new { UsuarioId = usuarioId });
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
