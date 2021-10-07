using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespesaDigital.Code.DTO.dtoFornecedor
{
    public class dtoFornecedorEndereco
    {
        public int codigo { get; set; }
        public int codigo_fornecedor { get; set; }
        public string logradouro { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string pais { get; set; }
        public string cep { get; set; }
    }
}
