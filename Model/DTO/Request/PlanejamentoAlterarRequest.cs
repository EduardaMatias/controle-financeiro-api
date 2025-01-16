using System.ComponentModel.DataAnnotations;

namespace controle_financeiro_api.Model.DTO.Request
{
    public class PlanejamentoAlterarRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Valor { get; set; }
    }
}
