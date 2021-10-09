using DespesaDigital.Code.BLL.bllFornecedor;
using DespesaDigital.Code.BLL.bllLogSistema;
using DespesaDigital.Code.DTO.dtoFornecedor;
using DespesaDigital.Core;
using System;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Fornecedor
{
    public partial class frmNovoFornecedor : Form
    {
        public frmNovoFornecedor(int codigo_setor)
        {
            InitializeComponent();
            Inicializa();

            if (codigo_setor > 0)
            {
                var bll = bllFornecedor.FornecedoresPorCodigo(codigo_setor);
                txtCodigo.Text = bll.codigo.ToString();
                mskCNPJ.Text = bll.cnpj;
                txtRazaoSocial.Text = bll.razao_social;

                btnSalvar.Enabled = true;
                btnExcluir.Enabled = true;

                mskCNPJ.Enabled = true;
                txtRazaoSocial.Enabled = true;
            }
            else
            {
                btnIncluir.Enabled = true;
            }
        }

        void Inicializa()
        {
            btnIncluir.Enabled = false;
            btnSalvar.Enabled = false;
            btnExcluir.Enabled = false;

            txtCodigo.Enabled = false;
            mskCNPJ.Enabled = false;
            txtRazaoSocial.Enabled = false;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            btnIncluir.Enabled = false;
            btnSalvar.Enabled = true;

            
            mskCNPJ.Mask = "";
            mskCNPJ.Text = "";
            mskCNPJ.Mask = "##.###.###/####-##";

            mskCNPJ.Enabled = true;
            txtRazaoSocial.Enabled = true;

            mskCNPJ.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mskCNPJ.Text) || string.IsNullOrEmpty(txtRazaoSocial.Text))
            {
                corePopUp.exibirMensagem("Preencha todos os campos.", "Atenção");
                return;
            }

            var dto = new dtoFornecedor();
            dto.razao_social = txtRazaoSocial.Text.Trim();
            dto.codigo_departamento = VariaveisGlobais.codigo_departamento;
            dto.cnpj = coreFormat.SemFormatacao(mskCNPJ.Text);

            if (!coreValid.ValidaCnpj(dto.cnpj))
            {
                corePopUp.exibirMensagem("O CNPJ informado é invalido.", "Atenção");
                mskCNPJ.Mask = "";
                mskCNPJ.Text = "";
                mskCNPJ.Mask = "##.###.###/####-##";
                return;
            }

            if (txtCodigo.Text.Length > 0)
            {
                dto.codigo = Convert.ToInt32(txtCodigo.Text);

                if (bllFornecedor.VerificaCNPJAtual(dto.codigo) != dto.cnpj)
                {
                    if (bllFornecedor.VerificaCNPJExistente(dto.cnpj))
                    {
                        corePopUp.exibirMensagem("Já existe um fornecedor com este cnpj.", "Atenção");
                        mskCNPJ.Mask = "";
                        mskCNPJ.Text = "";
                        mskCNPJ.Mask = "##.###.###/####-##";
                        mskCNPJ.Focus();
                        return;
                    }
                }

                if (bllFornecedor.VerificaRazaoSocialAtual(dto.codigo) != dto.razao_social)
                {
                    if (bllFornecedor.VerificaRazaoSocialExistente(dto.razao_social))
                    {
                        corePopUp.exibirMensagem("Já existe um fornecedor com esta razão social.", "Atenção");
                        txtRazaoSocial.Text = "";
                        txtRazaoSocial.Focus();
                        return;
                    }
                }

                if (!bllFornecedor.Update(dto))
                {
                    corePopUp.exibirMensagem("Ocorreu um erro ao salvar o cadastro", "Atenção");
                    return;
                }
                else
                {
                    bllLogSistema.Insert($"Alterou informações do cadastro de fornecedor: [Codigo: [{txtCodigo.Text}] CNPJ: [{mskCNPJ.Text}] Razão Social: [{txtRazaoSocial.Text}]");

                    corePopUp.exibirMensagem("Cadastro salvo com sucesso!", "Atenção");
                    Close();
                    return;
                }
            }
            else
            {
                if (bllFornecedor.VerificaCNPJExistente(dto.cnpj))
                {
                    corePopUp.exibirMensagem("Já existe um fornecedor com este cnpj.", "Atenção");
                    mskCNPJ.Mask = "";
                    mskCNPJ.Text = "";
                    mskCNPJ.Mask = "##.###.###/####-##";
                    mskCNPJ.Focus();
                    return;
                }

                if (bllFornecedor.VerificaRazaoSocialExistente(dto.razao_social))
                {
                    corePopUp.exibirMensagem("Já existe um fornecedor com esta razão social.", "Atenção");
                    txtRazaoSocial.Text = "";
                    txtRazaoSocial.Focus();
                    return;
                }

                if (!bllFornecedor.Insert(dto))
                {
                    corePopUp.exibirMensagem("Ocorreu um erro ao incluir o cadastro", "Atenção");
                    return;
                }
                else
                {
                    bllLogSistema.Insert($"Incluiu um novo fornecedor: CNPJ: [{mskCNPJ.Text}] Razão Social: [{txtRazaoSocial.Text}]");

                    corePopUp.exibirMensagem("Cadastro incluido com sucesso!", "Atenção");
                }
            }


            btnIncluir.Enabled = true;
            btnSalvar.Enabled = false;

            mskCNPJ.Mask = "";
            mskCNPJ.Text = "";
            mskCNPJ.Mask = "##.###.###/####-##";

            txtRazaoSocial.Text = "";

            mskCNPJ.Enabled = true;
            txtRazaoSocial.Enabled = true;

            mskCNPJ.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length == 0)
            {
                corePopUp.exibirMensagem("Para excluir selecione um fornecedor.", "Atenção");
                return;
            }

            if (!corePopUp.exibirPergunta("Atenção:", "Deseja excluir este fornecedor?", 2))
            {
                return;
            }

            if (bllFornecedor.Delete(Convert.ToInt32(txtCodigo.Text)))
            {
                bllLogSistema.Insert($"Exclusão do fornecedor: [Codigo: [{txtCodigo.Text}] CNPJ: [{mskCNPJ.Text}] Razão Social: [{txtRazaoSocial.Text}]");

                corePopUp.exibirMensagem("Fornecedor excluido com sucesso!.", "Atenção");
                Close();
                return;
            }
            else
            {
                corePopUp.exibirMensagem("Não foi possivel excluir o Fornecedor.", "Atenção");
                return;
            }
        }

        private void btnEndereco_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length < 1)
            {
                corePopUp.exibirMensagem("Selecione um fornecedor.", "Atenção");
                return;
            }

            using (var form = new frmEnderecoFornecedor(Convert.ToInt32(txtCodigo.Text)))
            {
                form.ShowDialog();
            }
        }

        private void btnContatos_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length < 1)
            {
                corePopUp.exibirMensagem("Selecione um fornecedor.", "Atenção");
                return;
            }

            using (var form = new frmContatoFornecedor(Convert.ToInt32(txtCodigo.Text)))
            {
                form.ShowDialog();
            }
        }
    }
}
