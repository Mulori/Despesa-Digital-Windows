using DespesaDigital.Code.DTO.dtoTipoDespesa;
using Npgsql;
using System;
using System.Collections.Generic;

namespace DespesaDigital.Code.DAL.dalTipoDespesa
{
    public class dalTipoDespesa
    {
        public List<dtoTipoDespesa> ListarTodosTipoDespesaPorStatusDescricao(string status, string descricao)
        {
            var list = new List<dtoTipoDespesa>();

            var ssql = $"select * from tipodespesa where ativo = '{status}' and UPPER(descricao) like UPPER('%{descricao}%') order by descricao asc";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoTipoDespesa();
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.descricao = dr["descricao"].ToString();
                    dto.ativo = dr["ativo"].ToString() == "A" ? "Ativo" : "Inativo";

                    list.Add(dto);
                }
                dr.Close();
            }

            return list;
        }

        public List<dtoTipoDespesa> ListarTodasTipoDespesaPorStatus(string status)
        {
            var list = new List<dtoTipoDespesa>();

            var ssql = $"select * from tipodespesa where ativo = '{status}' order by descricao asc";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoTipoDespesa();
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.descricao = dr["descricao"].ToString();
                    dto.ativo = dr["ativo"].ToString() == "A" ? "Ativo" : "Inativo";

                    list.Add(dto);
                }
                dr.Close();
            }

            return list;
        }

        public dtoTipoDespesa TipoDespesaPorCodigo(int codigo)
        {
            var dto = new dtoTipoDespesa();

            var ssql = $"select * from tipodespesa where codigo = '{codigo}'";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.descricao = dr["descricao"].ToString();
                    dto.ativo = dr["ativo"].ToString() == "A" ? "Ativo" : "Inativo";
                }
                dr.Close();
            }

            return dto;
        }


        public bool Insert(dtoTipoDespesa dto)
        {
            var ssql = "insert into tipodespesa (descricao, ativo) values (@descricao, @ativo)";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            {
                cmd.Parameters.AddWithValue("@descricao", dto.descricao);
                cmd.Parameters.AddWithValue("@ativo", dto.ativo);

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
            var ssql = $"delete from tipodespesa where codigo = '{codigo}'";

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

        public bool Update(dtoTipoDespesa dto)
        {
            var ssql = "update tipodespesa set descricao = @descricao, ativo = @ativo where codigo = @codigo";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            {
                cmd.Parameters.AddWithValue("@codigo", dto.codigo);
                cmd.Parameters.AddWithValue("@descricao", dto.descricao);
                cmd.Parameters.AddWithValue("@ativo", dto.ativo);

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

        public bool VerificaDescricaoExistente(string descricao)
        {
            var retorno = false;

            var ssql = $"select descricao from tipodespesa where descricao = '{descricao}'";

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

        public string VerificaDescricaoAtual(int codigo)
        {
            var retorno = "";

            var ssql = $"select descricao from tipodespesa where codigo = '{codigo}'";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    retorno = string.IsNullOrEmpty(dr["descricao"].ToString()) ? "" : dr["descricao"].ToString();
                }
                dr.Close();
            }

            return retorno;
        }
    }
}
