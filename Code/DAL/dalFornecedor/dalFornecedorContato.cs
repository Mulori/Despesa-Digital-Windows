using DespesaDigital.Code.DTO.dtoFornecedor;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespesaDigital.Code.DAL.dalFornecedor
{
    public class dalFornecedorContato
    {
        public bool Insert(dtoFornecedorContato dto)
        {
            var ssql = "insert into fornecedor_contato (codigo_fornecedor, telefone_celular) " +
                "values (@codigo_fornecedor, @telefone_celular)";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            {
                cmd.Parameters.AddWithValue("@codigo_fornecedor", dto.codigo_fornecedor);
                cmd.Parameters.AddWithValue("@telefone_celular", dto.telefone_celular);

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
            var ssql = $"delete from fornecedor_contato where codigo_fornecedor = '{codigo_fornecedor}' and codigo = '{codigo}'";

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

        public bool Update(dtoFornecedorContato dto)
        {
            var ssql = "update fornecedor_contato set telefone_celular = @telefone_celular where codigo = @codigo";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            {
                cmd.Parameters.AddWithValue("@telefone_celular", dto.telefone_celular);
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

        public List<dtoFornecedorContato> TodosContatoFornecedorCodigo(int codigo_fornecedor)
        {
            var list = new List<dtoFornecedorContato>();

            var ssql = $"select * from fornecedor_contato where codigo_fornecedor = '{codigo_fornecedor}'";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoFornecedorContato();
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.codigo_fornecedor = Convert.ToInt32(dr["codigo_fornecedor"]);
                    dto.telefone_celular = dr["telefone_celular"].ToString();

                    list.Add(dto);
                }
                dr.Close();
            }

            return list;
        }

        public dtoFornecedorContato ContatoCodigo(int codigo_fornecedor)
        {
            var dto = new dtoFornecedorContato();

            var ssql = $"select * from fornecedor_contato where codigo = '{codigo_fornecedor}'";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.codigo_fornecedor = Convert.ToInt32(dr["codigo_fornecedor"]);
                    dto.telefone_celular = dr["telefone_celular"].ToString();
                }
                dr.Close();
            }

            return dto;
        }
    }
}
