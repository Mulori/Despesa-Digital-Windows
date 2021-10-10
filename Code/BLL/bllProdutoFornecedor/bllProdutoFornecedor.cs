using DespesaDigital.Code.DAL.dalProdutoFornecedor;
using DespesaDigital.Code.DTO.dtoFornecedor;
using System.Collections.Generic;

namespace DespesaDigital.Code.BLL.bllProdutoFornecedor
{
    public class bllProdutoFornecedor
    {
        public static List<string> GetFornecedoresVinculado(int codigo_produto)
        {
            var dal = new dalProdutoFornecedor();
            return dal.GetFornecedoresVinculado(codigo_produto);
        }

        public static bool DeleteSetorProduto(int codigo_produto)
        {
            var dal = new dalProdutoFornecedor();
            return dal.DeleteSetorProduto(codigo_produto);
        }

        public static bool InsertProdutoFornecedor(List<dtoFornecedor> list, int codigo_produto)
        {
            var dal = new dalProdutoFornecedor();

            foreach (var fornecedor in list)
            {
                if (!dal.InsertProdutoFornecedor(fornecedor.codigo, codigo_produto))
                {
                    return false;
                }
            }

            dal = null;

            return true;
        }

        public static List<dtoFornecedor> ProdutoFornecedorPorCodigoProduto(int codigo_produto)
        {
            var dal = new dalProdutoFornecedor();
            return dal.ProdutoFornecedorPorCodigoProduto(codigo_produto);
        }
    }
}
