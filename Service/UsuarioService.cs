using controle_financeiro_api.Model.DTO.Request;
using controle_financeiro_api.Models;
using controle_financeiro_api.Repository;

namespace controle_financeiro_api.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<UsuarioService> _logger;

        public UsuarioService(IUsuarioRepository usuarioRepository, ILogger<UsuarioService> logger)
        {
            _usuarioRepository = usuarioRepository;
            _logger = logger;
        }

        public async Task<bool> Criar(UsuarioCriarAlterarRequest request)
        {
            return await _usuarioRepository.Criar(new Usuario(request.Nome, request.Email, request.Senha));
        }

        public async Task<Usuario> Obter(int id)
        {
            return await _usuarioRepository.Obter(id);
        }

        public async Task<bool> Alterar(int id, UsuarioCriarAlterarRequest request)
        {
            Usuario usuario = await _usuarioRepository.Obter(id);
            usuario.Alterar(request.Nome, request.Email, request.Senha);
            return await _usuarioRepository.Alterar(usuario);
        }

        public async Task<bool> AdicionarSaldo(int id, UsuarioAdicionarSaldoRequest request)
        {
            Usuario usuario = await _usuarioRepository.Obter(id);

            if (usuario.Saldo.HasValue)
            {
                _logger.LogWarning("O usuário já adicionou o saldo");
                return false;
            }

            usuario.AdicionarSaldo(request.Saldo);
            return await _usuarioRepository.Alterar(usuario);
        }
    }
}
