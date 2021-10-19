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

            string informacoes = "";
            informacoes += $"Solicitação Nº: {obj.codigo}";
            informacoes += $"{Environment.NewLine}Data da Solicitação: {obj.data_solicitacao.ToString("dd/MM/yyyy HH:mm:ss")}";
            informacoes += $"{Environment.NewLine}Usuario: {obj.usuario}";
            informacoes += $"{Environment.NewLine}Setor: {obj.s_codigo_setor}";
            informacoes += $"{Environment.NewLine}Valor Solicitado: R${obj.valor.ToString("N2")}";

            switch (obj.status)
            {
                case "Aprovado":
                    informacoes += $"{Environment.NewLine}Status: Aprovado";
                    btnAprovar.Enabled = false;
                    btnRejeitar.Enabled = false;
                    break;
                case "Pendente":
                    informacoes += $"{Environment.NewLine}Status: Pendente";
                    break;
                case "Rejeitado":
                    btnAprovar.Enabled = false;
                    btnRejeitar.Enabled = false;
                    informacoes += $"{Environment.NewLine}Status: Rejeitado";
                    break;
            }

            informacoes += $"{Environment.NewLine}{Environment.NewLine}Item: {obj.s_codigo_produto}";
            informacoes += $"{Environment.NewLine}{Environment.NewLine}Observação/Motivo: {Environment.NewLine}{obj.motivo}";

            txtInformacoes.Text = informacoes;

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
