using controle_financeiro_api.Model.DTO.Request;
using controle_financeiro_api.Models;

namespace controle_financeiro_api.Service
{
    public interface IUsuarioService
    {
        Task<bool> Criar(UsuarioCriarAlterarRequest request);
        Task<bool> ValidarEmail(string email);
        Task<Usuario> Obter(int id);
        Task<bool> Alterar(int id, UsuarioCriarAlterarRequest request);
        Task<bool> AlterarSaldo(int id, UsuarioAdicionarSaldoRequest request);
    }
}
