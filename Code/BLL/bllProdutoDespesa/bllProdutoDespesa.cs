using DespesaDigital.Code.DAL.dalProdutoDespesa;

namespace DespesaDigital.Code.BLL.bllProdutoDespesa
{
    public class bllProdutoDespesa
    {
        public static int Insert(long codigo_despesa, long codigo_produto)
        {
            var dal = new dalProdutoDespesa();
            return dal.Insert(codigo_despesa, codigo_produto);
        }
    }
}
