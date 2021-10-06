using DespesaDigital.Code.BLL.bllCategoria;
using DespesaDigital.Code.BLL.bllFornecedor;
using DespesaDigital.Code.BLL.bllLogSistema;
using DespesaDigital.Code.BLL.bllProduto;
using DespesaDigital.Code.BLL.bllProdutoFornecedor;
using DespesaDigital.Code.BLL.bllSetor;
using DespesaDigital.Code.BLL.bllSetorProduto;
using DespesaDigital.Code.DTO.dtoFornecedor;
using DespesaDigital.Code.DTO.dtoProduto;
using DespesaDigital.Code.DTO.dtoSetor;
using DespesaDigital.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
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

                ////Ativa os setores que o produto esta vinculado
                var listSetor = bllSetorProduto.GetSetoresVinculado(Convert.ToInt32(txtCodigo.Text));
                foreach (var setor in listSetor)
                {
                    int i;
                    for (i = 0; i <= (chklistSetores.Items.Count - 1); i++)
                    {
                        var atributos = chklistSetores.Items[i].ToString().Split('-');

                        if (atributos[1] == setor)
                        {
                            chklistSetores.SetItemChecked(i, true);
                        }
                    }
                }

                ////Ativa os fornecedores que o produto esta vinculado
                var listFornecedor = bllProdutoFornecedor.GetFornecedoresVinculado(Convert.ToInt32(txtCodigo.Text));
                foreach (var fornecedores in listFornecedor)
                {
                    int i;
                    for (i = 0; i <= (chkListFornecedores.Items.Count - 1); i++)
                    {
                        var atributos = chkListFornecedores.Items[i].ToString().Split('-');

                        if (atributos[1] == fornecedores)
                        {
                            chkListFornecedores.SetItemChecked(i, true);
                        }
                    }
                }
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
                var listSetor = bllSetor.ListSetorPorCodigo(VariaveisGlobais.codigo_setor);

                foreach (var setor in listSetor)
                {
                    chklistSetores.Items.Add(setor.codigo + "-" + setor.nome, CheckState.Unchecked);
                }
            }
            else if (VariaveisGlobais.nivel_acesso == 3)
            {
                var listSetor = bllSetor.TodosSetoresPorDepartamento(VariaveisGlobais.codigo_departamento);

                foreach (var setor in listSetor)
                {
                    chklistSetores.Items.Add(setor.codigo + "-" + setor.nome, CheckState.Unchecked);
                }
            }

            var listFornecedor = bllFornecedor.ListarTodosFornecedores();

            foreach (var fornecedor in listFornecedor)
            {
                chkListFornecedores.Items.Add(fornecedor.codigo + "-" + fornecedor.razao_social, CheckState.Unchecked);
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
            if (string.IsNullOrEmpty(txtDescricao.Text) || string.IsNullOrEmpty(cmbCategoria.Text))
            {
                corePopUp.exibirMensagem("Preencha todos os campos.", "Atenção");
                return;
            }

            List<dtoSetor> listSetor = new List<dtoSetor>();
            for (int i = 0; i <= (chklistSetores.Items.Count - 1); i++)
            {
                var atributos = chklistSetores.Items[i].ToString().Split('-');

                if (chklistSetores.GetItemChecked(i))
                {
                    var setor = new dtoSetor();
                    setor.codigo = Convert.ToInt32(atributos[0]);
                    setor.nome = atributos[1];

                    listSetor.Add(setor);
                }

            }

            List<dtoFornecedor> listFornecedor = new List<dtoFornecedor>();
            for (int i = 0; i <= (chkListFornecedores.Items.Count - 1); i++)
            {
                var atributos = chkListFornecedores.Items[i].ToString().Split('-');

                if (chkListFornecedores.GetItemChecked(i))
                {
                    var fornecedor = new dtoFornecedor();
                    fornecedor.codigo = Convert.ToInt32(atributos[0]);
                    fornecedor.razao_social = atributos[1];

                    listFornecedor.Add(fornecedor);
                }
            }


            if (listSetor.Count == 0)
            {
                corePopUp.exibirMensagem("Selecione ao menos um setor!", "Atenção");
                return;
            }

            if (listFornecedor.Count == 0)
            {
                if (!corePopUp.exibirPergunta("Atenção", "Nenhum fornecedor selecionado, deseja continuar a salvar?", 1))
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
                    //Apaga os registros da tabela vinculada entre produto e setor
                    bllSetorProduto.DeleteSetorProduto(Convert.ToInt32(txtCodigo.Text));
                    //Insere novos registro da tabela vinculada entre produto e setor
                    bllSetorProduto.InsertSetorProduto(listSetor, Convert.ToInt32(txtCodigo.Text));

                    //Apaga os registro da tabela vinculada entre produto e fornecedor
                    bllProdutoFornecedor.DeleteSetorProduto(Convert.ToInt32(txtCodigo.Text));
                    //Insere novos registro da tabela vinculada entre produto e setor
                    bllProdutoFornecedor.InsertProdutoFornecedor(listFornecedor, Convert.ToInt32(txtCodigo.Text));

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

                    //Apaga os registros da tabela vinculada entre produto e setor
                    bllSetorProduto.DeleteSetorProduto(codigo_produto);
                    //Insere novos registro da tabela vinculada entre produto e setor
                    bllSetorProduto.InsertSetorProduto(listSetor, codigo_produto);

                    //Apaga os registro da tabela vinculada entre produto e fornecedor
                    bllProdutoFornecedor.DeleteSetorProduto(codigo_produto);
                    //Insere novos registro da tabela vinculada entre produto e setor
                    bllProdutoFornecedor.InsertProdutoFornecedor(listFornecedor, codigo_produto);

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

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            btnIncluir.Enabled = false;
            btnSalvar.Enabled = true;

            txtDescricao.Text = "";

            txtDescricao.Enabled = true;
            cmbCategoria.Enabled = true;

            txtDescricao.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length == 0)
            {
                corePopUp.exibirMensagem("Para excluir selecione um produto.", "Atenção");
                return;
            }

            if (!corePopUp.exibirPergunta("Atenção:", "Deseja excluir este produto?", 2))
            {
                return;
            }

            //Apaga os registros da tabela vinculada entre produto e setor
            if (bllSetorProduto.DeleteSetorProduto(Convert.ToInt32(txtCodigo.Text)))
            {
                //Apaga os registro da tabela vinculada entre produto e fornecedor
                if (bllProdutoFornecedor.DeleteSetorProduto(Convert.ToInt32(txtCodigo.Text)))
                {
                    if (bllProduto.Delete(Convert.ToInt32(txtCodigo.Text)))
                    {

                        bllLogSistema.Insert($"Exclusão do produto: [Codigo: [{txtCodigo.Text}] Descrição: [{txtDescricao.Text}] Categoria: [{cmbCategoria.Text}]");

                        corePopUp.exibirMensagem("Produto excluido com sucesso!.", "Atenção");
                        Close();
                        return;
                    }
                    else
                    {
                        corePopUp.exibirMensagem("Não foi possivel excluir o produto.", "Atenção");
                        return;
                    }

                }
                else
                {
                    corePopUp.exibirMensagem("Não foi possivel excluir o produto.", "Atenção");
                    return;
                }
            }
            else
            {
                corePopUp.exibirMensagem("Não foi possivel excluir o produto.", "Atenção");
                return;
            }

        }
    }
}
