﻿using DespesaDigital.Core;
using Npgsql;
using System.Collections.Generic;

namespace DespesaDigital.Code.DAL.dalProdutoFornecedor
{
    public class dalProdutoFornecedor
    {
        public List<string> GetFornecedoresVinculado(int codigo_produto)
        {
            var retorno = new List<string>();

            var ssql = $"select f.razao_social, f.codigo, pf.codigo_produto from produto_fornecedor pf inner join fornecedor f on(pf.codigo_fornecedor = f.codigo) where pf.codigo_produto = '{codigo_produto}'";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    retorno.Add(dr["razao_social"].ToString());
                }
                dr.Close();
            }

            return retorno;
        }

        public bool DeleteSetorProduto(int codigo_produto)
        {
            var ssql = $"delete from produto_fornecedor where codigo_produto = '{codigo_produto}' and codigo_fornecedor in({VariaveisGlobais.fornecedores_concatenados})";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool InsertProdutoFornecedor(int codigo_fornecedor, int codigo_produto)
        {
            var ssql = "insert into produto_fornecedor VALUES (@codigo_produto, @codigo_fornecedor)";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            {
                cmd.Parameters.AddWithValue("@codigo_produto", codigo_produto);
                cmd.Parameters.AddWithValue("@codigo_fornecedor", codigo_fornecedor);

                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
