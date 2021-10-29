using Npgsql;

namespace DespesaDigital.Code.DAL.dalImagem
{
    public class dalImagem
    {
        public byte[] ObterByteImagemDespesaPorCodigo(long codigo_despesa)
        {
            byte[] productImageByte = null;

            var ssql = $"select dados_imagem from imagem where codigo_despesa = '{codigo_despesa}'";
            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    productImageByte = (byte[])dr["dados_imagem"];
                }
                dr.Close();
            }

            return productImageByte;
        }
    }
}
