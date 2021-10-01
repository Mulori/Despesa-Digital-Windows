using System.Collections.Generic;

namespace DespesaDigital.Code.DTO
{
    public class dtoUsuario
    {
        public int codigo { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public int nivel_acesso { get; set; }
        public string s_nivel_acesso { get; set; }
        public string ativo { get; set; }
        public int codigo_setor { get; set; }
        public string nome_setor { get; set; }
        public string nome_departamento { get; set; }
    }
}
