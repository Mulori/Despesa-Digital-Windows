using DespesaDigital.Code.BLL.bllCategoria;
using DespesaDigital.Code.BLL.bllLogSistema;
using DespesaDigital.Code.DTO.dtoCategoria;
using DespesaDigital.Core;
using System;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Categoria
{
    public partial class frmNovaCategoria : Form
    {
        public int codigo_categoria { get; set; }

        public frmNovaCategoria(int _codigo_categoria)
        {
            InitializeComponent();
            codigo_categoria = _codigo_categoria;
            Inicializa();

            if (codigo_categoria > 0)
            {
                var bll = bllCategoria.CategoriaPorCodigo(codigo_categoria);
                txtCodigo.Text = bll.codigo.ToString();
                txtDescricao.Text = bll.descricao;

                cmbStatus.Text = bll.ativo;

                btnIncluir.Enabled = false;
                btnSalvar.Enabled = true;
                btnExcluir.Enabled = true;

                txtDescricao.Enabled = true;
                cmbStatus.Enabled = true;

                txtDescricao.Focus();
            }
            else
            {
                cmbStatus.Text = "Ativo";
                btnIncluir.Enabled = true;
                btnIncluir.Focus();
            }
        }

        void Inicializa()
        {
            btnIncluir.Enabled = true;
            btnSalvar.Enabled = false;
            btnExcluir.Enabled = false;

            txtCodigo.Enabled = false;
            txtDescricao.Enabled = false;
            cmbStatus.Enabled = false;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            btnIncluir.Enabled = false;
            btnSalvar.Enabled = true;

            txtDescricao.Text = "";

            txtDescricao.Enabled = true;

            txtDescricao.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescricao.Text.Trim()) || string.IsNullOrEmpty(cmbStatus.Text.Trim()))
            {
                corePopUp.exibirMensagem("Preencha todos os campos.", "Atenção");
                return;
            }

            var dto = new dtoCategoria();
            dto.descricao = txtDescricao.Text.Trim();
            dto.codigo_departamento = VariaveisGlobais.codigo_departamento;

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

                dto.codigo = Convert.ToInt32(txtCodigo.Text.Trim());

                if (bllCategoria.VerificaDescricaoAtual(dto.codigo) != txtDescricao.Text.Trim())
                {
                    if (bllCategoria.VerificaDescricaoExistente(txtDescricao.Text.Trim()))
                    {
                        corePopUp.exibirMensagem("Já existe uma categoria com esta descrição.", "Atenção");
                        txtDescricao.Text = "";
                        txtDescricao.Focus();
                        return;
                    }
                }

                if (!bllCategoria.Update(dto))
                {
                    corePopUp.exibirMensagem("Ocorreu um erro ao salvar o cadastro", "Atenção");
                    return;
                }
                else
                {
                    bllLogSistema.Insert($"Alterou informações do cadastro de categoria: [Codigo: [{txtCodigo.Text.Trim()}] Nome: [{txtDescricao.Text.Trim()}] Status: [{cmbStatus.Text.Trim()}]");

                    corePopUp.exibirMensagem("Cadastro salvo com sucesso!", "Atenção");
                    Close();
                    return;
                }
            }
            else
            {
                dto.ativo = "A";

                if (bllCategoria.VerificaDescricaoExistente(txtDescricao.Text.Trim()))
                {
                    corePopUp.exibirMensagem("Já existe uma categoria com esta descrição.", "Atenção");
                    txtDescricao.Text = "";
                    txtDescricao.Focus();
                    return;
                }

                if (!bllCategoria.Insert(dto))
                {
                    corePopUp.exibirMensagem("Ocorreu um erro ao incluir o cadastro", "Atenção");
                    return;
                }
                else
                {
                    bllLogSistema.Insert($"Incluiu uma nova categoria: [Nome: [{txtDescricao.Text.Trim()}]");

                    corePopUp.exibirMensagem("Categoria incluida com sucesso!", "Atenção");
                }
            }


            btnIncluir.Enabled = true;
            btnSalvar.Enabled = false;

            txtDescricao.Text = "";

            cmbStatus.Enabled = false;
            txtDescricao.Enabled = false;
            btnIncluir.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            if (txtCodigo.Text.Length == 0)
            {
                corePopUp.exibirMensagem("Para excluir selecione uma categoria.", "Atenção");
                return;
            }

            if (!corePopUp.exibirPergunta("Atenção:", "Deseja excluir esta categoria?", 2))
            {
                return;
            }

            if (bllCategoria.Delete(Convert.ToInt32(txtCodigo.Text)))
            {
                bllLogSistema.Insert($"Exclusão de categoria: [Codigo: [{txtCodigo.Text}] Descrição: [{txtDescricao.Text}]");

                corePopUp.exibirMensagem("Categoria excluida com sucesso!.", "Atenção");
                Close();
                return;
            }
            else
            {
                corePopUp.exibirMensagem("Não foi possivel excluir a categoria.", "Atenção");
                return;
            }
        }
    }
}
