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
        public static DataSet relTodasDespesasPorDepartamentoData(DateTime inicio, DateTime fim)
        {
            var dal = new dalDespesa();
            return dal.relTodasDespesasPorDepartamentoData(inicio, fim);
        }

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

        internal static object DashboardPeriodoUmAnoPorSetor(object variveisglobais)
        {
            throw new NotImplementedException();
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

        public static List<dtoDashboard> DashboardPeriodoUmAno()
        {
            var dal = new dalDespesa();
            return dal.DashboardPeriodoUmAno();
        }

        public static long NovaDespesa(dtoDespesa obj)
        {
            var dal = new dalDespesa();
            return dal.NovaDespesa(obj);
        }

        public static List<dtoDespesa> ListarTodasDespesas(DateTime inicial, DateTime final, int codigo_forma_pagamento, int codigo_tipo_despesa, int codigo_setor, int codigo_usuario)
        {
            var dal = new dalDespesa();
            return dal.ListarTodasDespesas(inicial, final, codigo_forma_pagamento, codigo_tipo_despesa, codigo_setor, codigo_usuario);
        }

        public static decimal DashboardTotalDespesa()
        {
            var dal = new dalDespesa();
            return dal.DashboardTotalDespesa();
        }

        public static List<object> DashboardQuantidadeDespesa()
        {
            var dal = new dalDespesa();
            return dal.DashboardQuantidadeDespesa();
        }

        public static decimal DashboardValorUltimaDespesa()
        {
            var dal = new dalDespesa();
            return dal.DashboardValorUltimaDespesa();
        }
    }
}
