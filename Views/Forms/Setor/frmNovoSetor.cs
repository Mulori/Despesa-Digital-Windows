using DespesaDigital.Code.BLL.bllDepartamento;
using DespesaDigital.Code.BLL.bllLogSistema;
using DespesaDigital.Code.BLL.bllSetor;
using DespesaDigital.Code.DTO.dtoDepartamento;
using DespesaDigital.Code.DTO.dtoSetor;
using DespesaDigital.Core;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Setor
{
    public partial class frmNovoSetor : Form
    {
        public frmNovoSetor(int codigo_setor)
        {
            InitializeComponent();
            Inicializa();

            if (codigo_setor > 0)
            {
                var bll = bllSetor.SetorPorCodigo(codigo_setor);
                txtCodigo.Text = bll.codigo.ToString();
                txtNome.Text = bll.nome;
                txtCodCentroCusto.Text = bll.codigo_centro_custo;

                cmbDepartamento.Text = bll.s_departamento;

                btnSalvar.Enabled = true;
                btnExcluir.Enabled = true;

                txtNome.Enabled = true;
                txtCodCentroCusto.Enabled = true;
                cmbDepartamento.Enabled = true;
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
            txtCodCentroCusto.Enabled = false;
            cmbDepartamento.Enabled = false;

            List<dtoDepartamento> list;

            if (VariaveisGlobais.nivel_acesso > 2)
            {
                list = bllDepartamento.TodosDepartamentos();
            }
            else
            {
                list = bllDepartamento.DepartamentoPorSetor(VariaveisGlobais.codigo_setor);
            }            

            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            foreach (var item in list)
            {
                comboSource.Add($"{item.codigo}", $"{item.nome}");
            }

            cmbDepartamento.DataSource = new BindingSource(comboSource, null);
            cmbDepartamento.DisplayMember = "Value";
            cmbDepartamento.ValueMember = "Key";
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            btnIncluir.Enabled = false;
            btnSalvar.Enabled = true;

            txtNome.Text = "";

            txtNome.Enabled = true;
            txtCodCentroCusto.Enabled = true;
            cmbDepartamento.Enabled = true;

            txtNome.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text.Trim()) || string.IsNullOrEmpty(cmbDepartamento.Text.Trim()))
            {
                corePopUp.exibirMensagem("Preencha todos os campos.", "Atenção");
                return;
            }

            var dto = new dtoSetor();
            dto.nome = txtNome.Text.Trim();
            dto.codigo_departamento = Convert.ToInt32(((KeyValuePair<string, string>)cmbDepartamento.SelectedItem).Key);
            dto.codigo_centro_custo = txtCodCentroCusto.Text.Trim();

            if (txtCodigo.Text.Length > 0)
            {
                dto.codigo = Convert.ToInt32(txtCodigo.Text.Trim());

                if (bllSetor.VerificaNomeAtual(dto.codigo) != txtNome.Text.Trim())
                {
                    if (bllSetor.VerificaNomeExistente(txtNome.Text.Trim()))
                    {
                        corePopUp.exibirMensagem("Já existe um setor com este nome.", "Atenção");
                        txtNome.Text = "";
                        txtNome.Focus();
                        return;
                    }
                }

                if (bllSetor.VerificaCentroCustoAtual(dto.codigo) != txtCodCentroCusto.Text.Trim())
                {
                    if (bllSetor.VerificaCentroCustoExistente(txtCodCentroCusto.Text.Trim()))
                    {
                        corePopUp.exibirMensagem("Já existe um setor com este centro de custo.", "Atenção");
                        txtCodCentroCusto.Text = "";
                        txtCodCentroCusto.Focus();
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
                if (bllSetor.VerificaNomeExistente(txtNome.Text.Trim()))
                {
                    corePopUp.exibirMensagem("Já existe um setor com este nome.", "Atenção");
                    txtNome.Text = "";
                    txtNome.Focus();
                    return;
                }

                if (bllSetor.VerificaCentroCustoExistente(txtCodCentroCusto.Text.Trim()))
                {
                    corePopUp.exibirMensagem("Já existe um setor com este centro de custo.", "Atenção");
                    txtCodCentroCusto.Text = "";
                    txtCodCentroCusto.Focus();
                    return;
                }

                if (!bllSetor.Insert(dto))
                {
                    corePopUp.exibirMensagem("Ocorreu um erro ao incluir o cadastro", "Atenção");
                    return;
                }
                else
                {
                    bllLogSistema.Insert($"Incluiu um novo departamento: [Nome: [{txtNome.Text.Trim()}] Departamento: [{cmbDepartamento.Text}]");

                    corePopUp.exibirMensagem("Cadastro incluido com sucesso!", "Atenção");
                }
            }


            btnIncluir.Enabled = true;
            btnSalvar.Enabled = false;

            txtNome.Text = "";
            txtCodCentroCusto.Text = "";

            cmbDepartamento.Enabled = false;
            txtCodCentroCusto.Enabled = false;
            txtNome.Enabled = false;
            btnIncluir.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length == 0)
            {
                corePopUp.exibirMensagem("Para excluir selecione um setor.", "Atenção");
                return;
            }

            if (!corePopUp.exibirPergunta("Atenção:", "Deseja excluir este setor?", 2))
            {
                return;
            }

            if (bllSetor.Delete(Convert.ToInt32(txtCodigo.Text)))
            {
                bllLogSistema.Insert($"Exclusão do setor: [Codigo: [{txtCodigo.Text}] Nome: [{txtNome}] Departamento: [{cmbDepartamento.Text}]");

                corePopUp.exibirMensagem("Setor excluido com sucesso!.", "Atenção");
                Close();
                return;
            }
            else
            {
                corePopUp.exibirMensagem("Não foi possivel excluir o setor.", "Atenção");
                return;
            }
        }
    }
}
