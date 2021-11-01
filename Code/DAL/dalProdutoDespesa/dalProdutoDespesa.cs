using Npgsql;

namespace DespesaDigital.Code.DAL.dalProdutoDespesa
{
    public class dalProdutoDespesa
    {
        public int Insert(long codigo_despesa, long codigo_produto)
        {
            var ssql = $"insert into produto_despesa VALUES ('{codigo_despesa}', '{codigo_produto}');";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            {
                try
                {
                    return cmd.ExecuteNonQuery();
                }
                catch (NpgsqlException sql_erro)
                {
                    return sql_erro.ErrorCode;
                }
            }
        }
    }
}
