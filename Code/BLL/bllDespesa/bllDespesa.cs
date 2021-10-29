using DespesaDigital.Code.DAL.dalDespesa;
using DespesaDigital.Code.DTO.dtoDashboard;
using DespesaDigital.Code.DTO.dtoDespesa;
using System;
using System.Collections.Generic;
using System.Data;

namespace DespesaDigital.Code.BLL.bllDespesa
{
    public class bllDespesa
    {
        public static List<dtoDespesa> ListarTodasDespesasPorFormaPagamento(int codigo_forma_pagamento, DateTime inicial, DateTime final)
        {
            var dal = new dalDespesa();
            return dal.ListarTodasDespesasPorFormaPagamento(codigo_forma_pagamento, inicial, final);
        }

        public static List<dtoDespesa> ListarTodasDespesas(DateTime inicial, DateTime final, int codigo_forma_pagamento, int codigo_tipo_despesa, int codigo_setor)
        {
            var dal = new dalDespesa();
            return dal.ListarTodasDespesas(inicial, final, codigo_forma_pagamento, codigo_tipo_despesa, codigo_setor);
        }

        public static List<dtoDespesa> ListarTodasDespesasPorData(DateTime inicial, DateTime final)
        {
            var dal = new dalDespesa();
            return dal.ListarTodasDespesasPorData(inicial, final);
        }

        public static dtoDespesa DespesaPorCodigo(long codigo_despesa)
        {
            var dal = new dalDespesa();
            return dal.DespesaPorCodigo(codigo_despesa);
        }

        public static bool UpdateDespesa(dtoDespesa dto)
        {
            var dal = new dalDespesa();
            return dal.UpdateDespesa(dto);
        }

        public static DataSet DashboardTodoPeriodo()
        {
            var dal = new dalDespesa();
            return dal.DashboardTodoPeriodo();
        }
    }
}
