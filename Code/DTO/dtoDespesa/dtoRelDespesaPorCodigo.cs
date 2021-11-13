using System;

namespace DespesaDigital.Code.DTO.dtoDespesa
{
    public class dtoRelDespesaPorCodigo
    {
        public long codigo { get; set; }
        public DateTime data_hora_emissao { get; set; }
        public decimal valor { get; set; }
        public string usuario { get; set; }
        public string forma_paramento { get; set; }
        public string tipo { get; set; }
        public string setor { get; set; }
        public string departamento { get; set; }
        public string descricao { get; set; }
    }
}
