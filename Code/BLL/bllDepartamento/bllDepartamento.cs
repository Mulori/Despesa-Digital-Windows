using DespesaDigital.Code.DAL.dalDepartamento;
using DespesaDigital.Code.DTO.dtoDepartamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespesaDigital.Code.BLL.bllDepartamento
{
    public class bllDepartamento
    {
        public static List<dtoDepartamento> TodosDepartamentos()
        {
            var dal = new dalDepartamento();
            return dal.TodosDepartamentos();
        }

        public static List<dtoDepartamento> DepartamentoPorSetor(int id)
        {
            var dal = new dalDepartamento();
            return dal.DepartamentoPorSetor(id);
        }
    }
}
