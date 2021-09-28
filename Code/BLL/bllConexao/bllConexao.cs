using DespesaDigital.Code.DAL.dalConexao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespesaDigital.Code.BLL.bllConexao
{
    public class bllConexao
    {
        public static bool Conectar()
        {
            var dal = new dalConexao();
            return dal.Conectar();
        }

        public static bool Desconectar()
        {
            var dal = new dalConexao();
            return dal.Desconectar();
        }
    }
}
