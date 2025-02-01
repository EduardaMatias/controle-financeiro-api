using controle_financeiro_api.Model;
using Dapper;
using Npgsql;
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
            using IDbConnection conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            string query = @"SELECT * FROM ""Historico"" H 
                            WHERE H.""Usuario_Id"" = @UsuarioId 
                            AND EXTRACT(MONTH FROM H.""Data"") = @Mes";

            return await conn.QueryAsync<Historico>(query, new { UsuarioId = usuarioId, Mes = mes });
        }

        public async Task<bool> Criar(Historico historico)
        {
            using IDbConnection conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            string query = @"INSERT INTO ""Historico"" (""Usuario_Id"", ""Tipo"", ""Valor"", ""Data"", ""Categoria"")
                           VALUES (@Usuario_Id, @Tipo, @Valor, @Data, @Categoria)";

            using IDbTransaction tran = conn.BeginTransaction();
            int rowsAffected = await conn.ExecuteAsync(query, historico, tran);
            tran.Commit();

            return rowsAffected > 0;
        }
    }
}
