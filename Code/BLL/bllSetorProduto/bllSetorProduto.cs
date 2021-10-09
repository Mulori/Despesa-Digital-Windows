using DespesaDigital.Code.DAL.dalSetorProduto;
using DespesaDigital.Code.DTO.dtoSetor;
using System.Collections.Generic;

namespace DespesaDigital.Code.BLL.bllSetorProduto
{
    public class bllSetorProduto
    {
        public static bool InsertSetorProduto(List<dtoSetor> list, int codigo_produto)
        {
            var dal = new dalSetorProduto();

            foreach(var setor in list)
            {
                if(!dal.InsertSetorProduto(setor.codigo, codigo_produto))
                {
                    return false;
                }
            }

            dal = null;

            return true;
        }

        public static bool DeleteSetorProduto(int codigo_produto)
        {
            var dal = new dalSetorProduto();
            return dal.DeleteSetorProduto(codigo_produto);
        }

        public static List<string> GetSetoresVinculado(int codigo_produto)
        {
            var dal = new dalSetorProduto();
            return dal.GetSetoresVinculado(codigo_produto);
        }

        public static List<dtoSetor> SetorProdutoPorCodigoProduto(int codigo_produto)
        {
            var dal = new dalSetorProduto();
            return dal.SetorProdutoPorCodigoProduto(codigo_produto);
        }
    }
}
