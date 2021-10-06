using DespesaDigital.Core;
using Npgsql;
using System.Collections.Generic;

namespace DespesaDigital.Code.DAL.dalSetorProduto
{
    public class dalSetorProduto
    {
        public bool InsertSetorProduto(int codigo_setor, int codigo_produto)
        {
            var ssql = "insert into setor_produto VALUES (@codigo_setor, @codigo_produto)";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            {
                cmd.Parameters.AddWithValue("@codigo_setor", codigo_setor);
                cmd.Parameters.AddWithValue("@codigo_produto", codigo_produto);

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

        public bool DeleteSetorProduto(int codigo_produto)
        {
            var ssql = $"delete from setor_produto where codigo_produto = '{codigo_produto}' and codigo_setor in({VariaveisGlobais.setores_concatenados})";

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

        public List<string> GetSetoresVinculado(int codigo_produto)
        {
            var retorno = new List<string>();

            var ssql = $"select s.codigo, sp.codigo_produto, s.nome from setor_produto sp inner join setor s on(sp.codigo_setor = s.codigo) where sp.codigo_produto = '{codigo_produto}'";
            
            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    retorno.Add(dr["nome"].ToString());
                }
                dr.Close();
            }

            return retorno;
        }
    }
}
