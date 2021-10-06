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

            var ssql = $"select * from forma_pagamento where ativo = '{status}' and UPPER(descricao) like UPPER('%{descricao}%')";

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

            var ssql = $"select * from forma_pagamento where ativo = '{status}'";

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
    }
}
