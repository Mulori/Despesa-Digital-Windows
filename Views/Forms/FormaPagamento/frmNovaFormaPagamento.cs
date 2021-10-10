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

                if (bllSetor.VerificaCentroCustoAtual(dto.codigo) != txtDescricao.Text.Trim())
                {
                    if (bllSetor.VerificaCentroCustoExistente(txtDescricao.Text.Trim()))
                    {
                        corePopUp.exibirMensagem("Já existe um setor com este centro de custo.", "Atenção");
                        txtDescricao.Text = "";
                        txtDescricao.Focus();
                        return;
                    }
                }

                if (!bllSetor.Update(dto))
                {
                    corePopUp.exibirMensagem("Ocorreu um erro ao salvar o cadastro", "Atenção");
                    return;
                }
                else
                {
                    bllLogSistema.Insert($"Alterou informações do cadastro de setor: [Codigo: [{txtCodigo.Text.Trim()}] Nome: [{txtNome.Text.Trim()}] Departamento: [{cmbDepartamento.Text.Trim()}]");

                    corePopUp.exibirMensagem("Cadastro salvo com sucesso!", "Atenção");
                    Close();
                    return;
                }
            }
            else
            {
                if (bllSetor.VerificaNomeExistente(txtDescricao.Text.Trim()))
                {
                    corePopUp.exibirMensagem("Já existe um setor com este nome.", "Atenção");
                    txtDescricao.Text = "";
                    txtDescricao.Focus();
                    return;
                }

                if (bllSetor.VerificaCentroCustoExistente(txtDescricao.Text.Trim()))
                {
                    corePopUp.exibirMensagem("Já existe um setor com este centro de custo.", "Atenção");
                    txtDescricao.Text = "";
                    txtDescricao.Focus();
                    return;
                }

                if (!bllSetor.Insert(dto))
                {
                    corePopUp.exibirMensagem("Ocorreu um erro ao incluir o cadastro", "Atenção");
                    return;
                }
                else
                {
                    bllLogSistema.Insert($"Incluiu um novo departamento: [Descrição: [{txtDescricao.Text.Trim()}]");

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
