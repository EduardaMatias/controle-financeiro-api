using controle_financeiro_api.Model;
using controle_financeiro_api.Model.DTO.Request;
using controle_financeiro_api.Model.Enum;
using controle_financeiro_api.Models;
using controle_financeiro_api.Repository;

namespace controle_financeiro_api.Service
{
    public class PlanejamentoService : IPlanejamentoService
    {
        private readonly IPlanejamentoRepository _planejamentoRepository;
        private readonly ILogger<PlanejamentoService> _logger;

        public PlanejamentoService(IPlanejamentoRepository planejamentoRepository, ILogger<PlanejamentoService> logger)
        {
            _planejamentoRepository = planejamentoRepository;
            _logger = logger;
        }

        public async Task<bool> Criar(PlanejamentoCriarRequest request)
        {
            var planejamento = await _planejamentoRepository.Obter(request.UsuarioId, request.Mes.ToString());

            if (planejamento != null)
            {
                _logger.LogWarning("O planejamento para esse mês já foi cadastrado");
                return false;
            }
            else
            {
                await _planejamentoRepository.Criar(new Planejamento(request.UsuarioId, request.Valor, request.Mes.ToString()));
            }

            return true;
        }

        public async Task<Planejamento> Obter(int usuarioId, string mes)
        {
            return await _planejamentoRepository.Obter(usuarioId, mes);
        }

        public async Task<bool> Alterar(int id, PlanejamentoAlterarRequest request)
        {
            Planejamento planejamento = await _planejamentoRepository.Obter(id);
            planejamento.Alterar(request.Valor);
            return await _planejamentoRepository.Alterar(planejamento);
        }
    }
}
