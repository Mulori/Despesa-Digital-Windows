using DespesaDigital.Code.DTO.dtoLogSistema;
using DespesaDigital.Core;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespesaDigital.Code.DAL.dalLogSistema
{
    public class dalLogSistema
    {
        public bool Insert(string descricao)
        {
            var ssql = "insert into log_sistema (plataforma, email_usuario, descricao, data_hora) VALUES " +
                $"('Desktop|{Environment.MachineName}', '{VariaveisGlobais.email_usuario}', '{descricao}', '{DateTime.Now}')";

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

        public List<dtoLogSistema> SelecionarLogs(DateTime inicio, DateTime fim, string email)
        {
            var list = new List<dtoLogSistema>();

            var ssql = "select * from log_sistema" +
                $" where data_hora between '{inicio.ToString("yyyy-MM-dd")} 00:00:00' and '{fim.ToString("yyyy-MM-dd")} 23:59:59'";

            if(email.Length > 0)
            {
                ssql += $" and email_usuario = '{email}'";
            }

            ssql += $" order by codigo asc";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoLogSistema();
                    dto.codigo = Convert.ToInt64(dr["codigo"]);
                    dto.plataforma = dr["plataforma"].ToString();
                    dto.email_usuario = dr["email_usuario"].ToString();
                    dto.descricao = dr["descricao"].ToString();
                    dto.data_hora = Convert.ToDateTime(dr["data_hora"]).ToString("dd/MM/yyyy HH:mm:ss");
                    list.Add(dto);
                }
                dr.Close();
            }
            return list;
        }
    }
}
