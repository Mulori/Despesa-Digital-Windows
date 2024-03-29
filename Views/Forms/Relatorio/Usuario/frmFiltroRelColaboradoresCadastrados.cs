﻿using DespesaDigital.Code.BLL.bllSetor;
using DespesaDigital.Code.DTO.dtoSetor;
using DespesaDigital.Core;
using DespesaDigital.Report.rptUsuario;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Relatorio.Usuario
{
    public partial class frmFiltroRelColaboradoresCadastrados : Form
    {
        public frmFiltroRelColaboradoresCadastrados()
        {
            InitializeComponent();
            List<dtoSetor> list;
            if (VariaveisGlobais.nivel_acesso > 2)
            {
                list = bllSetor.TodosSetoresPorDepartamento(VariaveisGlobais.codigo_departamento);
            }
            else
            {
                cmbSetor.Enabled = false;
                list = bllSetor.ListSetorPorCodigo(VariaveisGlobais.codigo_setor);
            }
            CarregaListaSetores(list);
            CarregaListaStatus();
            CarregaListaNivelAcesso();

        }
        void CarregaListaNivelAcesso()
        {
            Dictionary<string, string> comboSource = new Dictionary<string, string>();

            comboSource.Add($"-1", $"Todos");
            comboSource.Add($"1", $"Técnico");
            comboSource.Add($"2", $"Supervisor");
            comboSource.Add($"3", $"Gestor");

            cmbNivelAcesso.DataSource = new BindingSource(comboSource, null);
            cmbNivelAcesso.DisplayMember = "Value";
            cmbNivelAcesso.ValueMember = "Key";
        }

        void CarregaListaStatus()
        {
            Dictionary<string, string> comboSource = new Dictionary<string, string>();

            comboSource.Add($"T", $"Ambos");
            comboSource.Add($"A", $"Ativo");
            comboSource.Add($"I", $"Inativo");

            cmbStatus.DataSource = new BindingSource(comboSource, null);
            cmbStatus.DisplayMember = "Value";
            cmbStatus.ValueMember = "Key";
        }

        void CarregaListaSetores(List<dtoSetor> list)
        {
            Dictionary<string, string> comboSource = new Dictionary<string, string>();

            if (VariaveisGlobais.nivel_acesso > 2)
            {
                comboSource.Add($"-1", $"Todos");
            }

            foreach (var item in list)
            {
                comboSource.Add($"{item.codigo}", $"{item.nome}");
            }

            cmbSetor.DataSource = new BindingSource(comboSource, null);
            cmbSetor.DisplayMember = "Value";
            cmbSetor.ValueMember = "Key";
        }

        private void btnVisualizar_Click(object sender, System.EventArgs e)
        {
            var codigo_setor = Convert.ToInt32(((KeyValuePair<string, string>)cmbSetor.SelectedItem).Key);
            var codigo_nivel_acesso = Convert.ToInt32(((KeyValuePair<string, string>)cmbNivelAcesso.SelectedItem).Key);
            var codigo_status = ((KeyValuePair<string, string>)cmbStatus.SelectedItem).Key;

            using (var rel = new frmRelColaboradoresCadastrados(codigo_setor, codigo_status, codigo_nivel_acesso))
            {
                rel.ShowDialog();
            }
        }
    }
}
