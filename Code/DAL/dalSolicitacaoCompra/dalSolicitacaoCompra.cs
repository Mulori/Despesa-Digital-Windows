using DespesaDigital.Code.DTO.dtoSolicitacaoCompra;
using DespesaDigital.Core;
using Npgsql;
using System;
using System.Collections.Generic;

namespace DespesaDigital.Code.DAL.dalSolicitacaoCompra
{
    public class dalSolicitacaoCompra
    {
        public List<dtoSolicitacaoCompra> ListarTodasSolicitacaoPorStatusData(string status, DateTime inicial, DateTime final)
        {
            var list = new List<dtoSolicitacaoCompra>();

            var ssql = "select so.codigo, so.motivo, so.data_solicitacao, so.valor, so.status, p.descricao, se.nome from solicitacao so";
            ssql += " inner join produto p on(so.codigo_produto = p.codigo)";
            ssql += " left join setor se on(so.codigo_setor = se.codigo)";
            ssql += $" where se.codigo_departamento = '{VariaveisGlobais.codigo_departamento}'";
            ssql += $" and so.data_solicitacao between '{inicial.ToString("yyyy-MM-dd") + " 00:00:00.000"}' and '{final.ToString("yyyy-MM-dd") + " 23:59:59.000"}'";

            if (VariaveisGlobais.nivel_acesso == 2)
            {
                ssql += $" and so.codigo_setor = '{VariaveisGlobais.codigo_setor}'";
            }

            ssql += $" and so.status = '{status}'";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoSolicitacaoCompra();
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.motivo = dr["motivo"].ToString();
                    dto.data_solicitacao = Convert.ToDateTime(dr["data_solicitacao"]);
                    dto.valor = Convert.ToDecimal(dr["valor"]);
                    string s_valor = Convert.ToDouble(dr["valor"]).ToString("N2");
                    dto.s_valor = s_valor;

                    switch (dr["status"].ToString())
                    {
                        case "A":
                            dto.status = "Aprovado";
                            break;
                        case "P":
                            dto.status = "Pendente";
                            break;
                        case "R":
                            dto.status = "Rejeitado";
                            break;
                    }

                    dto.s_codigo_produto = dr["descricao"].ToString();
                    dto.s_codigo_setor = dr["nome"].ToString();

                    list.Add(dto);
                }
                dr.Close();
            }

            return list;
        }

        public List<dtoSolicitacaoCompra> ListarTodasSolicitacaoPorStatusSetor(string status, int codigo_setor)
        {
            var list = new List<dtoSolicitacaoCompra>();

            var ssql = "select so.codigo, so.motivo, so.data_solicitacao, so.valor, so.status, p.descricao, se.nome from solicitacao so";
            ssql += " inner join produto p on(so.codigo_produto = p.codigo)";
            ssql += " left join setor se on(so.codigo_setor = se.codigo)";
            ssql += $" where se.codigo_departamento = '{VariaveisGlobais.codigo_departamento}'";
            ssql += $" and so.codigo_setor = '{codigo_setor}'";
            ssql += $" and so.status = '{status}'";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoSolicitacaoCompra();
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.motivo = dr["motivo"].ToString();
                    dto.data_solicitacao = Convert.ToDateTime(dr["data_solicitacao"]);
                    dto.valor = Convert.ToDecimal(dr["valor"]);
                    string s_valor = Convert.ToDouble(dr["valor"]).ToString("N2");
                    dto.s_valor = s_valor;

                    switch (dr["status"].ToString())
                    {
                        case "A":
                            dto.status = "Aprovado";
                            break;
                        case "P":
                            dto.status = "Pendente";
                            break;
                        case "R":
                            dto.status = "Rejeitado";
                            break;
                    }

                    dto.s_codigo_produto = dr["descricao"].ToString();
                    dto.s_codigo_setor = dr["nome"].ToString();

                    list.Add(dto);
                }
                dr.Close();
            }

            return list;
        }

        public List<dtoSolicitacaoCompra> ListarTodasSolicitacaoPorStatus(string status)
        {
            var list = new List<dtoSolicitacaoCompra>();

            var ssql = "select so.codigo, so.motivo, so.data_solicitacao, so.valor, so.status, p.descricao, se.nome from solicitacao so";
            ssql += " inner join produto p on(so.codigo_produto = p.codigo)";
            ssql += " left join setor se on(so.codigo_setor = se.codigo)";
            ssql += $" where se.codigo_departamento = '{VariaveisGlobais.codigo_departamento}'";

            if (VariaveisGlobais.nivel_acesso == 2)
            {
                ssql += $" and so.codigo_setor = '{VariaveisGlobais.codigo_setor}'";
            }

            switch (status)
            {
                case "A":
                    ssql += $" and so.status = 'A'";
                    break;
                case "P":
                    ssql += $" and so.status = 'P'";
                    break;
                case "R":
                    ssql += $" and so.status = 'R'";
                    break;
            }

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoSolicitacaoCompra();
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.motivo = dr["motivo"].ToString();
                    dto.data_solicitacao = Convert.ToDateTime(dr["data_solicitacao"]);
                    dto.valor = Convert.ToDecimal(dr["valor"]);
                    string s_valor = Convert.ToDouble(dr["valor"]).ToString("N2");
                    dto.s_valor = s_valor;

                    switch (dr["status"].ToString())
                    {
                        case "A":
                            dto.status = "Aprovado";
                            break;
                        case "P":
                            dto.status = "Pendente";
                            break;
                        case "R":
                            dto.status = "Rejeitado";
                            break;
                    }

                    dto.s_codigo_produto = dr["descricao"].ToString();
                    dto.s_codigo_setor = dr["nome"].ToString();

                    list.Add(dto);
                }
                dr.Close();
            }

            return list;
        }

        public dtoSolicitacaoCompra SolicitacaoPorCodigo(long codigo)
        {
            var dto = new dtoSolicitacaoCompra();

            var ssql = "select so.codigo, so.motivo, so.data_solicitacao, so.valor, so.status, p.descricao, se.nome, u.nome as nome_usuario, u.sobrenome as sobrenome_usuario from solicitacao so";
            ssql += " inner join produto p on(so.codigo_produto = p.codigo)";
            ssql += " left join setor se on(so.codigo_setor = se.codigo)";
            ssql += " left join usuario_solicitacao us on(us.codigo_solicitacao = so.codigo)";
            ssql += " left join usuario u on(u.codigo = us.codigo_usuario)";
            ssql += $" where so.codigo = '{codigo}'";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.motivo = dr["motivo"].ToString();
                    dto.data_solicitacao = Convert.ToDateTime(dr["data_solicitacao"]);
                    dto.valor = Convert.ToDecimal(dr["valor"]);
                    string s_valor = Convert.ToDouble(dr["valor"]).ToString("N2");
                    dto.s_valor = s_valor;

                    switch (dr["status"].ToString())
                    {
                        case "A":
                            dto.status = "Aprovado";
                            break;
                        case "P":
                            dto.status = "Pendente";
                            break;
                        case "R":
                            dto.status = "Rejeitado";
                            break;
                    }

                    dto.s_codigo_produto = dr["descricao"].ToString();
                    dto.s_codigo_setor = dr["nome"].ToString();
                    dto.usuario = dr["nome_usuario"].ToString() + " " +dr["sobrenome_usuario"].ToString();
                }
                dr.Close();
            }

            return dto;
        }

        public bool UpdateStatus(long codigo_solicitacao, string status)
        {
            var ssql = "update solicitacao set status = @status where codigo = @codigo";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            {
                cmd.Parameters.AddWithValue("@codigo", codigo_solicitacao);
                cmd.Parameters.AddWithValue("@status", status);

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

        public bool UsuarioAprovouRejeitou(long codigo_solicitacao, int codigo_gestor)
        {
            var ssql = $"insert into gestor_solicitacao VALUES ('{codigo_solicitacao}', '{codigo_gestor}')";

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
    }
}
