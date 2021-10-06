using DespesaDigital.Code.DTO.dtoFornecedor;
using DespesaDigital.Core;
using Npgsql;
using System;
using System.Collections.Generic;

namespace DespesaDigital.Code.DAL.dalFornecedor
{
    public class dalFornecedor
    {
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
    }
}
