using controle_financeiro_api.Model.DTO.Request;

namespace controle_financeiro_api.Service
{
    public interface IAutenticacaoService
    {
        Task<string?> Login(AutenticacaoLoginRequest request);
    }
}
