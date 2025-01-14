using controle_financeiro_api.Model;
using controle_financeiro_api.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System.Data;

namespace controle_financeiro_api.Repository
{
    public class DespesaRepository : IDespesaRepository
    {
        private readonly string _connectionString;

        public DespesaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Despesa> Obter(int usuarioId)
        {
            using IDbConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            string query = "SELECT * FROM Receita WHERE Usuario_Id = @UsuarioId";

            return await conn.QueryFirstOrDefaultAsync<Despesa>(query, new { UsuarioId = usuarioId });
        }

        public async Task<bool> Criar(Despesa despesa)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            using IDbTransaction tran = connection.BeginTransaction();
            await connection.InsertAsync(despesa, tran);
            tran.Commit();
            return true;
        }
    }
}
