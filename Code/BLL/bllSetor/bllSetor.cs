using DespesaDigital.Code.DAL.dalSetor;
using DespesaDigital.Code.DTO.dtoSetor;
using System.Collections.Generic;

namespace DespesaDigital.Code.BLL.bllSetor
{
    public class bllSetor
    {
        public static List<dtoSetor> TodosSetoresPorDepartamento(string departamento)
        {
            var dal = new dalSetor();
            return dal.TodosSetoresPorSetor(departamento);
        }
    }
}
