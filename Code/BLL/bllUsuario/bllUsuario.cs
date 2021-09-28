using DespesaDigital.Code.DAL.dalUsuario;
using DespesaDigital.Code.DTO;

namespace DespesaDigital.Code.BLL
{
    public class bllUsuario
    {
        public static dtoUsuario AutenticaUsuario(string email, string senha)
        {
            var dal = new dalUsuario();
            return dal.AutenticaUsuario(email, senha);
        }
    }
}
