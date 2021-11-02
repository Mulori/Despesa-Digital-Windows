using DespesaDigital.Code.BLL.bllCategoria;
using DespesaDigital.Code.DTO.dtoProduto;
using DespesaDigital.Core;
using Npgsql;
using System;
using System.Collections.Generic;

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

        public bool Insert(dtoProduto dto)
        {
            var ssql = "insert into produto (descricao, ativo, codigo_categoria) values (@descricao, @ativo, @codigo_categoria)";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            {
                cmd.Parameters.AddWithValue("@descricao", dto.descricao);
                cmd.Parameters.AddWithValue("@ativo", dto.ativo);
                cmd.Parameters.AddWithValue("@codigo_categoria", dto.codigo_categoria);

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

        public bool Delete(int codigo)
        {
            var ssql = $"delete from produto where codigo = '{codigo}'";

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

        public bool Update(dtoProduto dto)
        {
            var ssql = "update produto set descricao = @descricao, ativo = @ativo, codigo_categoria = @codigo_categoria where codigo = @codigo";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            {
                cmd.Parameters.AddWithValue("@codigo", dto.codigo);
                cmd.Parameters.AddWithValue("@descricao", dto.descricao);
                cmd.Parameters.AddWithValue("@ativo", dto.ativo);
                cmd.Parameters.AddWithValue("@codigo_categoria", dto.codigo_categoria);

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

        public bool VerificaNomeExistente(string descricao)
        {
            var retorno = false;

            var ssql = "select distinct p.codigo , p.descricao as desc_prod, c.descricao as desc_cat, p.codigo_categoria, p.ativo from setor_produto sp";
            ssql += " inner join produto p on(sp.codigo_produto = p.codigo)";
            ssql += " inner join categoria c on(p.codigo_categoria = c.codigo)";
            ssql += " inner join setor s on(s.codigo = sp.codigo_setor)";
            ssql += " inner join departamento d on(d.codigo = s.codigo_departamento)";
            ssql += $" where d.codigo = '{VariaveisGlobais.codigo_departamento}' and UPPER(p.descricao) like UPPER('%{descricao}%')";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    retorno = true;
                }
                dr.Close();
            }

            return retorno;
        }

        public int PegarUltimoCodigo()
        {
            var retorno = 0;

            var ssql = "select max(codigo) as codigo from produto";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    retorno = string.IsNullOrEmpty(dr["codigo"].ToString()) ? 0 : Convert.ToInt32(dr["codigo"]);
                }
                dr.Close();
            }

            return retorno;
        }

        public int NovoProdutoRapido(string descricao, int codigo_setor)
        {
            var retorno = 0;

            var ssql = $"select NovoProdutoRapido('{descricao}', '{bllCategoria.GetCategoriaOutros()}', '{codigo_setor}');";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    retorno = int.Parse(dr["NovoProdutoRapido"].ToString());
                }

                dr.Close();
            }

            return retorno;
        }
    }
}
