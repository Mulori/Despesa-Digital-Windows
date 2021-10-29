using DespesaDigital.Code.DAL.dalImagem;

namespace DespesaDigital.Code.BLL.bllImagem
{
    public class bllImagem
    {
        public static byte[] ObterByteImagemDespesaPorCodigo(long codigo_despesa)
        {
            var dal = new dalImagem();
            return dal.ObterByteImagemDespesaPorCodigo(codigo_despesa);
        }
    }
}
