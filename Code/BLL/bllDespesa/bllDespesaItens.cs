using DespesaDigital.Code.DAL.dalDespesa;
using DespesaDigital.Code.DTO.dtoDespesa;
using System.Collections.Generic;

namespace DespesaDigital.Code.BLL.bllDespesa
{
    public class bllDespesaItens
    {
        public static List<dtoDespesaItens> ListarTodoProdutoDespesaPorCodigo(long codigo_despesa)
        {
            var dal = new dalDespesaItens();
            return dal.ListarTodoProdutoDespesaPorCodigo(codigo_despesa);
        }
    }
}
