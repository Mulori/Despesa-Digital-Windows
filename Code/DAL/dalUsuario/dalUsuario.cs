using DespesaDigital.Code.DTO;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespesaDigital.Code.DAL.dalUsuario
{
    public class dalUsuario
    {
        public dtoUsuario AutenticaUsuario(string email, string senha)
        {
            var dto = new dtoUsuario();

            var ssql = $"select * from usuario where email = '{email}' and senha = md5('{senha}')";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    dto.codigo = int.Parse(dr["codigo"].ToString());
                    dto.nome = dr["nome"].ToString();
                    dto.sobrenome = dr["sobrenome"].ToString();
                    dto.email = dr["email"].ToString();
                    dto.senha = dr["senha"].ToString();
                    dto.ativo = dr["ativo"].ToString();
                    dto.nivel_acesso = int.Parse(dr["nivel_acesso"].ToString());
                    dto.codigo_setor = int.Parse(dr["codigo_setor"].ToString());
                }

                dr.Close();
            }

            return dto;
        }

    }
}
