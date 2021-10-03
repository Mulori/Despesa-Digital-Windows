using DespesaDigital.Code.DTO.dtoCategoria;
using DespesaDigital.Core;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespesaDigital.Code.DAL.dalCategoria
{
    public class dalCategoria
    {
        public List<dtoCategoria> ListarTodasCategoriasPorStatus(string status)
        {
            var list = new List<dtoCategoria>();

            var ssql = "select c.codigo, c.descricao, c.ativo, d.nome, c.codigo_departamento from categoria c " +
                "inner join departamento d on(c.codigo_departamento = d.codigo)" +
                $" where c.ativo = '{status}' and c.codigo_departamento = '{VariaveisGlobais.codigo_departamento}' order by c.descricao asc";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoCategoria();
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.descricao = dr["descricao"].ToString();

                    switch (dr["ativo"].ToString())
                    {
                        case "A":
                            dto.ativo = "Ativo";
                            break;
                        case "I":
                            dto.ativo = "Inativo";
                            break;
                    }

                    dto.codigo_departamento = Convert.ToInt32(dr["codigo_departamento"]);
                    dto.s_codigo_departamento = dr["nome"].ToString();

                    list.Add(dto);
                }
                dr.Close();
            }

            return list;
        }
    }
}
