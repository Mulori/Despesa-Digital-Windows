using DespesaDigital.Code.DAL.dalFornecedor;
using DespesaDigital.Code.DTO.dtoFornecedor;
using System.Collections.Generic;

namespace DespesaDigital.Code.BLL.bllFornecedor
{
    class bllFornecedorContato
    {
        public static bool Insert(dtoFornecedorContato dto)
        {
            var dal = new dalFornecedorContato();
            return dal.Insert(dto);
        }

        public static bool Delete(int codigo, int codigo_fornecedor)
        {
            var dal = new dalFornecedorContato();
            return dal.Delete(codigo, codigo_fornecedor);
        }

        public static bool Update(dtoFornecedorContato dto)
        {
            var dal = new dalFornecedorContato();
            return dal.Update(dto);
        }

        public static List<dtoFornecedorContato> TodosContatoFornecedorCodigo(int codigo_fornecedor)
        {
            var dal = new dalFornecedorContato();
            return dal.TodosContatoFornecedorCodigo(codigo_fornecedor);
        }

        public static dtoFornecedorContato ContatoCodigo(int codigo_fornecedor)
        {
            var dal = new dalFornecedorContato();
            return dal.ContatoCodigo(codigo_fornecedor);
        }
    }
}
