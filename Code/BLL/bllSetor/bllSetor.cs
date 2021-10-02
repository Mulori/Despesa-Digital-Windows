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

        public static List<dtoSetor> ListSetorPorCodigo(int setor)
        {
            var dal = new dalSetor();
            return dal.ListSetorPorCodigo(setor);
        }

        public static dtoSetor SetorPorCodigo(int id)
        {
            var dal = new dalSetor();
            return dal.SetorPorCodigo(id);
        }

        public static List<dtoSetor> ListSetorPorNome(string nome)
        {
            var dal = new dalSetor();
            return dal.ListSetorPorNome(nome);
        }

        public static bool Insert(dtoSetor dto)
        {
            var dal = new dalSetor();
            return dal.Insert(dto);
        }

        public static bool Delete(int codigo)
        {
            var dal = new dalSetor();
            return dal.Delete(codigo);
        }

        public static bool Update(dtoSetor dto)
        {
            var dal = new dalSetor();
            return dal.Update(dto);
        }

        public static bool VerificaNomeExistente(string nome)
        {
            var dal = new dalSetor();
            return dal.VerificaNomeExistente(nome);
        }
    }
}
