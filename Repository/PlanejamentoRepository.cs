using controle_financeiro_api.Model;
using Dapper;
using Npgsql;
using System.Data;

namespace controle_financeiro_api.Repository
{
    public class PlanejamentoRepository : IPlanejamentoRepository
    {
        private readonly string _connectionString;

        public PlanejamentoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Planejamento?> Obter(int usuarioId, string mes)
        {
            using IDbConnection conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            string query = @"SELECT * FROM ""Planejamento"" 
                            WHERE ""Usuario_Id"" = @UsuarioId 
                            AND ""Mes"" = @Mes";

            return await conn.QueryFirstOrDefaultAsync<Planejamento?>(query, new { UsuarioId = usuarioId, Mes = mes });
        }

        public async Task<Planejamento> Obter(int id)
        {
            using IDbConnection conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            string query = @"SELECT * FROM ""Planejamento"" 
                            WHERE ""Id"" = @Id";

            return await conn.QueryFirstOrDefaultAsync<Planejamento>(query, new { Id = id });
        }

        public async Task<bool> Criar(Planejamento planejamento)
        {
            using IDbConnection conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            string query = @"INSERT INTO ""Planejamento"" (""Usuario_Id"", ""Valor"", ""Mes"")
                     VALUES (@Usuario_Id, @Valor, @Mes)";

            using IDbTransaction tran = conn.BeginTransaction();
            int rowsAffected = await conn.ExecuteAsync(query, planejamento, tran);
            tran.Commit();

            return rowsAffected > 0;
        }

        public async Task<bool> Alterar(Planejamento planejamento)
        {
            using IDbConnection conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            string query = @"UPDATE ""Planejamento""
                     SET ""Usuario_Id"" = @Usuario_Id, ""Valor"" = @Valor, ""Mes"" = @Mes
                     WHERE ""Id"" = @Id";

            using IDbTransaction tran = conn.BeginTransaction();
            int rowsAffected = await conn.ExecuteAsync(query, planejamento, tran);
            tran.Commit();

            return rowsAffected > 0;
        }
    }
}
