using DespesaDigital.Code.DTO;
using DespesaDigital.Core;
using Npgsql;
using System;
using System.Collections.Generic;

namespace DespesaDigital.Code.DAL.dalUsuario
{
    public class dalUsuario
    {
        public bool VerificaEmailExistente(string email)
        {
            var retorno = false;

            var ssql = $"select email from usuario where UPPER(email) = UPPER('{email}')";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    retorno = true;
                }
                dr.Close();
            }

            return retorno;
        }

        public dtoUsuario AutenticaUsuario(string email, string senha)
        {
            var dto = new dtoUsuario();

            var ssql = $"select * from usuario where email = '{email}' and senha = md5('{senha}') and ativo = 'A'";

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

            if (VariaveisGlobais.nivel_acesso == 2)
            {
                ssql += $" and u.codigo_setor = '{VariaveisGlobais.codigo_setor}'";
            }
            else if(VariaveisGlobais.nivel_acesso == 3)
            {
                ssql += $" and u.codigo_setor in({VariaveisGlobais.setores_concatenados})";
            }

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
                            dto.ativo = "Ativo";
                            break;
                        case "P":
                            dto.ativo = "Pendente";
                            break;
                        case "I":
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

        public List<dtoUsuario> ListarUsuariosPorNome(string status, string nome)
        {
            var ssql = $"select u.codigo, u.nome as usuario, u.sobrenome, u.email, u.nivel_acesso, u.ativo, s.nome as setor " +
                $"from usuario u inner join setor s on(u.codigo_setor = s.codigo) where u.ativo = '{status}' and UPPER(u.nome) like UPPER('%{nome}%')";

            if (VariaveisGlobais.nivel_acesso == 2)
            {
                ssql += $" and u.codigo_setor = '{VariaveisGlobais.codigo_setor}'";
            }
            else if (VariaveisGlobais.nivel_acesso == 3)
            {
                ssql += $" and u.codigo_setor in ({VariaveisGlobais.setores_concatenados})";
            }

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
                            dto.ativo = "Ativo";
                            break;
                        case "P":
                            dto.ativo = "Pendente";
                            break;
                        case "I":
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

        public dtoUsuario UsuarioPorCodigo(int codigo)
        {
            var ssql = $"select u.codigo, u.nome as usuario, u.sobrenome, u.email, u.nivel_acesso, u.ativo, s.nome as setor, d.nome as departamento, u.senha " +
                $"from usuario u inner join setor s on(u.codigo_setor = s.codigo) inner join departamento d on(d.codigo = s.codigo_departamento) where u.codigo = '{codigo}'";

            if (VariaveisGlobais.nivel_acesso == 2)
            {
                ssql += $" and u.codigo_setor = '{VariaveisGlobais.codigo_setor}'";
            }
            else if (VariaveisGlobais.nivel_acesso == 3)
            {
                ssql += $" and u.codigo_setor in ({VariaveisGlobais.setores_concatenados})";
            }

            var dto = new dtoUsuario();

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
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
                            dto.ativo = "Ativo";
                            break;
                        case "P":
                            dto.ativo = "Pendente";
                            break;
                        case "I":
                            dto.ativo = "Inativo";
                            break;
                    }

                    dto.senha = dr["senha"].ToString();
                    dto.nome_setor = dr["setor"].ToString();
                    dto.nome_departamento = dr["departamento"].ToString();
                }
                dr.Close();
            }
            return dto;
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
                catch
                {
                    return false;
                }
            }
        }

        public bool UpdateAceitar(int codigo_usuario, int nivel)
        {
            var ssql = $"update usuario set ativo = 'A', nivel_acesso = '{nivel}' where codigo = '{codigo_usuario}'";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
            }

            ssql = $"update usuario_aprovacao set motivo = 'Usuário aprovado por: {VariaveisGlobais.codigo_usuario} {VariaveisGlobais.nome_usuario}', aprovado = 'S' where codigo_usuario = '{codigo_usuario}'";
            
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

        public int NovoUsuario(dtoUsuario dto)
        {
            var retorno = 0;

            var ssql = $"select NovoUsuario('{dto.nome}', '{dto.sobrenome}', '{dto.email}', '{dto.senha}', {dto.codigo_setor});";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    retorno = int.Parse(dr["NovoUsuario"].ToString());
                }

                dr.Close();
            }

            return retorno;
        }

        public List<dtoUsuario> ListarUsuariosPorSetor(int codigo_setor)
        {
            var ssql = $"select u.codigo, u.nome as usuario, u.sobrenome, u.email, u.nivel_acesso, u.ativo, s.nome as setor " +
                $"from usuario u inner join setor s on(u.codigo_setor = s.codigo) where u.codigo_setor = '{codigo_setor}'";

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
                            dto.ativo = "Ativo";
                            break;
                        case "P":
                            dto.ativo = "Pendente";
                            break;
                        case "I":
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

        public bool UpdateEmail(int codigo_usuario, string email)
        {
            var ssql = $"update usuario set email = '{email}' where codigo = '{codigo_usuario}'";

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

        public bool UpdateSenha(int codigo_usuario, string senha)
        {
            var ssql = $"update usuario set senha = md5('{senha}') where codigo = '{codigo_usuario}'";

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

        public int DashboardTotalUsuario()
        {
            int total = 0;

            var ssql = "select count(*) as quantidade from usuario u " +
                " inner join setor s on(u.codigo_setor = s.codigo)" +
                " inner join departamento dp on(s.codigo_departamento = dp.codigo)" +
                $" where dp.codigo = '{VariaveisGlobais.codigo_departamento}'";

            if (VariaveisGlobais.nivel_acesso < 3)
            {
                ssql += $" and u.codigo_setor = '{VariaveisGlobais.codigo_setor}'";
            }

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    total = string.IsNullOrEmpty(dr["quantidade"].ToString()) ? 0 : Convert.ToInt32(dr["quantidade"]);
                }
                dr.Close();
            }

            return total;
        }
    }
}
