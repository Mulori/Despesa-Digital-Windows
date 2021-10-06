using DespesaDigital.Code.DAL.dalFormaPagamento;
using DespesaDigital.Code.DTO.dtoFormaPagamento;
using System.Collections.Generic;

namespace DespesaDigital.Code.BLL.bllFormaPagamento
{
    public class bllFormaPagamento
    {
        public static List<dtoFormaPagamento> ListarTodasFormasPagamentoPorStatus(string status)
        {
            var dal = new dalFormaPagamento();
            return dal.ListarTodasFormasPagamentoPorStatus(status);
        }

        public static List<dtoFormaPagamento> ListarTodasFormasPagamentoPorStatusDescricao(string status, string descricao)
        {
            var dal = new dalFormaPagamento();
            return dal.ListarTodasFormasPagamentoPorStatusDescricao(status, descricao);
        }
    }
}
