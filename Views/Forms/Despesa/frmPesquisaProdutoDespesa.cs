using DespesaDigital.Code.BLL.bllProduto;
using DespesaDigital.Code.DTO.dtoModal;
using DespesaDigital.Code.DTO.dtoProduto;
using DespesaDigital.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
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
                var list = bllProduto.ListarTodosProdutosPorStatusDescricao("A", txtPesquisa.Text.Trim());
                dataGrid.DataSource = list;
                if (list.Count == 0)
                {
                    btnIncluir.Visible = true;
                    txtPesquisa.Size = new Size(634, 27);
                }
                else
                {
                    btnIncluir.Visible = false;
                    txtPesquisa.Size = new Size(781, 27);
                }
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            var list = bllProduto.ListarTodosProdutosPorStatusDescricao("A", txtPesquisa.Text.Trim());

            dataGrid.DataSource = list;

            if (list.Count == 0)
            {
                btnIncluir.Visible = true;
                txtPesquisa.Size = new Size(634, 27);                
            }
            else
            {
                btnIncluir.Visible = false;
                txtPesquisa.Size = new Size(781, 27);               
            }
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

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            var novo_produto = bllProduto.NovoProdutoRapido(txtPesquisa.Text.Trim(), VariaveisGlobais.codigo_setor);

            if (novo_produto > 0)
            {
                var dto = new dtoModalCheckListBox();
                dto.codigo = novo_produto;
                dto.descricao = txtPesquisa.Text.Trim();

                listReturn.Add(dto);
                Close();

                Close();
            }
            else
            {
                corePopUp.exibirMensagem("Não foi possivel cadastrar esse item no banco de dados.", "Atenção");
                return;
            }
        }
    }
}
