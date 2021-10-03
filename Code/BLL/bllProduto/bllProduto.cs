﻿using DespesaDigital.Code.DAL.dalProduto;
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
    }
}
