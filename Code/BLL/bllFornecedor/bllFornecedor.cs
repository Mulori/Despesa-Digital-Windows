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

        public static List<dtoFornecedor> ListarTodosFornecedoresPorCNPJ(string cnpj)
        {
            var dal = new dalFornecedor();
            return dal.ListarTodosFornecedoresPorCNPJ(cnpj);
        }

        public static dtoFornecedor FornecedoresPorCodigo(int codigo_fornecedor)
        {
            var dal = new dalFornecedor();
            return dal.FornecedoresPorCodigo(codigo_fornecedor);
        }

        public static bool VerificaCNPJExistente(string cnpj)
        {
            var dal = new dalFornecedor();
            return dal.VerificaCNPJExistente(cnpj);
        }

        public static string VerificaCNPJAtual(int codigo)
        {
            var dal = new dalFornecedor();
            return dal.VerificaCNPJAtual(codigo);
        }
        public static bool VerificaRazaoSocialExistente(string razao_social)
        {
            var dal = new dalFornecedor();
            return dal.VerificaRazaoSocialExistente(razao_social);
        }

        public static string VerificaRazaoSocialAtual(int codigo)
        {
            var dal = new dalFornecedor();
            return dal.VerificaRazaoSocialAtual(codigo);
        }

        public static bool Insert(dtoFornecedor dto)
        { 
            var dal = new dalFornecedor();
            return dal.Insert(dto);
        }

        public static bool Delete(int codigo)
        {
            var dal = new dalFornecedor();
            return dal.Delete(codigo);
        }

        public static bool Update(dtoFornecedor dto)
        {
            var dal = new dalFornecedor();
            return dal.Update(dto);
        }
    }
}
