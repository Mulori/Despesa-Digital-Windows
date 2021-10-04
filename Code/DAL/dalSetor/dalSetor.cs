using DespesaDigital.Code.DTO.dtoSetor;
using DespesaDigital.Core;
using Npgsql;
using System;
using System.Collections.Generic;

namespace DespesaDigital.Code.DAL.dalSetor
{
    public class dalSetor
    {
        public List<dtoSetor> TodosSetoresPorCodigoDepartamento(int departamento)
        {
            var list = new List<dtoSetor>();

            var ssql = $"select s.codigo as cod_setor, s.nome as nome_setor, d.codigo as cod_departamento, d.nome as nome_departamento " +
                $"from setor s inner join departamento d on(s.codigo_departamento = d.codigo) where s.codigo_departamento = '{departamento}' order by s.nome asc";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoSetor();
                    dto.codigo = Convert.ToInt32(dr["cod_setor"]);
                    dto.nome = dr["nome_setor"].ToString();
                    dto.codigo_departamento = Convert.ToInt32(dr["cod_departamento"]);
                    dto.s_departamento = dr["nome_departamento"].ToString();

                    list.Add(dto);
                }
                dr.Close();
            }

            return list;
        }

        public List<dtoSetor> ListSetorPorCodigo (int setor)
        {
            var list = new List<dtoSetor>();

            var ssql = $"select s.codigo as cod_setor, s.nome as nome_setor, d.codigo as cod_departamento, d.nome as nome_departamento " +
                $"from setor s inner join departamento d on(s.codigo_departamento = d.codigo) where s.codigo = '{setor}'";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoSetor();
                    dto.codigo = Convert.ToInt32(dr["cod_setor"]);
                    dto.nome = dr["nome_setor"].ToString();
                    dto.codigo_departamento = Convert.ToInt32(dr["cod_departamento"]);
                    dto.s_departamento = dr["nome_departamento"].ToString();

                    list.Add(dto);
                }
                dr.Close();
            }

            return list;
        }

        public List<dtoSetor> ListSetorPorNome(string nome)
        {
            var list = new List<dtoSetor>();

            var ssql = $"select s.codigo as cod_setor, s.nome as nome_setor, d.codigo as cod_departamento, d.nome as nome_departamento " +
                $"from setor s inner join departamento d on(s.codigo_departamento = d.codigo) where UPPER(s.nome) like UPPER('%{nome}%') and s.codigo_departamento = '{VariaveisGlobais.codigo_departamento}' order by s.nome asc";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoSetor();
                    dto.codigo = Convert.ToInt32(dr["cod_setor"]);
                    dto.nome = dr["nome_setor"].ToString();
                    dto.codigo_departamento = Convert.ToInt32(dr["cod_departamento"]);
                    dto.s_departamento = dr["nome_departamento"].ToString();

                    list.Add(dto);
                }
                dr.Close();
            }

            return list;
        }

        public int CodigoDepartamentoPorCodigoSetor(int setor)
        {
            var codigo = 0;

            var ssql = $"select codigo_departamento from setor where codigo = '{setor}'";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    codigo = Convert.ToInt32(dr["codigo_departamento"]);
                }
                dr.Close();
            }

            return codigo;
        }

        public string CodigoSetoresContatenado(int departamento)
        {
            var retorno = "";

            var ssql = $"select codigo from setor where codigo_departamento = '{departamento}'";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (retorno.Length > 0)
                    {
                        retorno += "," + dr["codigo"].ToString();
                    }
                    else
                    {
                        retorno += dr["codigo"].ToString();
                    }
                }
                dr.Close();
            }

            return retorno;
        }

        public dtoSetor SetorPorCodigo(int id)
        {
            var dto = new dtoSetor();

            var ssql = $"select s.codigo, s.nome as setor, s.codigo_departamento, d.nome as departamento from setor s " +
                $"inner join departamento d on(s.codigo_departamento = d.codigo) where s.codigo = '{id}'";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.nome = dr["setor"].ToString();
                    dto.s_departamento = dr["departamento"].ToString();
                    dto.codigo_departamento = Convert.ToInt32(dr["codigo_departamento"]);
                }
                dr.Close();
            }

            return dto;
        }

        public bool Insert(dtoSetor dto)
        {
            var ssql = "insert into setor (nome, codigo_departamento) values (@nome, @codigo_departamento)";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            {
                cmd.Parameters.AddWithValue("@nome", dto.nome);
                cmd.Parameters.AddWithValue("@codigo_departamento", dto.codigo_departamento);

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
            var ssql = $"delete from setor where codigo = '{codigo}'";

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

        public bool Update(dtoSetor dto)
        {
            var ssql = "update setor set nome = @nome, codigo_departamento = @codigo_departamento where codigo = @codigo";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            {
                cmd.Parameters.AddWithValue("@codigo", dto.codigo);
                cmd.Parameters.AddWithValue("@nome", dto.nome);
                cmd.Parameters.AddWithValue("@codigo_departamento", dto.codigo_departamento);

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

            var ssql = $"select nome from setor where nome = '{nome}'";

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
    }
}
