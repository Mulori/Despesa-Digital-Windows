using DespesaDigital.Code.DTO.dtoDespesa;
using DespesaDigital.Core;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespesaDigital.Code.DAL.dalDespesa
{
    public class dalDespesa
    {
        public List<dtoDespesa> ListarTodasDespesasPorFormaPagamento(int codigo_forma_pagamento, DateTime inicial, DateTime final)
        {
            var list = new List<dtoDespesa>();

            var ssql = "select de.codigo, de.data_hora_emissao, de.valor, de.descricao, de.codigo_tipo_despesa, de.codigo_setor, de.codigo_forma_pagamento, de.codigo_usuario from despesa de";
            ssql += " inner join forma_pagamento fp on(de.codigo_forma_pagamento = fp.codigo)";
            ssql += " left join setor se on(de.codigo_setor = se.codigo)";
            ssql += $" where se.codigo_departamento = '{VariaveisGlobais.codigo_departamento}'";
            ssql += $" and de.data_hora_emissao between '{inicial.ToString("yyyy-MM-dd") + " 00:00:00.000"}' and '{final.ToString("yyyy-MM-dd") + " 23:59:59.000"}'";

            if (VariaveisGlobais.nivel_acesso == 2)
            {
                ssql += $" and so.codigo_setor = '{VariaveisGlobais.codigo_setor}'";
            }

            ssql += $" and de.codigo_forma_pagamento = '{codigo_forma_pagamento}'";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoDespesa();
                    //dto.codigo = Convert.ToInt32(dr["codigo"]);
                    //dto.motivo = dr["motivo"].ToString();
                    //dto.data_solicitacao = Convert.ToDateTime(dr["data_solicitacao"]);
                    //dto.valor = Convert.ToDecimal(dr["valor"]);
                    //string s_valor = Convert.ToDouble(dr["valor"]).ToString("N2");
                    //dto.s_valor = s_valor;

                    //switch (dr["status"].ToString())
                    //{
                    //    case "A":
                    //        dto.status = "Aprovado";
                    //        break;
                    //    case "P":
                    //        dto.status = "Pendente";
                    //        break;
                    //    case "R":
                    //        dto.status = "Rejeitado";
                    //        break;
                    //}

                    //dto.s_codigo_produto = dr["descricao"].ToString();
                    //dto.s_codigo_setor = dr["nome"].ToString();

                    list.Add(dto);
                }
                dr.Close();
            }

            return list;
        }

    }
}
