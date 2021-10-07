using DespesaDigital.Code.DAL.dalFornecedor;
using DespesaDigital.Code.DTO.dtoFornecedor;

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
    }
}
