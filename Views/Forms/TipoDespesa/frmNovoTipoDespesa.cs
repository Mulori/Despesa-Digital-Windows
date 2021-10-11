using DespesaDigital.Code.BLL.bllLogSistema;
using DespesaDigital.Code.BLL.bllTipoDespesa;
using DespesaDigital.Code.DTO.dtoTipoDespesa;
using DespesaDigital.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.TipoDespesa
{
    public partial class frmNovoTipoDespesa : Form
    {
        public int codigo_forma_pagamento { get; set; }
        public frmNovoTipoDespesa(int _codigo_forma_pagamento)
        {
            InitializeComponent();
            codigo_forma_pagamento = _codigo_forma_pagamento;
            Inicializa();

            if (codigo_forma_pagamento > 0)
            {
                var bll = bllTipoDespesa.TipoDespesaPorCodigo(codigo_forma_pagamento);
                txtCodigo.Text = bll.codigo.ToString();
                txtDescricao.Text = bll.descricao;
                cmbStatus.Text = bll.ativo;

                btnSalvar.Enabled = true;
                btnExcluir.Enabled = true;

                txtDescricao.Enabled = true;
                cmbStatus.Enabled = true;
            }
            else
            {
                btnIncluir.Enabled = true;
                cmbStatus.Text = "Ativo";
            }
        }

        void Inicializa()
        {
            btnIncluir.Enabled = false;
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

            var dto = new dtoTipoDespesa();
            dto.descricao = txtDescricao.Text.Trim();

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

                if (bllTipoDespesa.VerificaDescricaoAtual(dto.codigo) != txtDescricao.Text.Trim())
                {
                    if (bllTipoDespesa.VerificaDescricaoExistente(txtDescricao.Text.Trim()))
                    {
                        corePopUp.exibirMensagem("Já existe um tipo de despesa com esta descrição.", "Atenção");
                        txtDescricao.Text = "";
                        txtDescricao.Focus();
                        return;
                    }
                }

                if (!bllTipoDespesa.Update(dto))
                {
                    corePopUp.exibirMensagem("Ocorreu um erro ao salvar o cadastro", "Atenção");
                    return;
                }
                else
                {
                    bllLogSistema.Insert($"Alterou informações do cadastro de tipo de despesa: [Codigo: [{txtCodigo.Text.Trim()}] Descrição: [{txtDescricao.Text.Trim()}]");

                    corePopUp.exibirMensagem("Cadastro salvo com sucesso!", "Atenção");
                    Close();
                    return;
                }
            }
            else
            {
                dto.ativo = "A";

                if (bllTipoDespesa.VerificaDescricaoExistente(txtDescricao.Text.Trim()))
                {
                    corePopUp.exibirMensagem("Já existe um tipo de despesa com esta descrição.", "Atenção");
                    txtDescricao.Text = "";
                    txtDescricao.Focus();
                    return;
                }

                if (!bllTipoDespesa.Insert(dto))
                {
                    corePopUp.exibirMensagem("Ocorreu um erro ao incluir o cadastro", "Atenção");
                    return;
                }
                else
                {
                    bllLogSistema.Insert($"Incluiu um novo tipo de despesa: [Descrição: [{txtDescricao.Text.Trim()}]");

                    corePopUp.exibirMensagem("Cadastro incluido com sucesso!", "Atenção");
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
                corePopUp.exibirMensagem("Para excluir selecione um tipo de despesa.", "Atenção");
                return;
            }

            if (!corePopUp.exibirPergunta("Atenção:", "Deseja excluir este tipo de despesa?", 2))
            {
                return;
            }

            if (bllTipoDespesa.Delete(Convert.ToInt32(txtCodigo.Text)))
            {
                bllLogSistema.Insert($"Exclusão de tipo de despesa: [Codigo: [{txtCodigo.Text}] Descrição: [{txtDescricao.Text}] ");

                corePopUp.exibirMensagem("Tipo de despesa excluido com sucesso!.", "Atenção");
                Close();
                return;
            }
            else
            {
                corePopUp.exibirMensagem("Não foi possivel excluir o tipo de despesa.", "Atenção");
                return;
            }
        }
    }
}
