using System;

namespace DespesaDigital.Code.DTO
{
    public class dtoRelUsuario
    {
        public int codigo { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string email { get; set; }
        public string s_nivel_acesso { get; set; }
        public string s_ativo { get; set; }
        public string setor { get; set; }
        public DateTime datahora { get; set; }
    }
}
