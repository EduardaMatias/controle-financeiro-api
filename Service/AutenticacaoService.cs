using controle_financeiro_api.Model.DTO.Request;
using controle_financeiro_api.Model.Enum;
using controle_financeiro_api.Model;
using controle_financeiro_api.Models;
using controle_financeiro_api.Repository;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace controle_financeiro_api.Service
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly IAutenticacaoRepository _autenticacaoRepository;

        public AutenticacaoService(IAutenticacaoRepository autenticacaoRepository)
        {
            _autenticacaoRepository = autenticacaoRepository;
        }

        public async Task<string?> Login(AutenticacaoLoginRequest request)
        {
            return await _autenticacaoRepository.Login(request);
        }
    }
}
