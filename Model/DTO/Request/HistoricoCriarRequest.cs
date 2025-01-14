using System.ComponentModel.DataAnnotations;

namespace controle_financeiro_api.Model.DTO.Request
{
    public class HistoricoCriarRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Valor { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateOnly Data { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Categoria { get; set; }
    }
}
