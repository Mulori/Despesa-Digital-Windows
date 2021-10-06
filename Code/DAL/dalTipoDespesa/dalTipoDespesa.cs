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

            var ssql = $"select * from tipodespesa where ativo = '{status}' and UPPER(descricao) like UPPER('%{descricao}%')";

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

            var ssql = $"select * from tipodespesa where ativo = '{status}'";

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
    }
}
