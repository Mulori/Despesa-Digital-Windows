using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespesaDigital.Core
{
    public class coreMid
    {
        public static string MidString(string mid, int pos)
        {
            if (mid.Length >= pos)
            {
                return mid.Substring(0, pos);
            }
            else
            {
                return mid.Substring(0, mid.Length);
            }
        }
    }
}
