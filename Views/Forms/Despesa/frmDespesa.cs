using DespesaDigital.Code.DAL.dalConexao;
using DespesaDigital.Code.DAL.dalDespesa;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Despesa
{
    public partial class frmDespesa : Form
    {
        public frmDespesa()
        {
            InitializeComponent();
        }

        private void btnVisualizarDespesas_Click(object sender, EventArgs e)
        {
            using (var form = new frmPesquisarDespesa())
            {
                form.ShowDialog();
            }
        }

        private void btnNovaDespesa_Click(object sender, EventArgs e)
        {
            using (var form = new frmNovaDespesa())
            {
                form.ShowDialog();
            }
        }
    }
}
