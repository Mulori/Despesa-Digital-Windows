using DespesaDigital.Code.DAL.dalLogSistema;
using DespesaDigital.Code.DTO.dtoLogSistema;
using System;
using System.Collections.Generic;

namespace DespesaDigital.Code.BLL.bllLogSistema
{
    public class bllLogSistema
    {
        public static bool Insert(string descricao)
        {
            var dal = new dalLogSistema();
            return dal.Insert(descricao);
        }

        public static List<dtoLogSistema> SelecionarLogs(DateTime inicio, DateTime fim, string email)
        {
            var dal = new dalLogSistema();
            return dal.SelecionarLogs(inicio, fim, email);
        }
    }
}
