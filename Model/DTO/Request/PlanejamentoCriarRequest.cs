using controle_financeiro_api.Model.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace controle_financeiro_api.Model.DTO.Request
{
    public class PlanejamentoCriarRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public PlanejamentoMes Mes { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Valor { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int UsuarioId { get; set; }
    }
}
