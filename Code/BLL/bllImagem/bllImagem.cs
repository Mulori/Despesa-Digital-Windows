﻿using DespesaDigital.Code.DAL.dalImagem;
using System.Threading.Tasks;

namespace DespesaDigital.Code.BLL.bllImagem
{
    public class bllImagem
    {
        public static byte[] ObterByteImagemDespesaPorCodigo(long codigo_despesa)
        {
            var dal = new dalImagem();
            return dal.ObterByteImagemDespesaPorCodigo(codigo_despesa);
        }

        public static async Task<int> Insert(byte[] file_byte, long codigo_despesa, string formato)
        {
            var dal = new dalImagem();
            return await dal.Insert(file_byte, codigo_despesa, formato);
        }

        public static string ObterFormatoImagemDespesaPorCodigo(long codigo_despesa)
        {
            var dal = new dalImagem();
            return dal.ObterFormatoImagemDespesaPorCodigo(codigo_despesa);
        }
    }
}
