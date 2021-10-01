using DespesaDigital.Code.DTO.dtoSetor;
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
                $"from setor s inner join departamento d on(s.codigo_departamento = d.codigo) where s.codigo_departamento = '{departamento}'";

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

        public List<dtoSetor> SetorPorCodigo (int setor)
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
    }
}
