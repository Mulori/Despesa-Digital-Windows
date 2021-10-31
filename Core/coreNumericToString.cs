using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespesaDigital.Core
{
    public class coreNumericToString
    {
        public enum DataMes
        {
            Janeiro,
            Fevereiro,
            Março,
            Abril,
            Maio,
            Junho,
            Julho,
            Agosto,
            Setembro,
            Outubro,
            Novembro,
            Dezembro,
        }

        public static int MesCaracterParaMesNumerico(DataMes dt)
        {
            switch (dt)
            {
                case DataMes.Janeiro:
                    return 1;
                case DataMes.Fevereiro:
                    return 2;
                case DataMes.Março:
                    return 3;
                case DataMes.Abril:
                    return 4;
                case DataMes.Maio:
                    return 5;
                case DataMes.Junho:
                    return 6;
                case DataMes.Julho:
                    return 7;
                case DataMes.Agosto:
                    return 8;
                case DataMes.Setembro:
                    return 9;
                case DataMes.Outubro:
                    return 10;
                case DataMes.Novembro:
                    return 11;
                case DataMes.Dezembro:
                    return 12;
                default:
                    return 0;

            }
        }


        public static string MesNumericoParaMesCaracter(int mes)
        {
            switch (mes)
            {
                case 1:
                    return "Janeiro";
                case 2:
                    return "Fevereiro";
                case 3:
                    return "Março";
                case 4:
                    return "Abril";
                case 5:
                    return "Maio";
                case 6:
                    return "Junho";
                case 7:
                    return "Julho";
                case 8:
                    return "Agosto";
                case 9:
                    return "Setembro";
                case 10:
                    return "Outubro";
                case 11:
                    return "Novembro";
                case 12:
                    return "Dezembro";
                default:
                    return "Mês inexitente";

            }
        }
    }
}
