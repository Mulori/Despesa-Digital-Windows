using DespesaDigital.Code.BLL;
using DespesaDigital.Code.BLL.bllDepartamento;
using DespesaDigital.Code.BLL.bllSetor;
using DespesaDigital.Code.BLL.bllUsuarioAprovacao;
using DespesaDigital.Code.DTO;
using DespesaDigital.Core;
using DespesaDigital.Views.Forms.Mensagens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Usuario
{
    public partial class frmEditarUsuario : Form
    {
        public frmEditarUsuario(int codigo_usuario)
        {
            InitializeComponent();
            CarregaCombos();
            CarregaDepartamento();
            CarregarUsuario(codigo_usuario);
        }

        void CarregaDepartamento()
        {
            var list = bllDepartamento.TodosDepartamentos();

            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            foreach (var item in list)
            {
                comboSource.Add($"{item.codigo}", $"{item.nome}");
            }

            cmbDepartamento.DataSource = new BindingSource(comboSource, null);
            cmbDepartamento.DisplayMember = "Value";
            cmbDepartamento.ValueMember = "Key";
        }

        void CarregaCombos()
        {
            if(VariaveisGlobais.nivel_acesso == 2)
            {
                cmbNivel.Items.Add("Tecnico");
                cmbNivel.Items.Add("Supervisor");

                cmbDepartamento.Enabled = false;
                cmbSetor.Enabled = false;
            }
            else if(VariaveisGlobais.nivel_acesso == 3)
            {
                cmbNivel.Items.Add("Tecnico");
                cmbNivel.Items.Add("Supervisor");
                cmbNivel.Items.Add("Gestor");
            }
        }

        void CarregarUsuario(int codigo)
        {
            var bll = bllUsuario.UsuarioPorCodigo(codigo);

            if(bll.ativo == "Pendente")
            {
                txtCodigo.Enabled = false;
                txtNome.Enabled = false;
                txtSobrenome.Enabled = false;
                txtEmail.Enabled = false;
                cmbDepartamento.Enabled = false;
                cmbSetor.Enabled = false;

                cmbStatus.Items.Add("Aceitar");
                cmbStatus.Items.Add("Recusar");
            }
            else if(bll.ativo == "Ativo" || bll.ativo == "Inativo")
            {
                cmbStatus.Items.Add("Ativo");
                cmbStatus.Items.Add("Inativo");

                cmbStatus.Text = bll.ativo;
            }

            txtCodigo.Text = bll.codigo.ToString();
            txtNome.Text = bll.nome;
            txtSobrenome.Text = bll.sobrenome;
            txtEmail.Text = bll.email;
            cmbNivel.Text = bll.s_nivel_acesso;
            
            cmbDepartamento.Text = bll.nome_departamento;
            cmbSetor.Text = bll.nome_setor;

            SendKeys.Send("{F4}");
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var dto = new dtoUsuario();            

            if (cmbStatus.Text == "Recusar")
            {
                if (!corePopUp.exibirPergunta("Atenção", "Tem certeza que deseja recusar o usuário?", 1))
                {
                    return;
                }

                if (bllUsuarioAprovacao.Delete(Convert.ToInt32(txtCodigo.Text)))
                {
                    if (bllUsuario.Delete(Convert.ToInt32(txtCodigo.Text)))
                    {
                        corePopUp.exibirMensagem("Usuário rejeitado com sucesso!", "Atenção");
                        Close();
                        return;
                    }
                }
            }

            if (string.IsNullOrEmpty(cmbNivel.Text))
            {
                corePopUp.exibirMensagem("Selecione o nivel de acesso do usuário!", "Atenção");
                return;
            }

            if (string.IsNullOrEmpty(cmbStatus.Text))
            {
                corePopUp.exibirMensagem("Selecione o status do cadastro.", "Atenção");
                return;
            }

            switch (cmbNivel.Text)
            {
                case "Tecnico":
                    dto.nivel_acesso = 1;
                    break;
                case "Supervisor":
                    dto.nivel_acesso = 2;
                    break;
                case "Gestor":
                    dto.nivel_acesso = 3;
                    break;
            }

            if (cmbStatus.Text == "Aceitar")
            {
                if (!corePopUp.exibirPergunta("Atenção", "Tem certeza que deseja aceitar o usuário?", 1))
                {
                    return;
                }

                if (bllUsuario.UpdateAceitar(Convert.ToInt32(txtCodigo.Text), dto.nivel_acesso))
                {
                    corePopUp.exibirMensagem("Usuário aprovado com sucesso!", "Atenção");
                    Close();
                    return;
                }
            }

            dto.codigo = Convert.ToInt32(txtCodigo.Text);
            dto.nome = txtNome.Text;
            dto.sobrenome = txtSobrenome.Text;

            if (string.IsNullOrEmpty(dto.nome))
            {
                corePopUp.exibirMensagem("Informe o nome do usuário!", "Atenção");
                return;
            }

            if (string.IsNullOrEmpty(dto.sobrenome))
            {
                corePopUp.exibirMensagem("Informe o sobrenome do usuário!", "Atenção");
                return;
            }            

            if (string.IsNullOrEmpty(cmbDepartamento.Text))
            {
                corePopUp.exibirMensagem("Selecione o departamento do usuário!", "Atenção");
                return;
            }

            if (string.IsNullOrEmpty(cmbSetor.Text))
            {
                corePopUp.exibirMensagem("Selecione o setor do usuário!", "Atenção");
                return;
            }            

            switch (cmbStatus.Text)
            {
                case "Ativo":
                    dto.ativo = "A";
                    break;
                case "Pendente":
                    dto.ativo = "P";
                    break;
                case "Inativo":
                    dto.ativo = "I";
                    break;
            }

            dto.codigo_setor = Convert.ToInt32(((KeyValuePair<string, string>)cmbSetor.SelectedItem).Key);

            if (!corePopUp.exibirPergunta("Atenção:", "Deseja salvar esse cadastro?", 1))
            {
                return;
            }

            if (bllUsuario.Update(dto))
            {
                corePopUp.exibirMensagem("Usuário alterado com sucesso.", "Atenção");
                Close();
                return;
            }
            else
            {
                corePopUp.exibirMensagem("Ocorreu um erro ao alterar o usuário!", "Atenção");
            }

        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = ((KeyValuePair<string, string>)cmbDepartamento.SelectedItem).Key;

            cmbSetor.DataSource = null;

            var list = bllSetor.TodosSetoresPorDepartamento(Convert.ToInt32(key));
            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            foreach (var item in list)
            {
                comboSource.Add($"{item.codigo}", $"{item.nome}");
            }

            cmbSetor.DataSource = new BindingSource(comboSource, null);
            cmbSetor.DisplayMember = "Value";
            cmbSetor.ValueMember = "Key";
        }
    }
}
