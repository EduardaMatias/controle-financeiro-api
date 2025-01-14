using controle_financeiro_api.Model;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System.Data;

namespace controle_financeiro_api.Repository
{
    public class ReceitaRepository : IReceitaRepository
    {
        private readonly string _connectionString;

        public ReceitaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Receita> Obter(int usuarioId)
        {
            using IDbConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            string query = "SELECT * FROM Receita WHERE Usuario_Id = @UsuarioId";

            return await conn.QueryFirstOrDefaultAsync<Receita>(query, new { UsuarioId = usuarioId });
        }


        public async Task<bool> Criar(Receita receita)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            using IDbTransaction tran = connection.BeginTransaction();
            await connection.InsertAsync(receita, tran);
            tran.Commit();
            return true;
        }
    }
}
