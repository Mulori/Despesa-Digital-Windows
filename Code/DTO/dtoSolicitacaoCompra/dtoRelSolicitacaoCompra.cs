using System;

namespace DespesaDigital.Code.DTO
{
    public class dtoRelSolicitacaoCompra
    {
        public int codigo { get; set; }
        public DateTime data_solicitacao { get; set; }
        public string motivo { get; set; }
        public decimal valor { get; set; }
        public string usuario_solicitacao { get; set; }
        public string status { get; set; }
        public string usuario_aprovacao { get; set; }
        public string setor { get; set; }
        public string item { get; set; }
    }
}
