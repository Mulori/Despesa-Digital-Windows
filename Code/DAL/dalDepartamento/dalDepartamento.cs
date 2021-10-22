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

        public dtoDepartamento DepartamentoPorCodigo(int id)
        {
            var dto = new dtoDepartamento();

            var ssql = $"select * from departamento where codigo = '{id}'";

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

            return dto;
        }

        public bool Insert(dtoDepartamento dto)
        {
            var ssql = "insert into departamento (nome, descricao) values (@nome, @descricao)";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            {
                cmd.Parameters.AddWithValue("@nome", dto.nome);
                cmd.Parameters.AddWithValue("@descricao", dto.descricao);

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
            var ssql = $"delete from departamento where codigo = '{codigo}'";

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

        public bool Update(dtoDepartamento dto)
        {
            var ssql = "update departamento set nome = @nome, descricao = @descricao where codigo = @codigo";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            { 
                cmd.Parameters.AddWithValue("@codigo", dto.codigo);
                cmd.Parameters.AddWithValue("@nome", dto.nome);
                cmd.Parameters.AddWithValue("@descricao", dto.descricao);

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

        public bool VerificaNomeExistente(string nome)
        {
            var retorno = false;

            var ssql = $"select nome from departamento where nome = '{nome}'";

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

        public string VerificaNomeAtual(int codigo)
        {
            var retorno = "";

            var ssql = $"select nome from departamento where codigo = '{codigo}'";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    retorno = string.IsNullOrEmpty(dr["nome"].ToString()) ? "" : dr["nome"].ToString();
                }
                dr.Close();
            }

            return retorno;
        }
    }
}
