using DespesaDigital.Code.DTO.dtoImagem;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DespesaDigital.Code.DAL.dalImagem
{
    public class dalImagem
    {
        public List<dtoImagem> ObterByteImagemDespesaPorCodigo(long codigo_despesa)
        {
            var list = new List<dtoImagem>();

            var ssql = $"select dados_imagem, codigo from imagem where codigo_despesa = '{codigo_despesa}'";
            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoImagem();
                    dto.b_dados_imagem = (byte[])dr["dados_imagem"];
                    dto.codigo = Convert.ToInt64(dr["codigo"]);
                    list.Add(dto);
                }
                dr.Close();
            }

            return list;
        }

        public string ObterFormatoImagemDespesaPorCodigo(long codigo_despesa, long codigo)
        {
            string productImageFormat = null;

            var ssql = $"select formato from imagem where codigo_despesa = '{codigo_despesa}' and codigo = '{codigo}'";
            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    productImageFormat = dr["formato"].ToString();
                }
                dr.Close();
            }

            return productImageFormat;
        }

        public async Task<int> Insert(byte[] file_byte, long codigo_despesa, string formato)
        {
            var ssql = $"insert into imagem (dados_imagem, codigo_despesa, formato) VALUES(@dados, @codigo, @formato);";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            {
                cmd.Parameters.AddWithValue("@dados", file_byte);
                cmd.Parameters.AddWithValue("@codigo", codigo_despesa);
                cmd.Parameters.AddWithValue("@formato", formato);

                try
                {
                    return await cmd.ExecuteNonQueryAsync();
                }
                catch (NpgsqlException sql_erro)
                {
                    return sql_erro.ErrorCode;
                }
            }
        }
    }
}
