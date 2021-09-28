using DespesaDigital.Code.DTO.dtoSetor;
using Npgsql;
using System;
using System.Collections.Generic;

namespace DespesaDigital.Code.DAL.dalSetor
{
    public class dalSetor
    {
        public List<dtoSetor> TodosSetoresPorSetor(string departamento)
        {
            var list = new List<dtoSetor>();

            var ssql = $"select * from setor where codigo_departamento in (select codigo from departamento where nome = '{departamento}')";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoSetor();
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.nome = dr["nome"].ToString();
                    dto.codigo_departamento = Convert.ToInt32(dr["codigo_departamento"]);

                    list.Add(dto);
                }
                dr.Close();
            }

            return list;
        }
    }
}
