using DespesaDigital.Code.DAL.dalTipoDespesa;
using DespesaDigital.Code.DTO.dtoTipoDespesa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespesaDigital.Code.BLL.bllTipoDespesa
{
    public class bllTipoDespesa
    {
        public static List<dtoTipoDespesa> ListarTodosTipoDespesaPorStatusDescricao(string status, string descricao)
        {
            var dal = new dalTipoDespesa();
            return dal.ListarTodosTipoDespesaPorStatusDescricao(status, descricao);
        }

        public static List<dtoTipoDespesa> ListarTodasTipoDespesaPorStatus(string status)
        {
            var dal = new dalTipoDespesa();
            return dal.ListarTodasTipoDespesaPorStatus(status);
        }
    }
}
