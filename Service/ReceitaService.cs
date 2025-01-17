using controle_financeiro_api.Model.DTO.Request;
using controle_financeiro_api.Model;
using controle_financeiro_api.Repository;
using controle_financeiro_api.Model.Enum;

namespace controle_financeiro_api.Service
{
    public class ReceitaService : IReceitaService
    {
        private readonly IReceitaRepository _receitaRepository;
        private readonly IHistoricoRepository _historicoRepository;

        public ReceitaService(IReceitaRepository receitaRepository, IHistoricoRepository historicoRepository)
        {
            _receitaRepository = receitaRepository;
            _historicoRepository = historicoRepository;
        }

        public async Task<bool> Criar(ReceitaCriarRequest request)
        {
            await _receitaRepository.Criar(new Receita(request.UsuarioId, request.Valor, request.Data, request.Categoria.ToString()));
            return await _historicoRepository.Criar(new Historico(request.UsuarioId, HistoricoTipo.RECEITA.ToString(), request.Valor, request.Data, request.Categoria.ToString()));
        }

        public async Task<Receita> Obter(int usuarioId)
        {
            return await _receitaRepository.Obter(usuarioId);
        }
    }
}
