using controle_financeiro_api.Model;
using controle_financeiro_api.Model.DTO.Response;
using Dapper;
using Npgsql;
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

        public async Task<ReceitaDespesaResponse> Listar(int usuarioId, int mes)
        {
            using IDbConnection conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            string totalDespesas = @"SELECT COALESCE(SUM(D.""Valor""), 0)
                             FROM ""Despesa"" D
                             WHERE D.""Usuario_Id"" = @UsuarioId
                             AND EXTRACT(MONTH FROM D.""Data"") = @Mes";

            var total = await conn.QueryFirstOrDefaultAsync<decimal>(totalDespesas, new { UsuarioId = usuarioId, Mes = mes });

            string despesas = @"SELECT D.""Id"", D.""Usuario_Id"", D.""Valor"", D.""Moeda"", D.""Data"", D.""Categoria""
                        FROM ""Despesa"" D
                        WHERE D.""Usuario_Id"" = @UsuarioId
                        AND EXTRACT(MONTH FROM D.""Data"") = @Mes";

            var itens = await conn.QueryAsync<ReceitaDespesaItemResponse>(despesas, new { UsuarioId = usuarioId, Mes = mes });

            return new ReceitaDespesaResponse
            {
                Total = (int)total, 
                Itens = itens
            };
        }

        public async Task<bool> Criar(Despesa despesa)
        {
            using IDbConnection conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            string query = @"INSERT INTO ""Despesa"" (""Usuario_Id"", ""Valor"", ""Moeda"", ""Data"", ""Categoria"")
                             VALUES (@Usuario_Id, @Valor, @Moeda, @Data, @Categoria)";

            using IDbTransaction tran = conn.BeginTransaction();
            int rowsAffected = await conn.ExecuteAsync(query, despesa, tran);
            tran.Commit();

            return rowsAffected > 0;
        }
    }
}
