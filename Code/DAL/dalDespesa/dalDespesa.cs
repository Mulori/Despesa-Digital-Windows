using DespesaDigital.Code.DTO.dtoDashboard;
using DespesaDigital.Code.DTO.dtoDespesa;
using DespesaDigital.Core;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace DespesaDigital.Code.DAL.dalDespesa
{
    public class dalDespesa
    {
        public dtoDespesa DespesaPorCodigo(long codigo_despesa)
        {
            var dto = new dtoDespesa();

            var ssql = "select d.codigo, d.data_hora_emissao, d.valor, d.descricao, tp.descricao as tipo_despesa, s.nome as setor, fp.descricao as forma_pagamento, u.nome, u.sobrenome, d.descricao as motivo, ";
            ssql += " d.codigo_tipo_despesa, d.codigo_forma_pagamento, d.codigo_setor, d.codigo_setor, d.codigo_usuario from despesa d";
            ssql += " inner join tipodespesa tp on(d.codigo_tipo_despesa = tp.codigo) ";
            ssql += " inner join setor s on(d.codigo_setor = s.codigo) ";
            ssql += " inner join forma_pagamento fp ON (fp.codigo = d.codigo_forma_pagamento)";
            ssql += " inner join usuario u on(d.codigo_usuario = u.codigo)";
            ssql += $" where d.codigo = '{codigo_despesa}'";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.descricao = dr["motivo"].ToString();
                    dto.data_hora_emissao = Convert.ToDateTime(dr["data_hora_emissao"]);
                    dto.valor = Convert.ToDecimal(dr["valor"]);
                    string s_valor = Convert.ToDouble(dr["valor"]).ToString("N2");
                    dto.s_valor = s_valor;
                    dto.s_codigo_tipo_despesa = dr["tipo_despesa"].ToString();
                    dto.s_codigo_setor = dr["setor"].ToString();
                    dto.s_codigo_forma_pagamento = dr["forma_pagamento"].ToString();
                    dto.codigo_forma_pagamento = Convert.ToInt32(dr["codigo_forma_pagamento"]);
                    dto.codigo_setor = Convert.ToInt32(dr["codigo_setor"]);
                    dto.codigo_tipo_despesa = Convert.ToInt32(dr["codigo_tipo_despesa"]);
                    dto.codigo_usuario = Convert.ToInt32(dr["codigo_usuario"]);
                    dto.s_codigo_usuario = dr["nome"].ToString() + " " + dr["sobrenome"].ToString();
                }
                dr.Close();
            }

            return dto;
        }

        public List<dtoDespesa> ListarTodasDespesasPorFormaPagamento(int codigo_forma_pagamento, DateTime inicial, DateTime final)
        {
            var list = new List<dtoDespesa>();

            var ssql = "select d.codigo, d.data_hora_emissao, d.valor, d.descricao, tp.descricao as tipo_despesa, s.nome as setor, fp.descricao as forma_pagamento, d.motivo";
            ssql += " d.codigo_tipo_despesa, d.codigo_forma_pagamento, d.codigo_setor, d.codigo_setor, d.codigo_usuario from despesa d";
            ssql += " inner join tipodespesa tp on(d.codigo_tipo_despesa = tp.codigo) ";
            ssql += " inner join setor s on(d.codigo_setor = s.codigo) ";
            ssql += " inner join forma_pagamento fp ON (fp.codigo = d.codigo_forma_pagamento)";
            ssql += " inner join usuario u on(d.codigo_usuario = u.codigo)";
            ssql += $" where s.codigo_departamento = '{VariaveisGlobais.codigo_departamento}'";
            ssql += $" and d.data_hora_emissao between '{inicial.ToString("yyyy-MM-dd") + " 00:00:00.000"}' and '{final.ToString("yyyy-MM-dd") + " 23:59:59.000"}'";

            if (VariaveisGlobais.nivel_acesso == 2)
            {
                ssql += $" and s.codigo_setor = '{VariaveisGlobais.codigo_setor}'";
            }

            ssql += $" and d.codigo_forma_pagamento = '{codigo_forma_pagamento}'";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoDespesa();
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.descricao = dr["motivo"].ToString();
                    dto.data_hora_emissao = Convert.ToDateTime(dr["data_hora_emissao"]);
                    dto.valor = Convert.ToDecimal(dr["valor"]);
                    string s_valor = Convert.ToDouble(dr["valor"]).ToString("N2");
                    dto.s_valor = s_valor;
                    dto.s_codigo_tipo_despesa = dr["tipo_despesa"].ToString();
                    dto.s_codigo_setor = dr["setor"].ToString();
                    dto.s_codigo_forma_pagamento = dr["forma_pagamento"].ToString();
                    dto.codigo_forma_pagamento = Convert.ToInt32(dr["codigo_forma_pagamento"]);
                    dto.codigo_setor = Convert.ToInt32(dr["codigo_setor"]);
                    dto.codigo_tipo_despesa = Convert.ToInt32(dr["codigo_tipo_despesa"]);
                    dto.codigo_usuario = Convert.ToInt32(dr["codigo_usuario"]);

                    list.Add(dto);
                }
                dr.Close();
            }

            return list;
        }

        public List<dtoDespesa> ListarTodasDespesas(DateTime inicial, DateTime final, int codigo_forma_pagamento, int codigo_tipo_despesa, int codigo_setor)
        {
            var list = new List<dtoDespesa>();

            var ssql = "select d.codigo, d.data_hora_emissao, d.valor, d.descricao, tp.descricao as tipo_despesa, s.nome as setor, fp.descricao as forma_pagamento, ";
            ssql += " d.codigo_tipo_despesa, d.codigo_forma_pagamento, d.codigo_setor, d.codigo_setor, d.codigo_usuario from despesa d";
            ssql += " inner join tipodespesa tp on(d.codigo_tipo_despesa = tp.codigo) ";
            ssql += " inner join setor s on(d.codigo_setor = s.codigo) ";
            ssql += " inner join forma_pagamento fp ON (fp.codigo = d.codigo_forma_pagamento)";
            ssql += " inner join usuario u on(d.codigo_usuario = u.codigo)";
            ssql += $" where s.codigo_departamento = '{VariaveisGlobais.codigo_departamento}'";
            ssql += $" and d.data_hora_emissao between '{inicial.ToString("yyyy-MM-dd") + " 00:00:00.000"}' and '{final.ToString("yyyy-MM-dd") + " 23:59:59.000"}'";
            ssql += $" and s.codigo = '{codigo_setor}'";
            ssql += $" and fp.codigo = '{codigo_forma_pagamento}'";
            ssql += $" and tp.codigo = '{codigo_tipo_despesa}'";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoDespesa();
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.descricao = dr["descricao"].ToString();
                    dto.data_hora_emissao = Convert.ToDateTime(dr["data_hora_emissao"]);
                    dto.valor = Convert.ToDecimal(dr["valor"]);
                    string s_valor = Convert.ToDouble(dr["valor"]).ToString("N2");
                    dto.s_valor = s_valor;
                    dto.s_codigo_tipo_despesa = dr["tipo_despesa"].ToString();
                    dto.s_codigo_setor = dr["setor"].ToString();
                    dto.s_codigo_forma_pagamento = dr["forma_pagamento"].ToString();
                    dto.codigo_forma_pagamento = Convert.ToInt32(dr["codigo_forma_pagamento"]);
                    dto.codigo_setor = Convert.ToInt32(dr["codigo_setor"]);
                    dto.codigo_tipo_despesa = Convert.ToInt32(dr["codigo_tipo_despesa"]);
                    dto.codigo_usuario = Convert.ToInt32(dr["codigo_usuario"]);

                    list.Add(dto);
                }
                dr.Close();
            }

            return list;
        }

        public List<dtoDespesa> ListarTodasDespesasPorData(DateTime inicial, DateTime final)
        {
            var list = new List<dtoDespesa>();

            var ssql = "select d.codigo, d.data_hora_emissao, d.valor, d.descricao, tp.descricao as tipo_despesa, s.nome as setor, fp.descricao as forma_pagamento, ";
            ssql += " d.codigo_tipo_despesa, d.codigo_forma_pagamento, d.codigo_setor, d.codigo_setor, d.codigo_usuario from despesa d";
            ssql += " inner join tipodespesa tp on(d.codigo_tipo_despesa = tp.codigo) ";
            ssql += " inner join setor s on(d.codigo_setor = s.codigo) ";
            ssql += " inner join forma_pagamento fp ON (fp.codigo = d.codigo_forma_pagamento)";
            ssql += " inner join usuario u on(d.codigo_usuario = u.codigo)";
            ssql += $" where s.codigo_departamento = '{VariaveisGlobais.codigo_departamento}'";
            ssql += $" and d.data_hora_emissao between '{inicial.ToString("yyyy-MM-dd") + " 00:00:00.000"}' and '{final.ToString("yyyy-MM-dd") + " 23:59:59.000"}'";

            if (VariaveisGlobais.nivel_acesso == 2)
            {
                ssql += $" and so.codigo_setor = '{VariaveisGlobais.codigo_setor}'";
            }

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoDespesa();
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.descricao = dr["descricao"].ToString();
                    dto.data_hora_emissao = Convert.ToDateTime(dr["data_hora_emissao"]);
                    dto.valor = Convert.ToDecimal(dr["valor"]);
                    string s_valor = Convert.ToDouble(dr["valor"]).ToString("N2");
                    dto.s_valor = s_valor;
                    dto.s_codigo_tipo_despesa = dr["tipo_despesa"].ToString();
                    dto.s_codigo_setor = dr["setor"].ToString();
                    dto.s_codigo_forma_pagamento = dr["forma_pagamento"].ToString();
                    dto.codigo_forma_pagamento = Convert.ToInt32(dr["codigo_forma_pagamento"]);
                    dto.codigo_setor = Convert.ToInt32(dr["codigo_setor"]);
                    dto.codigo_tipo_despesa = Convert.ToInt32(dr["codigo_tipo_despesa"]);
                    dto.codigo_usuario = Convert.ToInt32(dr["codigo_usuario"]);

                    list.Add(dto);
                }
                dr.Close();
            }

            return list;
        }

        public bool UpdateDespesa(dtoDespesa dto)
        {
            var ssql = "update despesa set valor = @valor, descricao = @descricao, codigo_tipo_despesa = @codigo_tipo_despesa, " +
                "codigo_forma_pagamento = @codigo_forma_pagamento where codigo = @codigo";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            {
                cmd.Parameters.AddWithValue("@valor", dto.valor);
                cmd.Parameters.AddWithValue("@descricao", dto.descricao);
                cmd.Parameters.AddWithValue("@codigo_tipo_despesa", dto.codigo_tipo_despesa);
                cmd.Parameters.AddWithValue("@codigo_forma_pagamento", dto.codigo_forma_pagamento);
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

        public DataSet DashboardTodoPeriodo()
        {
            DataSet ds = new DataSet();

            var ssql = "select sum(valor) as ValorDespesa, s.codigo, s.nome as CentrodeCusto from despesa d left join setor s on(d.codigo_setor = s.codigo) group by s.codigo, s.nome";

            using (var ad = new NpgsqlDataAdapter(ssql, dalConexao.dalConexao.cnn))
            {
                ad.Fill(ds);
            }

            return ds;
        }
    }
}
