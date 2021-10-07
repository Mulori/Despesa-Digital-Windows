using DespesaDigital.Code.DTO.dtoFornecedor;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var ssql = "update fornecedor set codigo_fornecedor = @codigo_fornecedor, logradouro = @logradouro, bairro = @bairro, " +
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
    }
}
