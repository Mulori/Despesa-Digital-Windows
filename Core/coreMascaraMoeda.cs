using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace DespesaDigital.Core
{
   public  class coreMascaraMoeda
    {
        private static long ConverterReaisParaDecimal(string valor)
        {
            if (valor == "R$ " || valor == "R$")
            {
                valor = "0";
            }

            var valorConvertido = Decimal.Parse(valor.Replace("R$ ", "").Replace(",", "").Replace(".", ""),
                CultureInfo.GetCultureInfo("pt-BR"));
            return (long)valorConvertido;
        }
    }
}
