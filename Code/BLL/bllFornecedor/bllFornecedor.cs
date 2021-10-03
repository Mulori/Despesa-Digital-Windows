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
    }
}
