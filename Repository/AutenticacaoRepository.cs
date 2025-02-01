using controle_financeiro_api.Model.DTO.Request;
using controle_financeiro_api.Models;
using Dapper;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace controle_financeiro_api.Repository
{
    public class AutenticacaoRepository : IAutenticacaoRepository
    {
        private readonly string _connectionString;
        private readonly string _jwtKey;

        public AutenticacaoRepository(string connectionString, string jwtKey)
        {
            _connectionString = connectionString;
            _jwtKey = jwtKey;
        }

        public async Task<string?> Login(AutenticacaoLoginRequest request)
        {
            using IDbConnection conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            string query = @"SELECT * FROM ""Usuario"" WHERE ""Email"" = @Email";
            var usuario = await conn.QueryFirstOrDefaultAsync<Usuario>(query, new { request.Email });

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(request.Senha, usuario.Senha))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new(ClaimTypes.Name, usuario.Id.ToString()),
                    new(ClaimTypes.Email, usuario.Email)
                ]),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
