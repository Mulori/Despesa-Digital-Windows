using DespesaDigital.Code.DTO.dtoDepartamento;
using Npgsql;
using System;
using System.Collections.Generic;

namespace DespesaDigital.Code.DAL.dalDepartamento
{
    public class dalDepartamento
    {
        public List<dtoDepartamento> TodosDepartamentos()
        {
            var list = new List<dtoDepartamento>();

            var ssql = "select * from departamento";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoDepartamento();
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.nome = dr["nome"].ToString();
                    dto.descricao = dr["descricao"].ToString();

                    list.Add(dto);
                }
                dr.Close();
            }

            return list;
        }

        public List<dtoDepartamento> DepartamentoPorSetor(int id)
        {
            var list = new List<dtoDepartamento>();

            var ssql = $"select d.codigo as cod_departamento, d.nome as nome_departamento, d.descricao as descricao_departamento " +
                $"from departamento d inner join setor s on(d.codigo = s.codigo_departamento) where s.codigo = {id}";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoDepartamento();
                    dto.codigo = Convert.ToInt32(dr["cod_departamento"]);
                    dto.nome = dr["nome_departamento"].ToString();
                    dto.descricao = dr["descricao_departamento"].ToString();

                    list.Add(dto);
                }
                dr.Close();
            }

            return list;
        }
    }
}
