using DespesaDigital.Code.DAL.dalFornecedor;
using DespesaDigital.Code.DTO.dtoFornecedor;
using System.Collections.Generic;

namespace DespesaDigital.Code.BLL.bllFornecedor
{
    public class bllFornecedor
    {
        public static List<dtoFornecedor> ListarTodosFornecedores()
        {
            var dal = new dalFornecedor();
            return dal.ListarTodosFornecedores();
        }

        public static List<dtoFornecedor> ListarTodosFornecedoresPorRazaoSocial(string razao_social)
        {
            var dal = new dalFornecedor();
            return dal.ListarTodosFornecedoresPorRazaoSocial(razao_social);
        }

        public static string CodigoFornecedoresContatenado(int departamento)
        {
            var dal = new dalFornecedor();
            return dal.CodigoFornecedoresContatenado(departamento);
        }
    }
}
