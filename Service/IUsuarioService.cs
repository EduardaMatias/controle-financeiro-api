using controle_financeiro_api.Model.DTO.Request;
using controle_financeiro_api.Models;

namespace controle_financeiro_api.Service
{
    public interface IUsuarioService
    {
        Task<bool> Criar(UsuarioCriarAlterarRequest request);
        Task<Usuario> Obter(int id);
        Task<bool> Alterar(int id, UsuarioCriarAlterarRequest request);
        Task<bool> AdicionarSaldo(int id, UsuarioAdicionarSaldoRequest request);
    }
}
