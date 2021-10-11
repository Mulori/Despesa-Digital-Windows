using DespesaDigital.Code.DAL.dalTipoDespesa;
using DespesaDigital.Code.DTO.dtoTipoDespesa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespesaDigital.Code.BLL.bllTipoDespesa
{
    public class bllTipoDespesa
    {
        public static List<dtoTipoDespesa> ListarTodosTipoDespesaPorStatusDescricao(string status, string descricao)
        {
            var dal = new dalTipoDespesa();
            return dal.ListarTodosTipoDespesaPorStatusDescricao(status, descricao);
        }

        public static List<dtoTipoDespesa> ListarTodasTipoDespesaPorStatus(string status)
        {
            var dal = new dalTipoDespesa();
            return dal.ListarTodasTipoDespesaPorStatus(status);
        }

        public static dtoTipoDespesa TipoDespesaPorCodigo(int codigo)
        {
            var dal = new dalTipoDespesa();
            return dal.TipoDespesaPorCodigo(codigo);
        }

        public static bool Insert(dtoTipoDespesa dto)
        {
            var dal = new dalTipoDespesa();
            return dal.Insert(dto);
        }

        public static bool Delete(int codigo)
        {
            var dal = new dalTipoDespesa();
            return dal.Delete(codigo);
        }

        public static bool Update(dtoTipoDespesa dto)
        {
            var dal = new dalTipoDespesa();
            return dal.Update(dto);
        }

        public static bool VerificaDescricaoExistente(string descricao)
        {
            var dal = new dalTipoDespesa();
            return dal.VerificaDescricaoExistente(descricao);
        }

        public static string VerificaDescricaoAtual(int codigo)
        {
            var dal = new dalTipoDespesa();
            return dal.VerificaDescricaoAtual(codigo);
        }
    }
}
