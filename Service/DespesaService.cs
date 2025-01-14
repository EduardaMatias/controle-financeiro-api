using controle_financeiro_api.Model;
using controle_financeiro_api.Model.DTO.Request;
using controle_financeiro_api.Model.Enum;
using controle_financeiro_api.Repository;

namespace controle_financeiro_api.Service
{
    public class DespesaService : IDespesaService
    {
        private readonly IDespesaRepository _despesaRepository;
        private readonly IHistoricoRepository _historicoRepository;

        public DespesaService(IDespesaRepository despesaRepository, IHistoricoRepository historicoRepository)
        {
            _despesaRepository = despesaRepository;
            _historicoRepository = historicoRepository;
        }

        public async Task<bool> Criar(DespesaCriarRequest request)
        {
            await _despesaRepository.Criar(new Despesa(request.UsuarioId, request.Valor, request.Data, request.Categoria));
            return await _historicoRepository.Criar(new Historico(request.UsuarioId, HistoricoTipo.DESPESA.ToString(), request.Valor, request.Data, request.Categoria));
        }

        public async Task<Despesa> Obter(int usuarioId)
        {
            return await _despesaRepository.Obter(usuarioId);
        }
    }
}
