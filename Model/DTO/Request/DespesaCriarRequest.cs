using controle_financeiro_api.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace controle_financeiro_api.Model.DTO.Request
{
    public class DespesaCriarRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Valor { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateOnly Data { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DespesaCategoria Categoria { get; set; }
    }
}
