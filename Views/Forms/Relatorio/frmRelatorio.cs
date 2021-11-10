using DespesaDigital.Views.Forms.Relatorio.Despesa;
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
    }
}
