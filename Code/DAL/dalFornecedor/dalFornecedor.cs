using DespesaDigital.Code.DTO.dtoFornecedor;
using DespesaDigital.Core;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespesaDigital.Code.DAL.dalFornecedor
{
    public class dalFornecedor
    {
        public List<dtoFornecedor> ListarTodosFornecedores()
        {
            var list = new List<dtoFornecedor>();

            var ssql = "select f.codigo, f.cnpj, f.razao_social, f.codigo_departamento, d.nome from fornecedor f " +
                $"inner join departamento d on(f.codigo_departamento = d.codigo) where d.codigo = '{VariaveisGlobais.codigo_setor}'";

            using (var cmd = new NpgsqlCommand(ssql, dalConexao.dalConexao.cnn))
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var dto = new dtoFornecedor();
                    dto.codigo = Convert.ToInt32(dr["codigo"]);
                    dto.cnpj = dr["cnpj"].ToString();
                    dto.razao_social = dr["razao_social"].ToString();
                    dto.codigo_departamento = Convert.ToInt32(dr["codigo_departamento"]);
                    dto.s_codigo_departamento = dr["nome"].ToString();

                    list.Add(dto);
                }
                dr.Close();
            }

            return list;
        }
    }
}
