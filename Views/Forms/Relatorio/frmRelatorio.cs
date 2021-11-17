using DespesaDigital.Core;
using DespesaDigital.Views.Forms.Relatorio.Despesa;
using DespesaDigital.Views.Forms.Relatorio.Item;
using DespesaDigital.Views.Forms.Relatorio.Solicitacao;
using DespesaDigital.Views.Forms.Relatorio.Usuario;
using System;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Relatorio
{
    public partial class frmRelatorio : Form
    {
        Form _objForm;

        public frmRelatorio()
        {
            InitializeComponent();

            switch (VariaveisGlobais.nivel_acesso)
            {
                case 1:
                    despesasPorColaboradorToolStripMenuItem.Enabled = true;
                    break;
                case 2:
                    despesasPorColaboradorToolStripMenuItem.Enabled = true;
                    despesasPorCentroDeCustoToolStripMenuItem.Enabled = true;
                    despesasPorCodigoToolStripMenuItem.Enabled = true;
                    relatórioDeSolicitaçõesDeComprasToolStripMenuItem.Enabled = true;
                    relatórioDeColaboradoresCadastradosToolStripMenuItem.Enabled = true;
                    break;
                case 3:
                    despesasPorDepartamentoToolStripMenuItem.Enabled = true;
                    despesasPorColaboradorToolStripMenuItem.Enabled = true;
                    despesasPorCentroDeCustoToolStripMenuItem.Enabled = true;
                    despesasPorCodigoToolStripMenuItem.Enabled = true;
                    relatórioDeSolicitaçõesDeComprasToolStripMenuItem.Enabled = true;
                    relatórioDeColaboradoresCadastradosToolStripMenuItem.Enabled = true;
                    relatórioDeItensMaisAdquiridosToolStripMenuItem.Enabled = true;
                    break;
            }
        }

        private void despesasPorDepartamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _objForm?.Close();

            _objForm = new frmFiltroRelDespesaPorDepartamento
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            panelRelatorio.Controls.Add(_objForm);
            _objForm.Show();
        }

        private void despesasPorColaboradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _objForm?.Close();

            _objForm = new frmFiltroRelDespesaPorColaborador
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            panelRelatorio.Controls.Add(_objForm);
            _objForm.Show();
        }

        private void despesasPorCentroDeCustoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _objForm?.Close();

            _objForm = new frmFiltroRelDespesaPorCentroCusto
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            panelRelatorio.Controls.Add(_objForm);
            _objForm.Show();
        }

        private void despesasPorCodigoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _objForm?.Close();

            _objForm = new frmFiltroRelDespesaPorCodigo
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            panelRelatorio.Controls.Add(_objForm);
            _objForm.Show();
        }

        private void relatórioDeItensMaisAdquiridosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _objForm?.Close();

            _objForm = new frmFiltroRelItensMaisAdquiridos
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            panelRelatorio.Controls.Add(_objForm);
            _objForm.Show();
        }

        private void relatórioDeColaboradoresCadastradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _objForm?.Close();

            _objForm = new frmFiltroRelColaboradoresCadastrados
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            panelRelatorio.Controls.Add(_objForm);
            _objForm.Show();
        }

        private void relatórioDeSolicitaçõesDeComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _objForm?.Close();

            _objForm = new frmFiltroRelSolicitacoesCompra
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            panelRelatorio.Controls.Add(_objForm);
            _objForm.Show();
        }
    }
}
