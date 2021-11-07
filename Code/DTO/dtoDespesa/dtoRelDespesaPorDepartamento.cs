using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespesaDigital.Code.DTO.dtoDespesa
{
    public class dtoRelDespesaPorDepartamento
    {
        public long codigo { get; set; }
        public DateTime data_hora_emissao { get; set; }
        public decimal valor { get; set; }
        public string descricao { get; set; }
        public string descricao_tipo_despesa { get; set; }
        public string nome_setor { get; set; }
        public string descricao_forma_pagamento { get; set; }
        public string nome_usuario { get; set; }
    }
}
