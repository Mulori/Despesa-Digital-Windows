using DespesaDigital.Code.BLL.bllCategoria;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
