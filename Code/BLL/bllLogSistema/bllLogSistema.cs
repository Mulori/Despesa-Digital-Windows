using DespesaDigital.Code.DAL.dalLogSistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespesaDigital.Code.BLL.bllLogSistema
{
    public class bllLogSistema
    {
        public static bool Insert(string descricao)
        {
            var dal = new dalLogSistema();
            return dal.Insert(descricao);
        }
    }
}
