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

        public List<dtoUsuario> ListarUsuariosPorStatus(string status)
        {
            var ssql = $"select u.codigo, u.nome as usuario, u.sobrenome, u.email, u.nivel_acesso, u.ativo, s.nome as setor " +
                $"from usuario u inner join setor s on(u.codigo_setor = s.codigo) where u.ativo = '{status}'";

            var list = new List<dtoUsuario>();

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoUsuario();
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.nome = dr["usuario"].ToString();
                    dto.sobrenome = dr["sobrenome"].ToString();
                    dto.email = dr["email"].ToString();

                    switch (dr["nivel_acesso"].ToString())
                    {
                        case "1":
                            dto.s_nivel_acesso = "Tecnico";
                            break;
                        case "2":
                            dto.s_nivel_acesso = "Supervisor";
                            break;
                        case "3":
                            dto.s_nivel_acesso = "Gestor";
                            break;
                    }

                    switch (dr["ativo"].ToString())
                    {
                        case "A":
                            dto.salvar = "Salvar";
                            dto.excluir = "Excluir";

                            dto.ativo = "Ativo";
                            break;
                        case "P":
                            dto.salvar = "Aceitar";
                            dto.excluir = "Recusar";

                            dto.ativo = "Pendente";
                            break;
                        case "I":
                            dto.salvar = "Salvar";
                            dto.excluir = "Excluir";

                            dto.ativo = "Inativo";
                            break;
                    }

                    dto.salvar = "Salvar";
                    dto.excluir = "Excluir";
                    dto.nome_setor = dr["setor"].ToString();

                    list.Add(dto);
                }
                dr.Close();
            }
            return list;
        }

        public List<dtoUsuario> ListarUsuariosPorNome(string status, string nome)
        {
            var ssql = $"select u.codigo, u.nome as usuario, u.sobrenome, u.email, u.nivel_acesso, u.ativo, s.nome as setor " +
                $"from usuario u inner join setor s on(u.codigo_setor = s.codigo) where u.ativo = '{status}' and UPPER(u.nome) like UPPER('%{nome}%')";

            var list = new List<dtoUsuario>();

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoUsuario();
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.nome = dr["usuario"].ToString();
                    dto.sobrenome = dr["sobrenome"].ToString();
                    dto.email = dr["email"].ToString();

                    switch (dr["nivel_acesso"].ToString())
                    {
                        case "1":
                            dto.s_nivel_acesso = "Tecnico";
                            break;
                        case "2":
                            dto.s_nivel_acesso = "Supervisor";
                            break;
                        case "3":
                            dto.s_nivel_acesso = "Gestor";
                            break;
                    }

                    switch (dr["ativo"].ToString())
                    {
                        case "A":
                            dto.salvar = "Salvar";
                            dto.excluir = "Excluir";

                            dto.ativo = "Ativo";
                            break;
                        case "P":
                            dto.salvar = "Aceitar";
                            dto.excluir = "Recusar";

                            dto.ativo = "Pendente";
                            break;
                        case "I":
                            dto.salvar = "Salvar";
                            dto.excluir = "Excluir";

                            dto.ativo = "Inativo";
                            break;
                    }
                    
                    dto.nome_setor = dr["setor"].ToString();

                    list.Add(dto);
                }
                dr.Close();
            }
            return list;
        }

        public bool Update(dtoUsuario dto)
        {
            var ssql = "update usuario set nome = @nome, sobrenome = @sobrenome, ativo = @ativo, nivel_acesso = @nivel_acesso," +
                " codigo_setor = @codigo_setor where codigo = @codigo";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            {
                cmd.Parameters.AddWithValue("@nome", dto.nome);
                cmd.Parameters.AddWithValue("@sobrenome", dto.sobrenome);
                cmd.Parameters.AddWithValue("@ativo", dto.ativo);
                cmd.Parameters.AddWithValue("@nivel_acesso", dto.nivel_acesso);
                cmd.Parameters.AddWithValue("@codigo_setor", dto.codigo_setor);
                cmd.Parameters.AddWithValue("@codigo", dto.codigo);

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

        public bool Delete(int codigo)
        {
            var ssql = "delete from usuario where codigo = @codigo";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            {
                cmd.Parameters.AddWithValue("@codigo", codigo);

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
    }
}
