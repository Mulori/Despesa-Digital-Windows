﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespesaDigital.Core
{
    public class VariaveisGlobais
    {
        #region usuario
        public static int codigo_usuario { get; set; }
        public static int codigo_setor { get; set; }
        public static string nome_usuario { get; set; }
        public static string sobrenome_usuario { get; set; }
        public static int nivel_acesso { get; set; }
        #endregion 

        #region mensagem
        public static bool resposta_pergunta { get; set; }
        #endregion    
    }
}
