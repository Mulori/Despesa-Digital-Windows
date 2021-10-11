using DespesaDigital.Code.DTO.dtoFormaPagamento;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespesaDigital.Code.DAL.dalFormaPagamento
{
    public class dalFormaPagamento
    {
        public List<dtoFormaPagamento> ListarTodasFormasPagamentoPorStatusDescricao(string status, string descricao)
        {
            var list = new List<dtoFormaPagamento>();

            var ssql = $"select * from forma_pagamento where ativo = '{status}' and UPPER(descricao) like UPPER('%{descricao}%') order by descricao asc";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoFormaPagamento();
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.descricao = dr["descricao"].ToString();
                    dto.ativo = dr["ativo"].ToString() == "A" ? "Ativo" : "Inativo";

                    list.Add(dto);
                }
                dr.Close();
            }

            return list;
        }

        public List<dtoFormaPagamento> ListarTodasFormasPagamentoPorStatus(string status)
        {
            var list = new List<dtoFormaPagamento>();

            var ssql = $"select * from forma_pagamento where ativo = '{status}' order by descricao asc";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoFormaPagamento();
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.descricao = dr["descricao"].ToString();
                    dto.ativo = dr["ativo"].ToString() == "A" ? "Ativo" : "Inativo";

                    list.Add(dto);
                }
                dr.Close();
            }

            return list;
        }

        public dtoFormaPagamento FormaPagamentoPorCodigo(int codigo)
        {
            var dto = new dtoFormaPagamento();

            var ssql = $"select * from forma_pagamento where codigo = '{codigo}'";

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


        public bool Insert(dtoFormaPagamento dto)
        {
            var ssql = "insert into forma_pagamento (descricao, ativo) values (@descricao, @ativo)";

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
            var ssql = $"delete from forma_pagamento where codigo = '{codigo}'";

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

        public bool Update(dtoFormaPagamento dto)
        {
            var ssql = "update forma_pagamento set descricao = @descricao, ativo = @ativo where codigo = @codigo";

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

            var ssql = $"select descricao from forma_pagamento where descricao = '{descricao}'";

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

            var ssql = $"select descricao from forma_pagamento where codigo = '{codigo}'";

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
