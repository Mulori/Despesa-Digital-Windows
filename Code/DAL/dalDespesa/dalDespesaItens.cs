using DespesaDigital.Code.DTO.dtoDespesa;
using DespesaDigital.Core;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace DespesaDigital.Code.DAL.dalDespesa
{
    public class dalDespesaItens
    {
        public List<dtoDespesaItens> ListarTodoProdutoDespesaPorCodigo(long codigo_despesa)
        {
            var list = new List<dtoDespesaItens>();

            var ssql = $"select pd.codigo_despesa, pd.codigo_produto, p.descricao from produto_despesa pd " +
                $"inner join produto p on(pd.codigo_produto = p.codigo) where pd.codigo_despesa = '{codigo_despesa}' order by p.descricao asc";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoDespesaItens();
                    dto.codigo_despesa = Convert.ToInt32(dr["codigo_despesa"]);
                    dto.codigo_item = Convert.ToInt32(dr["codigo_produto"]);
                    dto.descricao = dr["descricao"].ToString();

                    list.Add(dto);
                }
                dr.Close();
            }

            return list;
        }

        public DataSet RelProdutosMaisAdquiridos(int codigo_categoria)
        {
            var ds = new DataSet();

            var ssql = $"select pd.codigo_produto, p.descricao, count(codigo_produto) as qtd from produto_despesa pd  " +
                $" left join produto p on(pd.codigo_produto = p.codigo)" +
                $" left join categoria c on(c.codigo = p.codigo_categoria)" +
                $" where c.codigo_departamento = '{VariaveisGlobais.codigo_departamento}'";


            if (codigo_categoria != -1)
            {
                ssql += $" and c.codigo = '{codigo_categoria}'";
            }

            ssql += $" group by pd.codigo_produto, p.descricao order by qtd desc";


            using (var ad = new NpgsqlDataAdapter(ssql, dalConexao.dalConexao.cnn))
            {
                ad.Fill(ds);
            }

            return ds;
        }
    }
}
