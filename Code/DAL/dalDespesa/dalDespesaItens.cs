using DespesaDigital.Code.DTO.dtoDespesa;
using Npgsql;
using System;
using System.Collections.Generic;

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
    }
}
