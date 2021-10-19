using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespesaDigital.Code.DTO.dtoSolicitacaoCompra
{
    public class dtoSolicitacaoCompra
    {
        public int codigo { get; set; }
        public DateTime data_solicitacao { get; set; }
        public string motivo { get; set; }
        public decimal valor { get; set; }
        public string s_valor { get; set; }
        public string status { get; set; } 
        public int codigo_produto { get; set; }
        public int codigo_setor { get; set; }
        public string s_codigo_produto { get; set; }
        public string s_codigo_setor { get; set; }
        public string usuario { get; set; }
    }
}
