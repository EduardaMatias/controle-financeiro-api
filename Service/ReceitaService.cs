using controle_financeiro_api.Model.DTO.Request;
using controle_financeiro_api.Model;
using controle_financeiro_api.Repository;
using controle_financeiro_api.Model.Enum;
using controle_financeiro_api.Models;
using controle_financeiro_api.Model.DTO.Response;

namespace controle_financeiro_api.Service
{
    public class ReceitaService : IReceitaService
    {
        private readonly IReceitaRepository _receitaRepository;
        private readonly IHistoricoRepository _historicoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public ReceitaService(IReceitaRepository receitaRepository, IHistoricoRepository historicoRepository, IUsuarioRepository usuarioRepository)
        {
            _receitaRepository = receitaRepository;
            _historicoRepository = historicoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Criar(ReceitaCriarRequest request)
        {
            await _receitaRepository.Criar(new Receita(request.UsuarioId, request.Valor, request.Data, request.Categoria.ToString()));

            Usuario usuario = await _usuarioRepository.Obter(request.UsuarioId);
            usuario.AdicionarSaldo(request.Valor);
            await _usuarioRepository.Alterar(usuario);

            return await _historicoRepository.Criar(new Historico(request.UsuarioId, HistoricoTipo.RECEITA.ToString(), request.Valor, request.Data, request.Categoria.ToString()));
        }

        public async Task<ReceitaDespesaResponse> Listar(int usuarioId, Mes mes)
        {
            return await _receitaRepository.Listar(usuarioId, (int)mes);
        }
    }
}
