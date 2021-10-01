using DespesaDigital.Code.DAL.dalUsuarioAprovacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespesaDigital.Code.BLL.bllUsuarioAprovacao
{
    public class bllUsuarioAprovacao
    {
        public static bool Delete(int codigo_usuario)
        {
            var bll = new dalUsuarioAprovacao();
            return bll.Delete(codigo_usuario);
        }
    }
}
