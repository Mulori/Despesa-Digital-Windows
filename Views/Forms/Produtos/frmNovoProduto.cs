using DespesaDigital.Code.BLL.bllCategoria;
using DespesaDigital.Code.BLL.bllProduto;
using DespesaDigital.Code.BLL.bllSetor;
using DespesaDigital.Code.DTO.dtoSetor;
using DespesaDigital.Core;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Produtos
{
    public partial class frmNovoProduto : Form
    {
        public frmNovoProduto(int codigo_produto)
        {
            InitializeComponent();
            Inicializar();

            if (codigo_produto > 0)
            {
                var bll = bllProduto.ProdutoPorCodigo(codigo_produto);
                txtCodigo.Text = bll.codigo.ToString();
                txtDescricao.Text = bll.descricao;

                cmbCategoria.Text = bll.s_codigo_categoria;

                btnSalvar.Enabled = true;
                btnExcluir.Enabled = true;

                txtDescricao.Enabled = true;
                cmbCategoria.Enabled = true;
            }
            else
            {
                btnIncluir.Enabled = true;
            }
        }

        void Inicializar()
        {
            btnIncluir.Enabled = false;
            btnSalvar.Enabled = false;
            btnExcluir.Enabled = false;

            txtCodigo.Enabled = false;
            txtDescricao.Enabled = false;
            cmbCategoria.Enabled = false;

            if (VariaveisGlobais.nivel_acesso == 2)
            {
                dataGrid.DataSource = bllSetor.ListSetorPorCodigo(VariaveisGlobais.codigo_setor);
            }
            else if (VariaveisGlobais.nivel_acesso == 3)
            {
                dataGrid.DataSource = bllSetor.TodosSetoresPorDepartamento(VariaveisGlobais.codigo_departamento);
            }

            var list = bllCategoria.ListarTodasCategoriasPorStatus("A");

            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            foreach (var item in list)
            {
                comboSource.Add($"{item.codigo}", $"{item.descricao}");
            }
            cmbCategoria.DataSource = new BindingSource(comboSource, null);
            cmbCategoria.DisplayMember = "Value";
            cmbCategoria.ValueMember = "Key";
        }

        private void btnSalvar_Click(object sender, System.EventArgs e)
        {
            List<dtoSetor> listSetor = new List<dtoSetor>();
            List<DataGridViewRow> rows_with_checked_column = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    var dto = new dtoSetor();
                    dto.codigo = Convert.ToInt32(row.Cells[1].Value);
                    dto.nome = row.Cells[2].Value.ToString();

                    listSetor.Add(dto);
                }
            }
        }
    }
}
