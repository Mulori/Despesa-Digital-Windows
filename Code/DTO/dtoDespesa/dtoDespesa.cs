using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespesaDigital.Code.DTO.dtoDespesa
{
    public class dtoDespesa
    {
        public long codigo { get; set; }
        public DateTime data_hora_emissao { get; set; }
        public decimal valor { get; set; }
        public string s_valor { get; set; }
        public string descricao { get; set; }
        public int codigo_tipo_despesa { get; set; }
        public int codigo_setor { get; set; }
        public int codigo_forma_pagamento { get; set; }
        public int codigo_usuario { get; set; }
        public string s_codigo_setor { get; set; }
        public string s_codigo_forma_pagamento { get; set; }
        public string s_codigo_usuario { get; set; }
        public string s_codigo_tipo_despesa { get; set; }
    }
}
