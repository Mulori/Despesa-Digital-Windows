using DespesaDigital.Code.DAL.dalSetor;
using DespesaDigital.Code.DTO.dtoSetor;
using System.Collections.Generic;

namespace DespesaDigital.Code.BLL.bllSetor
{
    public class bllSetor
    {
        public static List<dtoSetor> TodosSetoresPorDepartamento(int departamento)
        {
            var dal = new dalSetor();
            return dal.TodosSetoresPorCodigoDepartamento(departamento);
        }

        public static int IdSetorPorNome(string setor)
        {
            var dal = new dalSetor();
            return dal.IdSetorPorNome(setor);
        }
    }
}
