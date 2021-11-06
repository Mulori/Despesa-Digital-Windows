using DespesaDigital.Code.BLL.bllConexao;
using DespesaDigital.Code.DTO.dtoCategoria;
using DespesaDigital.Core;
using Npgsql;
using System;
using System.Collections.Generic;

namespace DespesaDigital.Code.DAL.dalCategoria
{
    public class dalCategoria
    {
        public List<dtoCategoria> ListarTodasCategoriasPorStatus(string status)
        {
            var list = new List<dtoCategoria>();

            //if (!bllConexao.Conectar())
            //{
            //    corePopUp.exibirMensagem("Não foi possivel estabelecer conexão \n com o servidor de banco de dados.", "Sem conexão!");
            //    return list;
            //}

            var ssql = "select c.codigo, c.descricao, c.ativo, d.nome, c.codigo_departamento from categoria c " +
                "inner join departamento d on(c.codigo_departamento = d.codigo)" +
                $" where c.ativo = '{status}' and c.codigo_departamento = '{VariaveisGlobais.codigo_departamento}' order by c.descricao asc";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoCategoria();
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.descricao = dr["descricao"].ToString();

                    switch (dr["ativo"].ToString())
                    {
                        case "A":
                            dto.ativo = "Ativo";
                            break;
                        case "I":
                            dto.ativo = "Inativo";
                            break;
                    }

                    dto.codigo_departamento = Convert.ToInt32(dr["codigo_departamento"]);
                    dto.s_codigo_departamento = dr["nome"].ToString();

                    list.Add(dto);
                }
                dr.Close();
            }

           // bllConexao.Desconectar();

            return list;
        }

        public List<dtoCategoria> ListarTodasCategoriaPorStatusDescricao(string status, string descricao)
        {
            var list = new List<dtoCategoria>();

            //if (!bllConexao.Conectar())
            //{
            //    corePopUp.exibirMensagem("Não foi possivel estabelecer conexão \n com o servidor de banco de dados.", "Sem conexão!");
            //    return list;
            //}

            var ssql = "select c.codigo, c.descricao, c.ativo, d.nome, c.codigo_departamento from categoria c " +
                 "inner join departamento d on(c.codigo_departamento = d.codigo)" +
                 $" where c.ativo = '{status}' and c.codigo_departamento = '{VariaveisGlobais.codigo_departamento}' " +
                 $"and UPPER(c.descricao) like UPPER('%{descricao}%') order by c.descricao asc";
 
            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoCategoria();
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.descricao = dr["descricao"].ToString();

                    switch (dr["ativo"].ToString())
                    {
                        case "A":
                            dto.ativo = "Ativo";
                            break;
                        case "I":
                            dto.ativo = "Inativo";
                            break;
                    }

                    dto.s_codigo_departamento = dr["nome"].ToString();
                    dto.codigo_departamento = Convert.ToInt32(dr["codigo_departamento"]);

                    list.Add(dto);
                }
                dr.Close();
            }

           // bllConexao.Desconectar();

            return list;
        }

        public dtoCategoria CategoriaPorCodigo(int codigo)
        {
            var dto = new dtoCategoria();

            //if (!bllConexao.Conectar())
            //{
            //    corePopUp.exibirMensagem("Não foi possivel estabelecer conexão \n com o servidor de banco de dados.", "Sem conexão!");
            //    return dto;
            //}

            var ssql = "select c.codigo, c.descricao, c.ativo, d.nome, c.codigo_departamento from categoria c " +
               "inner join departamento d on(c.codigo_departamento = d.codigo)" +
               $" where c.codigo = '{codigo}'";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.descricao = dr["descricao"].ToString();

                    switch (dr["ativo"].ToString())
                    {
                        case "A":
                            dto.ativo = "Ativo";
                            break;
                        case "I":
                            dto.ativo = "Inativo";
                            break;
                    }

                    dto.s_codigo_departamento = dr["nome"].ToString();
                    dto.codigo_departamento = Convert.ToInt32(dr["codigo_departamento"]);
                }
                dr.Close();
            }

            //bllConexao.Desconectar();

            return dto;
        }

        public bool Insert(dtoCategoria dto)
        {
            var ssql = "insert into categoria (descricao, ativo, codigo_departamento) values (@descricao, @ativo, @codigo_departamento)";

            //if (!bllConexao.Conectar())
            //{
            //    corePopUp.exibirMensagem("Não foi possivel estabelecer conexão \n com o servidor de banco de dados.", "Sem conexão!");
            //    return false;
            //}

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            {
                cmd.Parameters.AddWithValue("@descricao", dto.descricao);
                cmd.Parameters.AddWithValue("@ativo", dto.ativo);
                cmd.Parameters.AddWithValue("@codigo_departamento", dto.codigo_departamento);

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

        public bool Delete(int codigo)
        {
            var ssql = $"delete from categoria where codigo = '{codigo}'";

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

        public bool Update(dtoCategoria dto)
        {
            var ssql = "update categoria set descricao = @descricao, ativo = @ativo, codigo_departamento = @codigo_departamento where codigo = @codigo";

            //if (!bllConexao.Conectar())
            //{
            //    corePopUp.exibirMensagem("Não foi possivel estabelecer conexão \n com o servidor de banco de dados.", "Sem conexão!");
            //    return false;
            //}

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            {
                cmd.Parameters.AddWithValue("@codigo", dto.codigo);
                cmd.Parameters.AddWithValue("@descricao", dto.descricao);
                cmd.Parameters.AddWithValue("@ativo", dto.ativo);
                cmd.Parameters.AddWithValue("@codigo_departamento", dto.codigo_departamento);

                try
                {
                    cmd.ExecuteNonQuery();
                  //  bllConexao.Desconectar();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool VerificaDescricaoExistente(string descricao)
        {
            var retorno = false;

            //if (!bllConexao.Conectar())
            //{
            //    corePopUp.exibirMensagem("Não foi possivel estabelecer conexão \n com o servidor de banco de dados.", "Sem conexão!");
            //    return false;
            //}

            var ssql = $"select descricao from categoria where codigo_departamento = '{VariaveisGlobais.codigo_departamento}' " +
                 $"and UPPER(descricao) = UPPER('{descricao.Replace("'", string.Empty)}')";

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

        public string VerificaDescricaoAtual(int codigo)
        {
            var retorno = "";

            var ssql = $"select descricao from categoria where codigo = '{codigo}'";

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
                    retorno = string.IsNullOrEmpty(dr["descricao"].ToString()) ? "" : dr["descricao"].ToString();
                }
                dr.Close();
            }

            //bllConexao.Desconectar();

            return retorno;
        }

        public int GetCategoriaOutros()
        {
            int retorno = 0;

            var ssql = $"select codigo from categoria where descricao = 'Outros';";

            //if (!bllConexao.Conectar())
            //{
            //    corePopUp.exibirMensagem("Não foi possivel estabelecer conexão \n com o servidor de banco de dados.", "Sem conexão!");
            //    return 0;
            //}

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    retorno = int.Parse(dr["codigo"].ToString());
                }

                dr.Close();
            }

            //bllConexao.Desconectar();

            return retorno;
        }
    }
}
