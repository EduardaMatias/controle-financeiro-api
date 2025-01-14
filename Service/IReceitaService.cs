using controle_financeiro_api.Model;
using controle_financeiro_api.Model.DTO.Request;

namespace controle_financeiro_api.Service
{
    public interface IReceitaService
    {
        Task<bool> Criar(ReceitaCriarRequest request);
        Task<Receita> Obter(int id);
    }
}
