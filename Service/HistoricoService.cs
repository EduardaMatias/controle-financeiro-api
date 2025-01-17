using controle_financeiro_api.Model.DTO.Request;
using controle_financeiro_api.Model.Enum;
using controle_financeiro_api.Model;
using controle_financeiro_api.Repository;

namespace controle_financeiro_api.Service
{
    public class HistoricoService : IHistoricoService
    {
        private readonly IHistoricoRepository _historicoRepository;

        public HistoricoService(IHistoricoRepository historicoRepository)
        {
            _historicoRepository = historicoRepository;
        }

        public async Task<IEnumerable<Historico>> Listar(int usuarioId, Mes mes)
        {
            return await _historicoRepository.Listar(usuarioId, (int)mes);
        }
    }
}
