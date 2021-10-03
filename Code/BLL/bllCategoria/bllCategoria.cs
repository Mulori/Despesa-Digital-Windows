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
    }
}
