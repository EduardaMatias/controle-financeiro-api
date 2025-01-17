using controle_financeiro_api.Model;
using controle_financeiro_api.Model.DTO.Request;
using controle_financeiro_api.Model.Enum;
using controle_financeiro_api.Models;
using controle_financeiro_api.Repository;

namespace controle_financeiro_api.Service
{
    public class DespesaService : IDespesaService
    {
        private readonly IDespesaRepository _despesaRepository;
        private readonly IHistoricoRepository _historicoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<DespesaService> _logger;

        public DespesaService(IDespesaRepository despesaRepository, IHistoricoRepository historicoRepository, IUsuarioRepository usuarioRepository, ILogger<DespesaService> logger)
        {
            _despesaRepository = despesaRepository;
            _historicoRepository = historicoRepository;
            _usuarioRepository = usuarioRepository;
            _logger = logger;
        }

        public async Task<bool> Criar(DespesaCriarRequest request)
        {
            await _despesaRepository.Criar(new Despesa(request.UsuarioId, request.Valor, request.Data, request.Categoria.ToString()));

            Usuario usuario = await _usuarioRepository.Obter(request.UsuarioId);

            if (usuario.Saldo < request.Valor)
            {
                _logger.LogWarning("Não existe saldo suficiente para concluir essa transação.");
                return false;
            }

            usuario.SubtrairSaldo(request.Valor);
            await _usuarioRepository.Alterar(usuario);

            return await _historicoRepository.Criar(new Historico(request.UsuarioId, HistoricoTipo.RECEITA.ToString(), request.Valor, request.Data, request.Categoria.ToString()));
        }

        public async Task<Despesa> Obter(int usuarioId)
        {
            return await _despesaRepository.Obter(usuarioId);
        }
    }
}
