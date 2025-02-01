using controle_financeiro_api.Model;
using controle_financeiro_api.Model.DTO.Response;
using Dapper;
using Npgsql;
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

        public async Task<ReceitaDespesaResponse> Listar(int usuarioId, int mes)
        {
            using IDbConnection conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            string totalReceitas = @"SELECT COALESCE(SUM(R.""Valor""), 0)
                             FROM ""Receita"" R
                             WHERE R.""Usuario_Id"" = @UsuarioId
                             AND EXTRACT(MONTH FROM R.""Data"") = @Mes";

            var total = await conn.QueryFirstOrDefaultAsync<decimal>(totalReceitas, new { UsuarioId = usuarioId, Mes = mes });

            string receitas = @"SELECT R.""Id"", R.""Usuario_Id"", R.""Valor"", R.""Moeda"", R.""Data"", R.""Categoria""
                        FROM ""Receita"" R
                        WHERE R.""Usuario_Id"" = @UsuarioId
                        AND EXTRACT(MONTH FROM R.""Data"") = @Mes";

            var itens = await conn.QueryAsync<ReceitaDespesaItemResponse>(receitas, new { UsuarioId = usuarioId, Mes = mes });

            return new ReceitaDespesaResponse
            {
                Total = (int)total, 
                Itens = itens
            };
        }

        public async Task<bool> Criar(Receita receita)
        {
            using IDbConnection conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            string query = @"INSERT INTO ""Receita"" (""Usuario_Id"", ""Valor"", ""Moeda"", ""Data"", ""Categoria"")
                             VALUES (@Usuario_Id, @Valor, @Moeda, @Data, @Categoria)";

            using IDbTransaction tran = conn.BeginTransaction();
            int rowsAffected = await conn.ExecuteAsync(query, receita, tran);
            tran.Commit();

            return rowsAffected > 0;
        }
    }
}
