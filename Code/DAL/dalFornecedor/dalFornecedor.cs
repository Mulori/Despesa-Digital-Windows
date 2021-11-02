using DespesaDigital.Code.DTO.dtoFornecedor;
using DespesaDigital.Core;
using Npgsql;
using System;
using System.Collections.Generic;

namespace DespesaDigital.Code.DAL.dalFornecedor
{
    public class dalFornecedor
    {
        public dtoFornecedor FornecedoresPorCodigo(int codigo_fornecedor)
        {
            var dto = new dtoFornecedor();

            var ssql = "select f.codigo, f.cnpj, f.razao_social, f.codigo_departamento, d.nome from fornecedor f " +
                $"inner join departamento d on(f.codigo_departamento = d.codigo) where d.codigo = '{VariaveisGlobais.codigo_departamento}' and f.codigo = '{codigo_fornecedor}'";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.cnpj = coreFormat.FormatCNPJ(dr["cnpj"].ToString());
                    dto.razao_social = dr["razao_social"].ToString();
                    dto.codigo_departamento = Convert.ToInt32(dr["codigo_departamento"]);
                    dto.s_codigo_departamento = dr["nome"].ToString();
                }
                dr.Close();
            }

            return dto;
        }

        public List<dtoFornecedor> ListarTodosFornecedoresPorRazaoSocial(string razao_social)
        {
            var list = new List<dtoFornecedor>();

            var ssql = "select f.codigo, f.cnpj, f.razao_social, f.codigo_departamento, d.nome from fornecedor f " +
                $"inner join departamento d on(f.codigo_departamento = d.codigo) where d.codigo = '{VariaveisGlobais.codigo_departamento}' and UPPER(f.razao_social) like UPPER('%{razao_social}%')";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoFornecedor();
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.cnpj = coreFormat.FormatCNPJ(dr["cnpj"].ToString());
                    dto.razao_social = dr["razao_social"].ToString();
                    dto.codigo_departamento = Convert.ToInt32(dr["codigo_departamento"]);
                    dto.s_codigo_departamento = dr["nome"].ToString();

                    list.Add(dto);
                }
                dr.Close();
            }

            return list;
        }

        public List<dtoFornecedor> ListarTodosFornecedoresPorCNPJ(string cnpj)
        {
            var list = new List<dtoFornecedor>();

            var ssql = "select f.codigo, f.cnpj, f.razao_social, f.codigo_departamento, d.nome from fornecedor f " +
                $"inner join departamento d on(f.codigo_departamento = d.codigo) where d.codigo = '{VariaveisGlobais.codigo_departamento}' and f.cnpj = '{cnpj}'";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoFornecedor();
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.cnpj = coreFormat.FormatCNPJ(dr["cnpj"].ToString());
                    dto.razao_social = dr["razao_social"].ToString();
                    dto.codigo_departamento = Convert.ToInt32(dr["codigo_departamento"]);
                    dto.s_codigo_departamento = dr["nome"].ToString();

                    list.Add(dto);
                }
                dr.Close();
            }

            return list;
        }

        public List<dtoFornecedor> ListarTodosFornecedores()
        {
            var list = new List<dtoFornecedor>();

            var ssql = "select f.codigo, f.cnpj, f.razao_social, f.codigo_departamento, d.nome from fornecedor f " +
                $"inner join departamento d on(f.codigo_departamento = d.codigo) where d.codigo = '{VariaveisGlobais.codigo_departamento}'";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoFornecedor();
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.cnpj = coreFormat.FormatCNPJ(dr["cnpj"].ToString());
                    dto.razao_social = dr["razao_social"].ToString();
                    dto.codigo_departamento = Convert.ToInt32(dr["codigo_departamento"]);
                    dto.s_codigo_departamento = dr["nome"].ToString();

                    list.Add(dto);
                }
                dr.Close();
            }

            return list;
        }

        public string CodigoFornecedoresContatenado(int departamento)
        {
            var retorno = "";

            var ssql = $"select codigo from fornecedor where codigo_departamento = '{departamento}'";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (retorno.Length > 0)
                    {
                        retorno += "," + dr["codigo"].ToString();
                    }
                    else
                    {
                        retorno += dr["codigo"].ToString();
                    }
                }
                dr.Close();
            }

            return retorno;
        }
        public bool VerificaCNPJExistente(string cnpj)
        {
            var retorno = false;

            var ssql = $"select cnpj from fornecedor where cnpj = '{cnpj}'";

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

        public string VerificaCNPJAtual(int codigo)
        {
            var retorno = "";

            var ssql = $"select cnpj from fornecedor where codigo = '{codigo}'";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    retorno = string.IsNullOrEmpty(dr["cnpj"].ToString()) ? "" : dr["cnpj"].ToString();
                }
                dr.Close();
            }

            return retorno;
        }

        public bool VerificaRazaoSocialExistente(string razao_social)
        {
            var retorno = false;

            var ssql = $"select razao_social from fornecedor where UPPER(razao_social) = UPPER('{razao_social}')";

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

        public string VerificaRazaoSocialAtual(int codigo)
        {
            var retorno = "";

            var ssql = $"select razao_social from fornecedor where codigo = '{codigo}'";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    retorno = string.IsNullOrEmpty(dr["razao_social"].ToString()) ? "" : dr["razao_social"].ToString();
                }
                dr.Close();
            }

            return retorno;
        }

        public bool Insert(dtoFornecedor dto)
        {
            var ssql = "insert into fornecedor (cnpj, razao_social, codigo_departamento) values (@cnpj, @razao_social, @codigo_departamento)";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            {
                cmd.Parameters.AddWithValue("@cnpj", dto.cnpj);
                cmd.Parameters.AddWithValue("@razao_social", dto.razao_social);
                cmd.Parameters.AddWithValue("@codigo_departamento", dto.codigo_departamento);

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
            var ssql = $"delete from fornecedor where codigo = '{codigo}'";

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

        public bool Update(dtoFornecedor dto)
        {
            var ssql = "update fornecedor set cnpj = @cnpj, razao_social = @razao_social, codigo_departamento = @codigo_departamento where codigo = @codigo";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            {
                cmd.Parameters.AddWithValue("@codigo", dto.codigo);
                cmd.Parameters.AddWithValue("@cnpj", dto.cnpj);
                cmd.Parameters.AddWithValue("@razao_social", dto.razao_social);
                cmd.Parameters.AddWithValue("@codigo_departamento", dto.codigo_departamento);

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
