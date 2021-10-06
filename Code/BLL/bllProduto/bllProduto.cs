using DespesaDigital.Code.DAL.dalProduto;
using DespesaDigital.Code.DTO.dtoProduto;
using System.Collections.Generic;

namespace DespesaDigital.Code.BLL.bllProduto
{
    public class bllProduto
    {
        public static List<dtoProduto> ListarTodosProdutosPorStatus(string status)
        {
            var dal = new dalProduto();
            return dal.ListarTodosProdutosPorStatus(status);
        }

        public static List<dtoProduto> ListarTodosProdutosPorStatusDescricao(string status, string descricao)
        {
            var dal = new dalProduto();
            return dal.ListarTodosProdutosPorStatusDescricao(status, descricao);
        }

        public static dtoProduto ProdutoPorCodigo(int codigo)
        {
            var dal = new dalProduto();
            return dal.ProdutoPorCodigo(codigo);
        }

        public static bool VerificaNomeExistente(string descricao)
        {
            var dal = new dalProduto();
            return dal.VerificaNomeExistente(descricao);
        }

        public static bool Update(dtoProduto dto)
        {
            var dal = new dalProduto();
            return dal.Update(dto);
        }

        public static bool Insert(dtoProduto dto)
        {
            var dal = new dalProduto();
            return dal.Insert(dto);
        }

        public static int PegarUltimoCodigo()
        {
            var dal = new dalProduto();
            return dal.PegarUltimoCodigo();
        }

        public static bool Delete(int codigo)
        {
            var dal = new dalProduto();
            return dal.Delete(codigo);
        }
    }
}
