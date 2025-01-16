using controle_financeiro_api.Model;
using controle_financeiro_api.Model.Enum;
using controle_financeiro_api.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
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

        public async Task<Planejamento> Obter(PlanejamentoMes mes)
        {
            using IDbConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            string query = "SELECT * FROM Planejamento " +
                            "WHERE Mes = @Mes";

            return await conn.QueryFirstOrDefaultAsync<Planejamento>(query, new { Mes = mes });
        }

        public async Task<Planejamento> Obter(int usuarioId, string mes)
        {
            using IDbConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            string query = "SELECT * FROM Planejamento " +
                            "WHERE Usuario_Id = @UsuarioId " +
                            "AND Mes = @Mes";

            return await conn.QueryFirstOrDefaultAsync<Planejamento>(query, new { UsuarioId = usuarioId, Mes = mes });
        }

        public async Task<Planejamento> Obter(int id)
        {
            using IDbConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            string query = "SELECT * FROM Planejamento " +
                            "WHERE Id = @Id";

            return await conn.QueryFirstOrDefaultAsync<Planejamento>(query, new { Id = id });
        }

        public async Task<bool> Criar(Planejamento planejamento)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            using IDbTransaction tran = connection.BeginTransaction();
            await connection.InsertAsync(planejamento, tran);
            tran.Commit();
            return true;
        }

        public async Task<bool> Alterar(Planejamento planejamento)
        {
            using IDbConnection connectionDapper = new SqlConnection(_connectionString);
            connectionDapper.Open();

            using IDbTransaction tran = connectionDapper.BeginTransaction();
            await connectionDapper.UpdateAsync(planejamento, tran);
            tran.Commit();
            return true;
        }
    }
}
