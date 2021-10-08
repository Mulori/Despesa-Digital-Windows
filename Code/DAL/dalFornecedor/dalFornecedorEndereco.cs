using DespesaDigital.Code.DTO.dtoFornecedor;
using Npgsql;
using System;
using System.Collections.Generic;

namespace DespesaDigital.Code.DAL.dalFornecedor
{
    public class dalFornecedorEndereco
    {
        public bool Insert(dtoFornecedorEndereco dto)
        {
            var ssql = "insert into fornecedor_endereco (codigo_fornecedor, logradouro, bairro, cidade, estado, pais, cep) " +
                "values (@codigo_fornecedor, @logradouro, @bairro, @cidade, @estado, @pais, @cep)";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            {
                cmd.Parameters.AddWithValue("@codigo_fornecedor", dto.codigo_fornecedor);
                cmd.Parameters.AddWithValue("@logradouro", dto.logradouro);
                cmd.Parameters.AddWithValue("@bairro", dto.bairro);
                cmd.Parameters.AddWithValue("@cidade", dto.cidade);
                cmd.Parameters.AddWithValue("@estado", dto.estado);
                cmd.Parameters.AddWithValue("@pais", dto.pais);
                cmd.Parameters.AddWithValue("@cep", dto.cep);

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

        public bool Delete(int codigo, int codigo_fornecedor)
        {
            var ssql = $"delete from fornecedor_endereco where codigo_fornecedor = '{codigo_fornecedor}' and codigo = '{codigo}'";

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

        public bool Update(dtoFornecedorEndereco dto)
        {
            var ssql = "update fornecedor_endereco set codigo_fornecedor = @codigo_fornecedor, logradouro = @logradouro, bairro = @bairro, " +
                "cidade = @cidade, estado = @estado, pais = @pais, cep = @cep where codigo = @codigo";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            {
                cmd.Parameters.AddWithValue("@codigo_fornecedor", dto.codigo_fornecedor);
                cmd.Parameters.AddWithValue("@logradouro", dto.logradouro);
                cmd.Parameters.AddWithValue("@bairro", dto.bairro);
                cmd.Parameters.AddWithValue("@cidade", dto.cidade);
                cmd.Parameters.AddWithValue("@estado", dto.estado);
                cmd.Parameters.AddWithValue("@pais", dto.pais);
                cmd.Parameters.AddWithValue("@cep", dto.cep);
                cmd.Parameters.AddWithValue("@codigo", dto.codigo);

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

        public List<dtoFornecedorEndereco> TodosEnderecoFornecedorCodigo(int codigo_fornecedor)
        {
            var list = new List<dtoFornecedorEndereco>();

            var ssql = $"select * from fornecedor_endereco where codigo_fornecedor = '{codigo_fornecedor}'";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoFornecedorEndereco();
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.codigo_fornecedor = Convert.ToInt32(dr["codigo_fornecedor"]);
                    dto.logradouro = dr["logradouro"].ToString();
                    dto.bairro = dr["bairro"].ToString();
                    dto.cidade = dr["cidade"].ToString();
                    dto.cep = dr["cep"].ToString();
                    dto.pais = dr["pais"].ToString();
                    dto.estado = dr["estado"].ToString();

                    list.Add(dto);
                }
                dr.Close();
            }

            return list;
        }

        public dtoFornecedorEndereco EnderecoCodigo(int codigo_fornecedor)
        {
            var dto = new dtoFornecedorEndereco();

            var ssql = $"select * from fornecedor_endereco where codigo = '{codigo_fornecedor}'";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.codigo_fornecedor = Convert.ToInt32(dr["codigo_fornecedor"]);
                    dto.logradouro = dr["logradouro"].ToString();
                    dto.bairro = dr["bairro"].ToString();
                    dto.cidade = dr["cidade"].ToString();
                    dto.cep = dr["cep"].ToString();
                    dto.pais = dr["pais"].ToString();
                    dto.estado = dr["estado"].ToString();
                }
                dr.Close();
            }

            return dto;
        }
    }
}
