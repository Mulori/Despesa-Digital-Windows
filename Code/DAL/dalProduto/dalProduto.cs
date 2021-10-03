using DespesaDigital.Code.DTO.dtoProduto;
using DespesaDigital.Core;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespesaDigital.Code.DAL.dalProduto
{
    public class dalProduto
    {
        public List<dtoProduto> ListarTodosProdutosPorStatus(string status)
        {
            var list = new List<dtoProduto>();

            var ssql = "select distinct p.codigo , p.descricao as desc_prod, c.descricao as desc_cat, p.codigo_categoria, p.ativo from setor_produto sp";
            ssql += " inner join produto p on(sp.codigo_produto = p.codigo)";
            ssql += " inner join categoria c on(p.codigo_categoria = c.codigo)";
            ssql += " inner join setor s on(s.codigo = sp.codigo_setor)";
            ssql += " inner join departamento d on(d.codigo = s.codigo_departamento)";
            ssql += $" where d.codigo = '{VariaveisGlobais.codigo_departamento}'";

            if(VariaveisGlobais.nivel_acesso == 2)
            {
                ssql += $" and sp.codigo_setor = '{VariaveisGlobais.codigo_setor}'";
            }

            switch (status)
            {
                case "A":
                    ssql += $" and p.ativo = 'A'";
                    break;
                case "I":
                    ssql += $" and p.ativo = 'I'";
                    break;
            }

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoProduto();
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.descricao = dr["desc_prod"].ToString();

                    switch (dr["ativo"].ToString())
                    {
                        case "A":
                            dto.ativo = "Ativo";
                            break;
                        case "I":
                            dto.ativo = "Inativo";
                            break;
                    }                    

                    dto.s_codigo_categoria = dr["desc_cat"].ToString();
                    dto.codigo_categoria = Convert.ToInt32(dr["codigo_categoria"]);

                    list.Add(dto);
                }
                dr.Close();
            }

            return list;
        }

        public List<dtoProduto> ListarTodosProdutosPorStatusDescricao(string status, string descricao)
        {
            var list = new List<dtoProduto>();

            var ssql = "select distinct p.codigo , p.descricao as desc_prod, c.descricao as desc_cat, p.codigo_categoria, p.ativo from setor_produto sp";
            ssql += " inner join produto p on(sp.codigo_produto = p.codigo)";
            ssql += " inner join categoria c on(p.codigo_categoria = c.codigo)";
            ssql += " inner join setor s on(s.codigo = sp.codigo_setor)";
            ssql += " inner join departamento d on(d.codigo = s.codigo_departamento)";
            ssql += $" where d.codigo = '{VariaveisGlobais.codigo_departamento}' and UPPER(p.descricao) like UPPER('%{descricao}%')";

            if (VariaveisGlobais.nivel_acesso == 2)
            {
                ssql += $" and sp.codigo_setor = '{VariaveisGlobais.codigo_setor}'";
            }

            switch (status)
            {
                case "A":
                    ssql += $" and p.ativo = 'A'";
                    break;
                case "I":
                    ssql += $" and p.ativo = 'I'";
                    break;
            }

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoProduto();
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.descricao = dr["desc_prod"].ToString();

                    switch (dr["ativo"].ToString())
                    {
                        case "A":
                            dto.ativo = "Ativo";
                            break;
                        case "I":
                            dto.ativo = "Inativo";
                            break;
                    }

                    dto.s_codigo_categoria = dr["desc_cat"].ToString();
                    dto.codigo_categoria = Convert.ToInt32(dr["codigo_categoria"]);

                    list.Add(dto);
                }
                dr.Close();
            }

            return list;
        }

        public dtoProduto ProdutoPorCodigo(int codigo)
        {
            var dto = new dtoProduto();

            var ssql = "select p.codigo, p.descricao as produto, p.ativo, c.codigo as cod_categoria, c.descricao as categoria " +
                $"from produto p inner join categoria c on(p.codigo_categoria = c.codigo) where p.codigo = '{codigo}'";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.descricao = dr["produto"].ToString();

                    switch (dr["ativo"].ToString())
                    {
                        case "A":
                            dto.ativo = "Ativo";
                            break;
                        case "I":
                            dto.ativo = "Inativo";
                            break;
                    }

                    dto.s_codigo_categoria = dr["categoria"].ToString();
                    dto.codigo_categoria = Convert.ToInt32(dr["cod_categoria"]);
                }
                dr.Close();
            }

            return dto;
        }
    }
}
