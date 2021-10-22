using DespesaDigital.Code.BLL.bllDepartamento;
using DespesaDigital.Code.BLL.bllLogSistema;
using DespesaDigital.Code.DTO.dtoDepartamento;
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

namespace DespesaDigital.Views.Forms.Departamento
{
    public partial class frmNovoDepartamento : Form
    {
        public frmNovoDepartamento(int codigo_departamento)
        {
            InitializeComponent();
            Inicializa();

            if (codigo_departamento > 0)
            {
                var bll = bllDepartamento.DepartamentoPorCodigo(codigo_departamento);
                txtCodigo.Text = bll.codigo.ToString();
                txtNome.Text = bll.nome;
                txtDescricao.Text = bll.descricao;

                btnSalvar.Enabled = true;
                btnExcluir.Enabled = true;

                txtNome.Enabled = true;
                txtDescricao.Enabled = true;
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
            txtNome.Enabled = false;
            txtDescricao.Enabled = false;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            btnIncluir.Enabled = false;
            btnSalvar.Enabled = true;

            txtNome.Text = "";
            txtDescricao.Text = "";

            txtNome.Enabled = true;
            txtDescricao.Enabled = true;

            txtNome.Focus();
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDescricao.Focus();
            }
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Focus();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text.Trim()) || string.IsNullOrEmpty(txtDescricao.Text.Trim()))
            {
                corePopUp.exibirMensagem("Preencha todos os campos.", "Atenção");
                return;
            }

            var dto = new dtoDepartamento();
            dto.nome = txtNome.Text.Trim();
            dto.descricao = txtDescricao.Text.Trim();

            if (txtCodigo.Text.Length > 0)
            {
                dto.codigo = Convert.ToInt32(txtCodigo.Text.Trim());

                if (bllDepartamento.VerificaNomeAtual(dto.codigo) != txtNome.Text.Trim())
                {
                    if (bllDepartamento.VerificaNomeExistente(txtNome.Text.Trim()))
                    {
                        corePopUp.exibirMensagem("Já existe um departamento com este nome.", "Atenção");
                        txtNome.Text = "";
                        txtNome.Focus();
                        return;
                    }
                }

                if (!bllDepartamento.Update(dto))
                {
                    corePopUp.exibirMensagem("Ocorreu um erro ao salvar o cadastro", "Atenção");
                    return;
                }
                else
                {
                    bllLogSistema.Insert($"Alterou informações do cadastro de departamento: [Codigo: [{txtCodigo.Text.Trim()}] Nome: [{txtNome.Text.Trim()}] Descrição: [{txtDescricao.Text.Trim()}]");

                    corePopUp.exibirMensagem("Cadastro salvo com sucesso!", "Atenção");
                    Close();
                    return;
                }
            }
            else
            {
                if (bllDepartamento.VerificaNomeExistente(txtNome.Text.Trim()))
                {
                    corePopUp.exibirMensagem("Já existe um departamento com este nome.", "Atenção");
                    txtNome.Text = "";
                    txtNome.Focus();
                    return;
                }

                if (!bllDepartamento.Insert(dto))
                {
                    corePopUp.exibirMensagem("Ocorreu um erro ao incluir o cadastro", "Atenção");
                    return;
                }
                else
                {
                    bllLogSistema.Insert($"Incluiu um novo departamento: [Nome: [{txtNome.Text.Trim()}] Descrição: [{txtDescricao.Text.Trim()}]");

                    corePopUp.exibirMensagem("Cadastro incluido com sucesso!", "Atenção");
                }
            }


            btnIncluir.Enabled = true;
            btnSalvar.Enabled = false;

            txtNome.Text = "";
            txtDescricao.Text = "";

            txtDescricao.Enabled = false;
            txtNome.Enabled = false;
            btnIncluir.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length == 0)
            {
                corePopUp.exibirMensagem("Para excluir selecione um departamento.", "Atenção");
                return;
            }

            if (!corePopUp.exibirPergunta("Atenção:", "Deseja excluir este departamento?", 2))
            {
                return;
            }

            if (bllDepartamento.Delete(Convert.ToInt32(txtCodigo.Text)))
            {
                bllLogSistema.Insert($"Exclusão do departamento: [Codigo: [{txtCodigo.Text.Trim()}] Nome: [{txtNome.Text.Trim()}] Descrição: [{txtDescricao.Text.Trim()}]");

                corePopUp.exibirMensagem("Departamento excluido com sucesso!.", "Atenção");
                Close();
                return;
            }
            else
            {
                corePopUp.exibirMensagem("Não foi possivel excluir o departamento.", "Atenção");
                return;
            }
        }
    }
}
