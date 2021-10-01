using DespesaDigital.Code.BLL.bllDepartamento;
using DespesaDigital.Code.BLL.bllSetor;
using DespesaDigital.Code.DTO.dtoComponentes;
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

            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            foreach (var item in list)
            {
                comboSource.Add($"{item.codigo}", $"{item.nome}");
            }

            cmbDepartamento.DataSource = new BindingSource(comboSource, null);
            cmbDepartamento.DisplayMember = "Value";
            cmbDepartamento.ValueMember = "Key";
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = ((KeyValuePair<string, string>)cmbDepartamento.SelectedItem).Key;
            //string value = ((KeyValuePair<string, string>)cmbDepartamento.SelectedItem).Value;

            cmbSetor.Items.Clear();

            var list = bllSetor.TodosSetoresPorDepartamento(Convert.ToInt32(key));
            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            foreach (var item in list)
            {
                comboSource.Add($"{item.codigo}", $"{item.nome}");
            }

            cmbSetor.DataSource = new BindingSource(comboSource, null);
            cmbSetor.DisplayMember = "Value";
            cmbSetor.ValueMember = "Key";
        }
    }
}
