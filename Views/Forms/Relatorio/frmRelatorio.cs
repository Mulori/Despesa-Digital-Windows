using DespesaDigital.Views.Forms.Relatorio.Despesa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
