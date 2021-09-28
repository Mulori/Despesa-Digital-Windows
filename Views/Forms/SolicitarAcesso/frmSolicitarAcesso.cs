using DespesaDigital.Code.BLL.bllDepartamento;
using DespesaDigital.Code.BLL.bllSetor;
using DespesaDigital.Code.DTO.dtoDepartamento;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.SolicitarAcesso
{
    public partial class frmSolicitarAcesso : Form
    {
        public frmSolicitarAcesso()
        {
            InitializeComponent();
            CarregaDepartamento();
        }

        void CarregaDepartamento()
        {
            var list = bllDepartamento.TodosDepartamentos();

            foreach (var item in list)
            {
                cmbDepartamento.Items.Add(item.nome);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSetor.Items.Clear();

            var list = bllSetor.TodosSetoresPorDepartamento(cmbDepartamento.Text);
            foreach (var setor in list)
            {
                cmbSetor.Items.Add(setor.nome);
            }
        }
    }
}
