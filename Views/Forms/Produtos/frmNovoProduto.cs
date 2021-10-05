using DespesaDigital.Code.BLL.bllCategoria;
using DespesaDigital.Code.BLL.bllFornecedor;
using DespesaDigital.Code.BLL.bllLogSistema;
using DespesaDigital.Code.BLL.bllProduto;
using DespesaDigital.Code.BLL.bllSetor;
using DespesaDigital.Code.BLL.bllSetorProduto;
using DespesaDigital.Code.DTO.dtoFornecedor;
using DespesaDigital.Code.DTO.dtoProduto;
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
                cmbStatus.Text = bll.ativo;

                btnSalvar.Enabled = true;
                btnExcluir.Enabled = true;

                txtDescricao.Enabled = true;
                cmbCategoria.Enabled = true;
                cmbStatus.Enabled = true;

                //Ativa os setores que o produto esta vinculado
                var listSetor = bllSetorProduto.GetSetoresVinculado(Convert.ToInt32(txtCodigo.Text));
                foreach(var setor in listSetor)
                {
                    foreach (DataGridViewRow row in dataGrid.Rows)
                    {
                        if (row.Cells[2].Value.ToString() == setor)
                        {
                            row.Cells[0].Value = 1;

                        }
                    }
                }
                listSetor = null;
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
            cmbStatus.Enabled = false;

            if (VariaveisGlobais.nivel_acesso == 2)
            {
                dataGrid.DataSource = bllSetor.ListSetorPorCodigo(VariaveisGlobais.codigo_setor);
            }
            else if (VariaveisGlobais.nivel_acesso == 3)
            {
                dataGrid.DataSource = bllSetor.TodosSetoresPorDepartamento(VariaveisGlobais.codigo_departamento);
            }

            dataGrid2.DataSource = bllFornecedor.ListarTodosFornecedores();

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
            if (string.IsNullOrEmpty(txtDescricao.Text) || string.IsNullOrEmpty(cmbCategoria.Text))
            {
                corePopUp.exibirMensagem("Preencha todos os campos.", "Atenção");
                return;
            }

            List<dtoSetor> listSetor = new List<dtoSetor>();
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    var dtoSetor = new dtoSetor();
                    dtoSetor.codigo = Convert.ToInt32(row.Cells[1].Value);
                    dtoSetor.nome = row.Cells[2].Value.ToString();

                    listSetor.Add(dtoSetor);
                }
            }

            List<dtoFornecedor> listFornecedor = new List<dtoFornecedor>();
            foreach (DataGridViewRow row in dataGrid2.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    var dtoFornecedor = new dtoFornecedor();
                    dtoFornecedor.codigo = Convert.ToInt32(row.Cells[1].Value);
                    dtoFornecedor.razao_social = row.Cells[2].Value.ToString();

                    listFornecedor.Add(dtoFornecedor);
                }
            }

            if(listSetor.Count == 0)
            {
                corePopUp.exibirMensagem("Selecione ao menos um setor!", "Atenção");
                return;
            }

            if (listFornecedor.Count == 0)
            {
                if(!corePopUp.exibirPergunta("Atenção", "Nenhum fornecedor selecionado, deseja continuar a salvar?", 1))
                {
                    return;
                }
            }

            var dto = new dtoProduto();
            dto.descricao = txtDescricao.Text;
            dto.codigo_categoria = Convert.ToInt32(((KeyValuePair<string, string>)cmbCategoria.SelectedItem).Key);

            if (txtCodigo.Text.Length > 0)
            {
                switch (cmbStatus.Text)
                {
                    case "Ativo":
                        dto.ativo = "A";
                        break;
                    case "Inativo":
                        dto.ativo = "I";
                        break;
                    default:
                        dto.ativo = "A";
                        break;
                }

                dto.codigo = Convert.ToInt32(txtCodigo.Text);

                if (!bllProduto.Update(dto))
                {
                    corePopUp.exibirMensagem("Ocorreu um erro ao salvar o cadastro", "Atenção");
                    return;
                }
                else
                {
                    bllSetorProduto.DeleteSetorProduto(Convert.ToInt32(txtCodigo.Text));
                    bllSetorProduto.InsertSetorProduto(listSetor, Convert.ToInt32(txtCodigo.Text));

                    bllLogSistema.Insert($"Alterou informações do cadastro de produto: [Codigo: [{txtCodigo.Text}] Descricao: [{txtDescricao.Text}] Categoria: [{cmbCategoria.Text}]");

                    corePopUp.exibirMensagem("Cadastro salvo com sucesso!", "Atenção");
                    Close();
                    return;
                }
            }
            else
            {
                dto.ativo = "A";

                if (bllProduto.VerificaNomeExistente(txtDescricao.Text))
                {
                    corePopUp.exibirMensagem("Já existe um produto com esta descrição.", "Atenção");
                    txtDescricao.Text = "";
                    txtDescricao.Focus();
                    return;
                }

                if (!bllProduto.Insert(dto))
                {
                    corePopUp.exibirMensagem("Ocorreu um erro ao incluir o cadastro", "Atenção");
                    return;
                }
                else
                {
                    var codigo_produto = bllProduto.PegarUltimoCodigo();

                    bllSetorProduto.DeleteSetorProduto(codigo_produto);
                    bllSetorProduto.InsertSetorProduto(listSetor, codigo_produto);

                    bllLogSistema.Insert($"Incluiu um novo produto: [Nome: [{txtDescricao.Text}] Categoria: [{cmbCategoria.Text}]");

                    corePopUp.exibirMensagem("Cadastro incluido com sucesso!", "Atenção");
                }
            }


            btnIncluir.Enabled = true;
            btnSalvar.Enabled = false;

            txtDescricao.Text = "";

            cmbCategoria.Enabled = false;
            cmbStatus.Enabled = false;

            txtDescricao.Enabled = false;
            btnIncluir.Focus();
        }

        private void txtPesquisaSetores_Enter(object sender, EventArgs e)
        {
            txtPesquisaSetores.Text = "";
        }

        private void txtFornecedores_Enter(object sender, EventArgs e)
        {
            txtFornecedores.Text = "";
        }

        private void txtPesquisaSetores_Leave(object sender, EventArgs e)
        {
            txtPesquisaSetores.Text = "Pesquise por nome...";            
        }

        private void txtFornecedores_Leave(object sender, EventArgs e)
        {
            txtFornecedores.Text = "Pesquise por Razão Social...";
        }

        private void txtPesquisaSetores_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dataGrid.DataSource = bllSetor.ListSetorPorNome(txtPesquisaSetores.Text);
            }
        }

        private void txtFornecedores_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dataGrid2.DataSource = bllFornecedor.ListarTodosFornecedoresPorRazaoSocial(txtFornecedores.Text);
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            btnIncluir.Enabled = false;
            btnSalvar.Enabled = true;

            txtDescricao.Text = "";

            txtDescricao.Enabled = true;
            cmbCategoria.Enabled = true;

            txtDescricao.Focus();
        }
    }
}
