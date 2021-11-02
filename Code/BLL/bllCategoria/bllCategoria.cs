using DespesaDigital.Code.DAL.dalCategoria;
using DespesaDigital.Code.DTO.dtoCategoria;
using System.Collections.Generic;

namespace DespesaDigital.Code.BLL.bllCategoria
{
    public class bllCategoria
    {
        public static List<dtoCategoria> ListarTodasCategoriasPorStatus(string status) 
        {
            var dal = new dalCategoria();
            return dal.ListarTodasCategoriasPorStatus(status);
        }
        public static List<dtoCategoria> ListarTodasCategoriaPorStatusDescricao(string status, string descricao)
        {
            var dal = new dalCategoria();
            return dal.ListarTodasCategoriaPorStatusDescricao(status, descricao);
        }

        public static dtoCategoria CategoriaPorCodigo(int codigo)
        {
            var dal = new dalCategoria();
            return dal.CategoriaPorCodigo(codigo);
        }

        public static bool Insert(dtoCategoria dto)
        {
            var dal = new dalCategoria();
            return dal.Insert(dto);
        }

        public static bool Delete(int codigo)
        {
            var dal = new dalCategoria();
            return dal.Delete(codigo);
        }

        public static bool Update(dtoCategoria dto)
        {
            var dal = new dalCategoria();
            return dal.Update(dto);
        }

        public static bool VerificaDescricaoExistente(string descricao)
        {
            var dal = new dalCategoria();
            return dal.VerificaDescricaoExistente(descricao);
        }

        public static string VerificaDescricaoAtual(int codigo)
        {
            var dal = new dalCategoria();
            return dal.VerificaDescricaoAtual(codigo);
        }

        public static int GetCategoriaOutros()
        {
            var dal = new dalCategoria();
            return dal.GetCategoriaOutros();
        }
    }
}
