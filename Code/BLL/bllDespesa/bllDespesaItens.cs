using DespesaDigital.Code.DAL.dalDespesa;
using DespesaDigital.Code.DTO.dtoDespesa;
using System.Collections.Generic;
using System.Data;

namespace DespesaDigital.Code.BLL.bllDespesa
{
    public class bllDespesaItens
    {
        public static List<dtoDespesaItens> ListarTodoProdutoDespesaPorCodigo(long codigo_despesa)
        {
            var dal = new dalDespesaItens();
            return dal.ListarTodoProdutoDespesaPorCodigo(codigo_despesa);
        }

        public static DataSet RelProdutosMaisAdquiridos(int codigo_categoria)
        {
            var dal = new dalDespesaItens();
            return dal.RelProdutosMaisAdquiridos(codigo_categoria);
        }
    }
}
