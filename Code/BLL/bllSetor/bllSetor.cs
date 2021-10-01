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

        public static string CodigoSetoresContatenado(int departamento)
        {
            var dal = new dalSetor();
            return dal.CodigoSetoresContatenado(departamento);
        }

        public static int CodigoDepartamentoPorCodigoSetor(int setor)
        {
            var dal = new dalSetor();
            return dal.CodigoDepartamentoPorCodigoSetor(setor);
        }

        public static List<dtoSetor> SetorPorCodigo(int setor)
        {
            var dal = new dalSetor();
            return dal.SetorPorCodigo(setor);
        }
    }
}
