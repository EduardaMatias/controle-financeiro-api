using System.ComponentModel.DataAnnotations;

namespace controle_financeiro_api.Model.DTO.Response
{
    public class ReceitaDespesaResponse
    {
        public ReceitaDespesaResponse()
        {
            this.Total = 0;
            this.Itens = new List<ReceitaDespesaItemResponse>();
        }

        public ReceitaDespesaResponse(IEnumerable<ReceitaDespesaItemResponse> itens, int total)
        {
            this.Total = total;
            this.Itens = itens;
        }

        public int Total { get; set; }
        public IEnumerable<ReceitaDespesaItemResponse> Itens { get; set; }
    }

    public class ReceitaDespesaItemResponse
    {
        public int Id { get; set; }
        public int Usuario_Id { get; set; }
        public double Valor { get; set; }
        public string Moeda { get; set; }
        public DateTime Data { get; set; }
        public string Categoria { get; set; }
    }
}
