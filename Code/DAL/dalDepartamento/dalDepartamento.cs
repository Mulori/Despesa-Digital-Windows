using DespesaDigital.Code.BLL.bllConexao;
using DespesaDigital.Code.DTO.dtoDepartamento;
using DespesaDigital.Core;
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

            //if (!bllConexao.Conectar())
            //{
            //    corePopUp.exibirMensagem("Não foi possivel estabelecer conexão \n com o servidor de banco de dados.", "Sem conexão!");
            //    return list;
            //}

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
            //bllConexao.Desconectar();
            return list;
        }

        public List<dtoDepartamento> DepartamentoPorSetor(int id)
        {
            var list = new List<dtoDepartamento>();

            var ssql = $"select d.codigo as cod_departamento, d.nome as nome_departamento, d.descricao as descricao_departamento " +
                $"from departamento d inner join setor s on(d.codigo = s.codigo_departamento) where s.codigo = {id}";

            //if (!bllConexao.Conectar())
            //{
            //    corePopUp.exibirMensagem("Não foi possivel estabelecer conexão \n com o servidor de banco de dados.", "Sem conexão!");
            //    return list;
            //}

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
            //bllConexao.Desconectar();
            return list;
        }

        public dtoDepartamento DepartamentoPorCodigo(int id)
        {
            var dto = new dtoDepartamento();

            var ssql = $"select * from departamento where codigo = '{id}'";

            //if (!bllConexao.Conectar())
            //{
            //    corePopUp.exibirMensagem("Não foi possivel estabelecer conexão \n com o servidor de banco de dados.", "Sem conexão!");
            //    return dto;
            //}

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.nome = dr["nome"].ToString();
                    dto.descricao = dr["descricao"].ToString();
                }
                dr.Close();
            }
            //bllConexao.Desconectar();
            return dto;
        }

        public bool Insert(dtoDepartamento dto)
        {
            var ssql = "insert into departamento (nome, descricao) values (@nome, @descricao)";

            //if (!bllConexao.Conectar())
            //{
            //    corePopUp.exibirMensagem("Não foi possivel estabelecer conexão \n com o servidor de banco de dados.", "Sem conexão!");
            //    return false;
            //}

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            {
                cmd.Parameters.AddWithValue("@nome", dto.nome);
                cmd.Parameters.AddWithValue("@descricao", dto.descricao);

                try
                {
                    cmd.ExecuteNonQuery();
                    //bllConexao.Desconectar();
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
            var ssql = $"delete from departamento where codigo = '{codigo}'";

            //if (!bllConexao.Conectar())
            //{
            //    corePopUp.exibirMensagem("Não foi possivel estabelecer conexão \n com o servidor de banco de dados.", "Sem conexão!");
            //    return false;
            //}

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                   // bllConexao.Desconectar();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool Update(dtoDepartamento dto)
        {
            var ssql = "update departamento set nome = @nome, descricao = @descricao where codigo = @codigo";

            //if (!bllConexao.Conectar())
            //{
            //    corePopUp.exibirMensagem("Não foi possivel estabelecer conexão \n com o servidor de banco de dados.", "Sem conexão!");
            //    return false;
            //}

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            { 
                cmd.Parameters.AddWithValue("@codigo", dto.codigo);
                cmd.Parameters.AddWithValue("@nome", dto.nome);
                cmd.Parameters.AddWithValue("@descricao", dto.descricao);

                try
                {
                    cmd.ExecuteNonQuery();
                    //bllConexao.Desconectar();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool VerificaNomeExistente(string nome)
        {
            var retorno = false;

            var ssql = $"select nome from departamento where UPPER(nome) = UPPER('{nome}')";

            //if (!bllConexao.Conectar())
            //{
            //    corePopUp.exibirMensagem("Não foi possivel estabelecer conexão \n com o servidor de banco de dados.", "Sem conexão!");
            //    return false;
            //}

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    retorno = true;
                }
                dr.Close();
            }
            //bllConexao.Desconectar();
            return retorno;
        }

        public string VerificaNomeAtual(int codigo)
        {
            var retorno = "";

            var ssql = $"select nome from departamento where codigo = '{codigo}'";

            //if (!bllConexao.Conectar())
            //{
            //    corePopUp.exibirMensagem("Não foi possivel estabelecer conexão \n com o servidor de banco de dados.", "Sem conexão!");
            //    return "";
            //}

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    retorno = string.IsNullOrEmpty(dr["nome"].ToString()) ? "" : dr["nome"].ToString();
                }
                dr.Close();
            }
            //bllConexao.Desconectar();
            return retorno;
        }
    }
}
