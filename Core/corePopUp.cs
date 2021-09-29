using DespesaDigital.Views.Forms.Mensagens;

namespace DespesaDigital.Core
{
    public class corePopUp
    {
        public static bool exibirPergunta(string titulo, string mensagem, int foco)
        {
            using (var form = new frmPergunta(titulo, mensagem, foco))
            {
                form.ShowDialog();
                if (VariaveisGlobais.resposta_pergunta)
                {
                    VariaveisGlobais.resposta_pergunta = false;
                    return true;
                }
                else
                {
                    VariaveisGlobais.resposta_pergunta = false;
                    return false;
                }
            }
        }

        public static void exibirMensagem(string mensagem, string titulo)
        {
            using (var form = new frmMensagem(mensagem, titulo))
            {
                form.ShowDialog();
            }
        }
    }
}
