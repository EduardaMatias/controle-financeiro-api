using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace controle_financeiro_api.Model
{
    [Table("Receita")]
    public class Receita
    {
        public Receita() { }

        public Receita(int usuarioId, double valor, DateOnly data, string categoria)
        {
            this.Usuario_Id = usuarioId;
            this.Valor = valor;
            this.Moeda = "BRL";
            this.Data = data;
            this.Categoria = categoria;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public int Usuario_Id { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public string Moeda { get; set; }
        [Required]
        public DateOnly Data { get; set; }
        [Required]
        public string Categoria { get; set; }

    }
}
