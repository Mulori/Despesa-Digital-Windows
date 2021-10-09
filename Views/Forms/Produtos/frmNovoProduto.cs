using DespesaDigital.Code.BLL.bllCategoria;
using DespesaDigital.Code.BLL.bllLogSistema;
using DespesaDigital.Code.BLL.bllProduto;
using DespesaDigital.Code.BLL.bllProdutoFornecedor;
using DespesaDigital.Code.BLL.bllSetorProduto;
using DespesaDigital.Code.DTO.dtoFornecedor;
using DespesaDigital.Code.DTO.dtoModal;
using DespesaDigital.Code.DTO.dtoProduto;
using DespesaDigital.Code.DTO.dtoSetor;
using DespesaDigital.Core;
using DespesaDigital.Views.Forms.Modais;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Produtos
{
    public partial class frmNovoProduto : Form
    {
        private List<dtoModalCheckListBox> listSetores = new List<dtoModalCheckListBox>();
        private List<dtoModalCheckListBox> listSetoresBackup = new List<dtoModalCheckListBox>();
        private List<dtoModalCheckListBox> listFornecedores = new List<dtoModalCheckListBox>();
        private List<dtoModalCheckListBox> listFornecedoresBackup = new List<dtoModalCheckListBox>();

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

                var listSetor = bllSetorProduto.SetorProdutoPorCodigoProduto(bll.codigo);
                var listSetorCheckBox = new List<dtoModalCheckListBox>();

                foreach(var setor in listSetor)
                {
                    var dto = new dtoModalCheckListBox();
                    dto.codigo = setor.codigo;
                    dto.descricao = setor.nome;
                    listSetorCheckBox.Add(dto);
                }

                CarregaListaSetores(listSetorCheckBox);
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

            var list = bllCategoria.ListarTodasCategoriasPorStatus("A");

            Dictionary<string, string> comboSource = new Dictionary<string, string>();
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

        private void btnSalvar_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescricao.Text.Trim()) || string.IsNullOrEmpty(cmbCategoria.Text.Trim()))
            {
                corePopUp.exibirMensagem("Preencha todos os campos.", "Atenção");
                return;
            }

            List<dtoSetor> listSetor = new List<dtoSetor>();
            for (int i = 0; i <= (chkListSetores.Items.Count - 1); i++)
            {
                var atributos = chkListSetores.Items[i].ToString().Replace("[", "").Replace("]", "").Split(',');

                if (chkListSetores.GetItemChecked(i))
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
                var atributos = chkListFornecedores.Items[i].ToString().Replace("[", "").Replace("]", "").Split(',');

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
            dto.descricao = txtDescricao.Text.Trim();
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

        private void btnVinculaFornecedores_Click(object sender, EventArgs e)
        {
            using (var form = new frmModalCheckBoxList(2))
            {
                form.ShowDialog();

                listFornecedores = form.listReturn;
                CarregaListaFornecedores(listFornecedores);
            }
        }

        private void btnVinculaSetores_Click(object sender, EventArgs e)
        {
            using (var form = new frmModalCheckBoxList(1))
            {
                form.ShowDialog();

                listSetores = form.listReturn;
                CarregaListaSetores(listSetores);
            }
        }


        private void chkListSetores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var codigo = 0;
                var descricao = "";
                for (int i = 0; i <= (chkListSetores.Items.Count - 1); i++)
                {
                    var atributos = chkListSetores.Items[i].ToString().Replace("[", "").Replace("]", "").Split(',');

                    if (chkListSetores.GetSelected(i))
                    {
                        codigo = Convert.ToInt32(atributos[0]);
                        descricao = atributos[1].ToString();
                    }
                }

                if (codigo < 1)
                {
                    corePopUp.exibirMensagem("Não foi possivel encontrar o setor.", "Atenção");
                    return;
                }

                if (!corePopUp.exibirPergunta("Atenção", $"Deseja remover a vinculação com o setor: \n{descricao}?", 2))
                {
                    return;
                }

                int it = 0;
                foreach (var item in chkListSetores.Items)
                {
                    if (chkListSetores.GetSelected(it))
                    {
                        if (listSetoresBackup.Count > 0)
                        {
                            listSetoresBackup.RemoveAt(it);
                            CarregaListaSetores(listSetoresBackup);
                        }
                        else
                        {
                            listSetores.RemoveAt(it);
                            CarregaListaSetores(listSetores);
                        }

                        break;
                    }

                    it++;
                }
            }
        }

        void CarregaListaSetores(List<dtoModalCheckListBox> list)
        {
            var listSetoresBackupTemp = new List<dtoModalCheckListBox>();
            Dictionary<string, string> comboSource = new Dictionary<string, string>();

            if (listSetoresBackup.Count > 0) //Valida no backup quais itens ja estão para inserir sómente alguns
            {
                foreach (var new_item in list)
                {
                    bool insere_lista = true;

                    foreach (var item in listSetoresBackup)
                    {
                        if (new_item.codigo == item.codigo)
                        {
                            insere_lista = false;
                            break;
                        }
                    }

                    if (insere_lista)
                    {
                        comboSource.Add($"{new_item.codigo}", $"{new_item.descricao}");

                        var dtoModalTemp = new dtoModalCheckListBox();
                        dtoModalTemp.codigo = new_item.codigo;
                        dtoModalTemp.descricao = new_item.descricao;

                        listSetoresBackupTemp.Add(dtoModalTemp);
                    }
                }

                foreach (var item in listSetoresBackup)
                {
                    comboSource.Add($"{item.codigo}", $"{item.descricao}");

                    var dtoModalTemp = new dtoModalCheckListBox();
                    dtoModalTemp.codigo = item.codigo;
                    dtoModalTemp.descricao = item.descricao;

                    listSetoresBackupTemp.Add(dtoModalTemp);
                }
            }
            else //Percorre normalmente 
            {
                foreach (var item in list)
                {
                    comboSource.Add($"{item.codigo}", $"{item.descricao}");

                    var dtoModalTemp = new dtoModalCheckListBox();
                    dtoModalTemp.codigo = item.codigo;
                    dtoModalTemp.descricao = item.descricao;

                    listSetoresBackupTemp.Add(dtoModalTemp);
                }
            }

            listSetoresBackup = listSetoresBackupTemp;
            listSetoresBackupTemp = null;

            if (comboSource.Count > 0)
            {
                chkListSetores.DataSource = new BindingSource(comboSource, null);
                chkListSetores.DisplayMember = "Value";
                chkListSetores.ValueMember = "Key";

                for (int i = 0; i < chkListSetores.Items.Count; i++)
                {
                    chkListSetores.SetItemChecked(i, true);
                }
            }
        }

        void CarregaListaFornecedores(List<dtoModalCheckListBox> list)
        {
            var listFornecedoresBackupTemp = new List<dtoModalCheckListBox>();
            Dictionary<string, string> comboSource = new Dictionary<string, string>();

            if (listFornecedoresBackup.Count > 0) 
            {
                foreach (var new_item in list)
                {
                    bool insere_lista = true;

                    foreach (var item in listFornecedoresBackup)
                    {
                        if (new_item.codigo == item.codigo)
                        {
                            insere_lista = false;
                            break;
                        }
                    }

                    if (insere_lista)
                    {
                        comboSource.Add($"{new_item.codigo}", $"{new_item.descricao}");

                        var dtoModalTemp = new dtoModalCheckListBox();
                        dtoModalTemp.codigo = new_item.codigo;
                        dtoModalTemp.descricao = new_item.descricao;

                        listFornecedoresBackupTemp.Add(dtoModalTemp);
                    }
                }

                foreach (var item in listFornecedoresBackup)
                {
                    comboSource.Add($"{item.codigo}", $"{item.descricao}");

                    var dtoModalTemp = new dtoModalCheckListBox();
                    dtoModalTemp.codigo = item.codigo;
                    dtoModalTemp.descricao = item.descricao;

                    listFornecedoresBackupTemp.Add(dtoModalTemp);
                }
            }
            else //Percorre normalmente 
            {
                foreach (var item in list)
                {
                    comboSource.Add($"{item.codigo}", $"{item.descricao}");

                    var dtoModalTemp = new dtoModalCheckListBox();
                    dtoModalTemp.codigo = item.codigo;
                    dtoModalTemp.descricao = item.descricao;

                    listFornecedoresBackupTemp.Add(dtoModalTemp);
                }
            }

            listFornecedoresBackup = listFornecedoresBackupTemp;
            listFornecedoresBackupTemp = null;

            if (comboSource.Count > 0)
            {              
                chkListFornecedores.DataSource = new BindingSource(comboSource, null);
                chkListFornecedores.DisplayMember = "Value";
                chkListFornecedores.ValueMember = "Key";

                for (int i = 0; i < chkListFornecedores.Items.Count; i++)
                {
                    chkListFornecedores.SetItemChecked(i, true);
                }
            }
        }

        private void chkListFornecedores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var codigo = 0;
                var descricao = "";
                for (int i = 0; i <= (chkListFornecedores.Items.Count - 1); i++)
                {
                    var atributos = chkListFornecedores.Items[i].ToString().Replace("[", "").Replace("]", "").Split(',');

                    if (chkListFornecedores.GetSelected(i))
                    {
                        codigo = Convert.ToInt32(atributos[0]);
                        descricao = atributos[1].ToString();
                    }
                }

                if (codigo < 1)
                {
                    corePopUp.exibirMensagem("Não foi possivel encontrar o fornecedor.", "Atenção");
                    return;
                }

                if (!corePopUp.exibirPergunta("Atenção", $"Deseja remover a vinculação com o fornecedor: \n{descricao}?", 2))
                {
                    return;
                }

                int it = 0;
                foreach (var item in chkListFornecedores.Items)
                {
                    if (chkListFornecedores.GetSelected(it))
                    {
                        if (listFornecedoresBackup.Count > 0)
                        {
                            listFornecedoresBackup.RemoveAt(it);
                            CarregaListaFornecedores(listFornecedoresBackup);
                        }
                        else
                        {
                            listFornecedores.RemoveAt(it);
                            CarregaListaFornecedores(listFornecedores);
                        }

                        break;
                    }

                    it++;
                }
            }
        }
    }
}
