using DespesaDigital.Code.DAL.dalFormaPagamento;
using DespesaDigital.Code.DTO.dtoFormaPagamento;
using System.Collections.Generic;

namespace DespesaDigital.Code.BLL.bllFormaPagamento
{
    public class bllFormaPagamento
    {
        public static List<dtoFormaPagamento> ListarTodasFormasPagamentoPorStatus(string status)
        {
            var dal = new dalFormaPagamento();
            return dal.ListarTodasFormasPagamentoPorStatus(status);
        }

        public static List<dtoFormaPagamento> ListarTodasFormasPagamentoPorStatusDescricao(string status, string descricao)
        {
            var dal = new dalFormaPagamento();
            return dal.ListarTodasFormasPagamentoPorStatusDescricao(status, descricao);
        }

        public static dtoFormaPagamento FormaPagamentoPorCodigo(int codigo)
        {
            var dal = new dalFormaPagamento();
            return dal.FormaPagamentoPorCodigo(codigo);
        }

        public static bool Insert(dtoFormaPagamento dto)
        {
            var dal = new dalFormaPagamento();
            return dal.Insert(dto);
        }

        public static bool Delete(int codigo)
        {
            var dal = new dalFormaPagamento();
            return dal.Delete(codigo);
        }

        public static bool Update(dtoFormaPagamento dto)
        {
            var dal = new dalFormaPagamento();
            return dal.Update(dto);
        }

        public static bool VerificaDescricaoExistente(string descricao)
        {
            var dal = new dalFormaPagamento();
            return dal.VerificaDescricaoExistente(descricao);
        }

        public static string VerificaDescricaoAtual(int codigo)
        {
            var dal = new dalFormaPagamento();
            return dal.VerificaDescricaoAtual(codigo);
        }
    }
}
