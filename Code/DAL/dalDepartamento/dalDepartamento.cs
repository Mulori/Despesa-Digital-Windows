using DespesaDigital.Code.DTO.dtoDepartamento;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
