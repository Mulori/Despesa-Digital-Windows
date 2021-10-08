using DespesaDigital.Code.BLL.bllFornecedor;
using DespesaDigital.Code.BLL.bllLogSistema;
using DespesaDigital.Code.DTO.dtoFornecedor;
using DespesaDigital.Core;
using System;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Fornecedor
{
    public partial class frmEnderecoFornecedor : Form
    {
        private int codigo_fornecedor_ { get; set; }
        private int codigo_endereco { get; set; }

        public frmEnderecoFornecedor(int _codigo_fornecedor)
        {
            InitializeComponent();
            codigo_fornecedor_ = _codigo_fornecedor;
            Inicializar();
        }

        void Inicializar()
        {
            cmbEstado.Enabled = false;
            txtCidade.Enabled = false;
            txtBairro.Enabled = false;
            txtLogradouro.Enabled = false;
            mskCep.Enabled = false;

            txtCidade.Text = "";
            txtBairro.Text = "";
            txtLogradouro.Text = "";
            mskCep.Text = "";

            btnSalvar.Enabled = false;
            btnExcluir.Enabled = false;
            btnIncluir.Enabled = true;
            btnIncluir.Focus();

            codigo_endereco = 0;

            dataGrid.DataSource = bllFornecedorEndereco.TodosEnderecoFornecedorCodigo(codigo_fornecedor_);
        }

        private void btnSalvar_Click(object sender, System.EventArgs e)
        {
            if(string.IsNullOrEmpty(cmbEstado.Text) 
                || string.IsNullOrEmpty(txtCidade.Text) || string.IsNullOrEmpty(txtLogradouro.Text) 
                    || string.IsNullOrEmpty(txtBairro.Text) || string.IsNullOrEmpty(mskCep.Text))
            {
                corePopUp.exibirMensagem("Preencha todos os campos.", "Atenção");
                return;
            }

            var dto = new dtoFornecedorEndereco();
            dto.codigo_fornecedor = codigo_fornecedor_;
            dto.logradouro = txtLogradouro.Text.Trim();
            dto.bairro = txtBairro.Text.Trim();
            dto.cidade = txtCidade.Text.Trim();
            dto.estado = cmbEstado.Text;
            dto.pais = "Brasil";
            dto.cep = mskCep.Text.Replace("-", string.Empty);

            if(codigo_endereco > 0) //Alteração
            {
                dto.codigo = codigo_endereco;

                if (!bllFornecedorEndereco.Update(dto))
                {
                    corePopUp.exibirMensagem("Ocorreu um erro ao salvar o cadastro", "Atenção");
                    return;
                }
                else
                {
                    bllLogSistema.Insert($"Alterou informações do cadastro de endereço para o fornecedor de codigo[{codigo_fornecedor}] Logradouro: [{txtLogradouro.Text}] Cidade: [{txtCidade.Text}]");

                    corePopUp.exibirMensagem("Cadastro salvo com sucesso!", "Atenção");
                }
            }
            else //Inclusão
            {
                if (!bllFornecedorEndereco.Insert(dto))
                {
                    corePopUp.exibirMensagem("Ocorreu um erro ao incluir o cadastro", "Atenção");
                    return;
                }
                else
                {
                    bllLogSistema.Insert($"Incluiu um novo endereço para o fornecedor de codigo[{codigo_fornecedor}] Logradouro: [{txtLogradouro.Text}] Cidade: [{txtCidade.Text}]");

                    corePopUp.exibirMensagem("Cadastro incluido com sucesso!", "Atenção");
                }
            }

            Inicializar();
        }

        private void btnExcluir_Click(object sender, System.EventArgs e)
        {
            if (codigo_endereco < 1)
            {
                corePopUp.exibirMensagem("Para excluir selecione um endereço.", "Atenção");
                return;
            }

            if (!corePopUp.exibirPergunta("Atenção:", "Deseja excluir este endereço?", 2))
            {
                return;
            }

            if (bllFornecedorEndereco.Delete(codigo_endereco, codigo_fornecedor_))
            {
                bllLogSistema.Insert($"Exclusão do endereço: codigo:[{codigo_endereco}] codigo fornecedor:[{codigo_fornecedor}] Logradouro: [{txtLogradouro.Text}] Cidade: [{txtCidade.Text}]");

                corePopUp.exibirMensagem("Endereço excluido com sucesso!.", "Atenção");
            }
            else
            {
                corePopUp.exibirMensagem("Não foi possivel excluir o endereço.", "Atenção");
                return;
            }

            Inicializar();
        }

        private void btnIncluir_Click(object sender, System.EventArgs e)
        {
            cmbEstado.Enabled = true;
            txtCidade.Enabled = true;
            txtBairro.Enabled = true;
            txtLogradouro.Enabled = true;
            mskCep.Enabled = true;

            txtCidade.Text = "";
            txtBairro.Text = "";
            txtLogradouro.Text = "";
            mskCep.Text = "";

            btnSalvar.Enabled = true;
            btnExcluir.Enabled = true;
            btnIncluir.Enabled = false;

            codigo_endereco = 0;

            cmbEstado.Focus();
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var codigo = Convert.ToInt32(dataGrid.CurrentRow.Cells[1].Value.ToString());

            var dto = bllFornecedorEndereco.EnderecoCodigo(codigo);

            txtCidade.Text = dto.cidade;
            txtLogradouro.Text = dto.logradouro;
            txtBairro.Text = dto.bairro;
            cmbEstado.Text = dto.estado;
            mskCep.Text = dto.cep;

            codigo_endereco = dto.codigo;

            cmbEstado.Enabled = true;
            txtCidade.Enabled = true;
            txtBairro.Enabled = true;
            txtLogradouro.Enabled = true;
            mskCep.Enabled = true;

            btnSalvar.Enabled = true;
            btnExcluir.Enabled = true;
            btnIncluir.Enabled = false;
        }
    }
}
