using DespesaDigital.Views.Forms.Ferramentas.LogSistema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Ferramentas
{
    public partial class frmFerramentasPrincipal : Form
    {
        Form _objForm;

        public frmFerramentasPrincipal()
        {
            InitializeComponent();
        }

        private void despesasPorCodigoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _objForm?.Close();

            _objForm = new frmLogSistema
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            panelFerramentas.Controls.Add(_objForm);
            _objForm.Show();
        }
    }
}
