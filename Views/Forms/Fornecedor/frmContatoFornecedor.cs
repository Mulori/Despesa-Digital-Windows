using DespesaDigital.Code.BLL.bllFornecedor;
using DespesaDigital.Code.BLL.bllLogSistema;
using DespesaDigital.Code.DTO.dtoFornecedor;
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

namespace DespesaDigital.Views.Forms.Fornecedor
{
    public partial class frmContatoFornecedor : Form
    {
        private int codigo_fornecedor_ { get; set; }
        private int codigo_contato { get; set; }

        public frmContatoFornecedor(int _codigo_fornecedor)
        {
            InitializeComponent();
            codigo_fornecedor_ = _codigo_fornecedor;
            Inicializar();
        }
        void Inicializar()
        {
            mskContato.Enabled = false;

            mskContato.Text = "";

            btnSalvar.Enabled = false;
            btnExcluir.Enabled = false;
            btnIncluir.Enabled = true;
            btnIncluir.Focus();

            codigo_contato = 0;

            dataGrid.DataSource = bllFornecedorContato.TodosContatoFornecedorCodigo(codigo_fornecedor_);
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            mskContato.Enabled = true;
            
            mskContato.Text = "";

            btnSalvar.Enabled = true;
            btnExcluir.Enabled = true;
            btnIncluir.Enabled = false;

            codigo_contato = 0;

            mskContato.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mskContato.Text))
            {
                corePopUp.exibirMensagem("Preencha o campo Telefone/Celular.", "Atenção");
                return;
            }

            var dto = new dtoFornecedorContato();
            dto.codigo_fornecedor = codigo_fornecedor_;
            dto.telefone_celular = mskContato.Text.Trim();

            if (codigo_contato > 0) //Alteração
            {
                dto.codigo = codigo_contato;

                if (!bllFornecedorContato.Update(dto))
                {
                    corePopUp.exibirMensagem("Ocorreu um erro ao salvar o cadastro", "Atenção");
                    return;
                }
                else
                {
                    bllLogSistema.Insert($"Alterou informações do cadastro de contatos para o fornecedor de codigo[{codigo_fornecedor}] Telefone/Celular: [{mskContato.Text}]");

                    corePopUp.exibirMensagem("Cadastro salvo com sucesso!", "Atenção");
                }
            }
            else //Inclusão
            {
                if (!bllFornecedorContato.Insert(dto))
                {
                    corePopUp.exibirMensagem("Ocorreu um erro ao incluir o cadastro", "Atenção");
                    return;
                }
                else
                {
                    bllLogSistema.Insert($"Incluiu um novo contato para o fornecedor de codigo[{codigo_fornecedor}] Telefone/Celular: [{mskContato.Text}]");

                    corePopUp.exibirMensagem("Cadastro incluido com sucesso!", "Atenção");
                }
            }

            Inicializar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (codigo_contato < 1)
            {
                corePopUp.exibirMensagem("Para excluir selecione um contato.", "Atenção");
                return;
            }

            if (!corePopUp.exibirPergunta("Atenção:", "Deseja excluir este contato?", 2))
            {
                return;
            }

            if (bllFornecedorContato.Delete(codigo_contato, codigo_fornecedor_))
            {
                bllLogSistema.Insert($"Exclusão do contato: codigo:[{codigo_contato}] codigo fornecedor:[{codigo_fornecedor}] Telefone/Celular: [{mskContato.Text}]");

                corePopUp.exibirMensagem("Contato excluido com sucesso!.", "Atenção");
            }
            else
            {
                corePopUp.exibirMensagem("Não foi possivel excluir o contato.", "Atenção");
                return;
            }

            Inicializar();
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var codigo = Convert.ToInt32(dataGrid.CurrentRow.Cells[0].Value.ToString());

            var dto = bllFornecedorContato.ContatoCodigo(codigo);

            mskContato.Text = dto.telefone_celular;

            codigo_contato = dto.codigo;

            mskContato.Enabled = true;

            btnSalvar.Enabled = true;
            btnExcluir.Enabled = true;
            btnIncluir.Enabled = false;
        }
    }
}
