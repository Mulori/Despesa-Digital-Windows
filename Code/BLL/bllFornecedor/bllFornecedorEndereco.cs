using DespesaDigital.Code.DAL.dalFornecedor;
using DespesaDigital.Code.DTO.dtoFornecedor;
using System.Collections.Generic;

namespace DespesaDigital.Code.BLL.bllFornecedor
{
    public class bllFornecedorEndereco
    {
        public static bool Insert(dtoFornecedorEndereco dto)
        {
            var dal = new dalFornecedorEndereco();
            return dal.Insert(dto);
        }

        public static bool Delete(int codigo, int codigo_fornecedor)
        {
            var dal = new dalFornecedorEndereco();
            return dal.Delete(codigo, codigo_fornecedor);
        }

        public static bool Update(dtoFornecedorEndereco dto)
        {
            var dal = new dalFornecedorEndereco();
            return dal.Update(dto);
        }

        public static List<dtoFornecedorEndereco> TodosEnderecoFornecedorCodigo(int codigo_fornecedor)
        {
            var dal = new dalFornecedorEndereco();
            return dal.TodosEnderecoFornecedorCodigo(codigo_fornecedor);
        }

        public static dtoFornecedorEndereco EnderecoCodigo(int codigo)
        {
            var dal = new dalFornecedorEndereco();
            return dal.EnderecoCodigo(codigo);
        }
    }
}
