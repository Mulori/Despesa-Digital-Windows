using DespesaDigital.Core;
using Npgsql;
using System;
using System.Collections.Generic;
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
                catch(Exception e)
                {
                    return false;
                }
            }
        }
    }
}
