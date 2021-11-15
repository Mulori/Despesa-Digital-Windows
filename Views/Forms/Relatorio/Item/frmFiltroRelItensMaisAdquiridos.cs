using DespesaDigital.Code.BLL.bllCategoria;
using DespesaDigital.Report.rptItem;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Relatorio.Item
{
    public partial class frmFiltroRelItensMaisAdquiridos : Form
    {
        public frmFiltroRelItensMaisAdquiridos()
        {
            InitializeComponent();
            Inicializar();
        }

        void Inicializar()
        {
            var list = bllCategoria.ListarTodasCategoriasPorStatus("A");

            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            comboSource.Add($"-1", $"Todas");
            foreach (var item in list)
            {
                comboSource.Add($"{item.codigo}", $"{item.descricao}");
            }

            if (list.Count > 0)
            {
                cmbCategoria.DataSource = new BindingSource(comboSource, null);
                cmbCategoria.DisplayMember = "Value";
                cmbCategoria.ValueMember = "Key";
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            var codigo_categoria = Convert.ToInt32(((KeyValuePair<string, string>)cmbCategoria.SelectedItem).Key);

            using (var rel = new frmRelItensMaisAdquiridos(codigo_categoria))
            {
                rel.ShowDialog();
            }
        }
    }
}
