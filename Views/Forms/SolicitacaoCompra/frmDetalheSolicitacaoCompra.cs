using DespesaDigital.Code.BLL.bllLogSistema;
using DespesaDigital.Code.BLL.bllSolicitacaoCompra;
using DespesaDigital.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.SolicitacaoCompra
{
    public partial class frmDetalheSolicitacaoCompra : Form
    {
        public static long solicitacao_codigo { get; set; }
        public frmDetalheSolicitacaoCompra(long codigo_solicitacao)
        {
            InitializeComponent();
            solicitacao_codigo = codigo_solicitacao;
        }

        private void frmDetalheSolicitacaoCompra_Load(object sender, EventArgs e)
        {
            var obj = bllSolicitacaoCompra.SolicitacaoPorCodigo(solicitacao_codigo);

            txtNumeroSolicitacao.Text = obj.codigo.ToString();
            txtDataSolicitacao.Text = obj.data_solicitacao.ToString("dd/MM/yyyy HH:mm:ss");
            txtUsuario.Text = obj.usuario;
            txtSetor.Text = obj.s_codigo_setor;
            txtValorSolicitado.Text = $"R${obj.valor.ToString("N2")}";

            switch (obj.status)
            {
                case "Aprovado":
                    txtStatus.Text = "Aprovado";
                    btnAprovar.Visible = false;
                    btnRejeitar.Visible = false;
                    break;
                case "Pendente":
                    txtStatus.Text = "Pendente";
                    break;
                case "Rejeitado":
                    btnAprovar.Visible = false;
                    btnRejeitar.Visible = false;
                    txtStatus.Text = "Rejeitado";
                    break;
            }

            txtItem.Text = obj.s_codigo_produto;
            txtObservacao.Text = obj.motivo;

            obj = null;
        }

        private void btnAprovar_Click(object sender, EventArgs e)
        {
            if (!corePopUp.exibirPergunta("Atenção", "Deseja aprovar esta solicitação de compra?", 1))
            {
                return;
            }

            if (bllSolicitacaoCompra.UpdateStatus(solicitacao_codigo, "A"))
            {
                bllSolicitacaoCompra.UsuarioAprovouRejeitou(solicitacao_codigo, VariaveisGlobais.codigo_usuario);
                bllLogSistema.Insert($"Aprovou uma solicitação de compra: [Codigo: [{solicitacao_codigo}]");
                corePopUp.exibirMensagem("Solicitação aprovada com sucesso!", "Atenção");
                this.Close();
            }
            else
            {
                corePopUp.exibirMensagem("Ocorreu um problema ao aprovar a solicitação.", "ERRO");
                return;
            }
        }

        private void btnRejeitar_Click(object sender, EventArgs e)
        {
            if (!corePopUp.exibirPergunta("Atenção", "Deseja rejeitar esta solicitação de compra?", 1))
            {
                return;
            }

            if (bllSolicitacaoCompra.UpdateStatus(solicitacao_codigo, "R"))
            {
                bllSolicitacaoCompra.UsuarioAprovouRejeitou(solicitacao_codigo, VariaveisGlobais.codigo_usuario);
                bllLogSistema.Insert($"Rejeitou uma solicitação de compra: [Codigo: [{solicitacao_codigo}]");
                corePopUp.exibirMensagem("Solicitação aprovada com sucesso!", "Atenção");
                this.Close();
            }
            else
            {
                corePopUp.exibirMensagem("Ocorreu um problema ao rejeitar a solicitação.", "ERRO");
                return;
            }
        }
    }
}
