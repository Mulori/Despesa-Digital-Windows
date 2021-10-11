using DespesaDigital.Code.BLL.bllFormaPagamento;
using DespesaDigital.Code.BLL.bllLogSistema;
using DespesaDigital.Code.DTO.dtoFormaPagamento;
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

namespace DespesaDigital.Views.Forms.FormaPagamento
{
    public partial class frmNovaFormaPagamento : Form
    {
        public int codigo_forma_pagamento { get; set; }

        public frmNovaFormaPagamento(int _codigo_forma_pagamento)
        {
            InitializeComponent();
            codigo_forma_pagamento = _codigo_forma_pagamento;
            Inicializa();

            if (codigo_forma_pagamento > 0)
            {
                var bll = bllFormaPagamento.FormaPagamentoPorCodigo(codigo_forma_pagamento);
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
            }
        }
        void Inicializa()
        {
            btnIncluir.Enabled = false;
            btnSalvar.Enabled = false;
            btnExcluir.Enabled = false;

            txtCodigo.Enabled = false;
            txtDescricao.Enabled = false;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            btnIncluir.Enabled = false;
            btnSalvar.Enabled = true;

            txtDescricao.Text = "";

            txtDescricao.Enabled = true;
            cmbStatus.Enabled = true;

            txtDescricao.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescricao.Text.Trim()) || string.IsNullOrEmpty(cmbStatus.Text.Trim()))
            {
                corePopUp.exibirMensagem("Preencha todos os campos.", "Atenção");
                return;
            }

            var dto = new dtoFormaPagamento();
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

                if (bllFormaPagamento.VerificaDescricaoAtual(dto.codigo) != txtDescricao.Text.Trim())
                {
                    if (bllFormaPagamento.VerificaDescricaoExistente(txtDescricao.Text.Trim()))
                    {
                        corePopUp.exibirMensagem("Já existe uma forma de pagamento com esta descrição.", "Atenção");
                        txtDescricao.Text = "";
                        txtDescricao.Focus();
                        return;
                    }
                }

                if (!bllFormaPagamento.Update(dto))
                {
                    corePopUp.exibirMensagem("Ocorreu um erro ao salvar o cadastro", "Atenção");
                    return;
                }
                else
                {
                    bllLogSistema.Insert($"Alterou informações do cadastro de forma de pagamento: [Codigo: [{txtCodigo.Text.Trim()}] Descrição: [{txtDescricao.Text.Trim()}]");

                    corePopUp.exibirMensagem("Cadastro salvo com sucesso!", "Atenção");
                    Close();
                    return;
                }
            }
            else
            {
                dto.ativo = "A";

                if (bllFormaPagamento.VerificaDescricaoExistente(txtDescricao.Text.Trim()))
                {
                    corePopUp.exibirMensagem("Já existe uma forma de pagamento com esta descrição.", "Atenção");
                    txtDescricao.Text = "";
                    txtDescricao.Focus();
                    return;
                }

                if (!bllFormaPagamento.Insert(dto))
                {
                    corePopUp.exibirMensagem("Ocorreu um erro ao incluir o cadastro", "Atenção");
                    return;
                }
                else
                {
                    bllLogSistema.Insert($"Incluiu uma nova forma de pagamento: [Descrição: [{txtDescricao.Text.Trim()}]");

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
    }
}
