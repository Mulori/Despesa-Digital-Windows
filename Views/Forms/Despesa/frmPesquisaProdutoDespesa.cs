using DespesaDigital.Code.BLL.bllProduto;
using DespesaDigital.Code.DTO.dtoModal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Despesa
{
    public partial class frmPesquisaProdutoDespesa : Form
    {
        public static string _texto { get; set; }
        public List<dtoModalCheckListBox> listReturn = new List<dtoModalCheckListBox>();

        public frmPesquisaProdutoDespesa(string texto)
        {
            InitializeComponent();
            _texto = texto;
            txtPesquisa.Text = texto;

            if(Text.Length > 0) {
                dataGrid.DataSource = bllProduto.ListarTodosProdutosPorStatusDescricao("A", txtPesquisa.Text);
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            dataGrid.DataSource = bllProduto.ListarTodosProdutosPorStatusDescricao("A", txtPesquisa.Text);
        }

        private void dataGrid_DoubleClick(object sender, EventArgs e)
        {
            if (dataGrid.RowCount == 0)
            {
                return;
            }

            var codigo = Convert.ToInt32(dataGrid.CurrentRow.Cells[0].Value.ToString());
            var descricao = dataGrid.CurrentRow.Cells[1].Value.ToString();

            var dto = new dtoModalCheckListBox();
            dto.codigo = codigo;
            dto.descricao = descricao;

            listReturn.Add(dto);
            Close();
        }
    }
}
