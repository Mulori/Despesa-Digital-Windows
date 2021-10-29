using DespesaDigital.Code.BLL.bllDespesa;
using System;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Despesa
{
    public partial class frmDetalheDespesa : Form
    {
        public static long codigo_despesa_ {get;set;}

        public frmDetalheDespesa(long _codigo_despesa)
        {
            InitializeComponent();
            codigo_despesa_ = _codigo_despesa;

            Inicializa();
        }

        private void Inicializa()
        {
            var despesa = bllDespesa.DespesaPorCodigo(codigo_despesa_);
            txtCodigo.Text = despesa.codigo.ToString();
            mskData.Text = despesa.data_hora_emissao.ToString("dd/MM/yyyy HH:mm:ss");
            txtValor.Text = Convert.ToDouble(despesa.valor).ToString("N2");
            cmbFormaPagamento.Text = despesa.s_codigo_forma_pagamento;
            cmbTipoDespesa.Text = despesa.s_codigo_tipo_despesa;
            txtCentroCusto.Text = despesa.s_codigo_setor;
            txtColaborador.Text = despesa.s_codigo_usuario;
            txtDescricao.Text = despesa.descricao;

            dataGrid.DataSource = bllDespesaItens.ListarTodoProdutoDespesaPorCodigo(codigo_despesa_);
        }

        private void btnImagem_Click_1(object sender, EventArgs e)
        {
            using (var form = new frmImagemDespesa(Convert.ToInt64(txtCodigo.Text)))
            {
                form.ShowDialog();
            }
        }
    }
}
