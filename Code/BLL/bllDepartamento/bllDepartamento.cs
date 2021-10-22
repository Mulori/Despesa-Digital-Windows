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

        public static bool Insert(dtoDepartamento dto)
        {
            var dal = new dalDepartamento();
            return dal.Insert(dto);
        }

        public static bool VerificaNomeExistente(string nome)
        {
            var dal = new dalDepartamento();
            return dal.VerificaNomeExistente(nome);
        }

        public static dtoDepartamento DepartamentoPorCodigo(int id)
        {
            var dal = new dalDepartamento();
            return dal.DepartamentoPorCodigo(id);
        }

        public static bool Update(dtoDepartamento dto)
        {
            var dal = new dalDepartamento();
            return dal.Update(dto);
        }

        public static bool Delete(int codigo)
        {
            var dal = new dalDepartamento();
            return dal.Delete(codigo);
        }
        public static string VerificaNomeAtual(int codigo)
        {
            var dal = new dalDepartamento();
            return dal.VerificaNomeAtual(codigo);
        }
    }
}
