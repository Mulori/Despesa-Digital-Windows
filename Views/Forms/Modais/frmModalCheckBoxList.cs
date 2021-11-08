using DespesaDigital.Code.BLL.bllFornecedor;
using DespesaDigital.Code.BLL.bllSetor;
using DespesaDigital.Code.DTO.dtoModal;
using DespesaDigital.Code.DTO.dtoSetor;
using DespesaDigital.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Modais
{
    public partial class frmModalCheckBoxList : Form
    {
        /*
         * 1 - Lista Setores do Departamento Pertencente
         * 2 - Lista Todos os Fornecedores
         * 
         * 
         */

        private bool mouseDown;
        private Point lastLocation;
        public List<dtoModalCheckListBox> listReturn = new List<dtoModalCheckListBox>();
        private int codigo_funcao { get; set; }


        public frmModalCheckBoxList(int _codigo_funcao)
        {
            InitializeComponent();
            codigo_funcao = _codigo_funcao;
            Inicializar();

            txtPesquisa.Focus();
        }

        void Inicializar()
        {
            //Valida para qual entidade deve funcionar
            switch (codigo_funcao)
            {
                case 1: //Listar Setores do Departamento Pertencente

                    List<dtoSetor> listSetor = new List<dtoSetor>();

                    if (VariaveisGlobais.nivel_acesso == 2)
                    {
                        listSetor = bllSetor.ListSetorPorCodigo(VariaveisGlobais.codigo_setor);
                    }
                    else if (VariaveisGlobais.nivel_acesso == 3)
                    {
                        listSetor = bllSetor.TodosSetoresPorDepartamento(VariaveisGlobais.codigo_departamento);
                    }

                    if (listSetor.Count == 0)
                    {
                        corePopUp.exibirMensagem("Nenhum setor cadastrado para este departamento", "Atenção");
                        return;
                    }

                    Dictionary<string, string> comboSourceSetor = new Dictionary<string, string>();
                    foreach (var item in listSetor)
                    {
                        comboSourceSetor.Add($"{item.codigo}", $"{item.nome}");
                    }
                    checkList.DataSource = new BindingSource(comboSourceSetor, null);
                    checkList.DisplayMember = "Value";
                    checkList.ValueMember = "Key";

                    break;
                case 2: //Lista Todos os Fornecedores

                    var listFornecedor = bllFornecedor.ListarTodosFornecedores();

                    if(listFornecedor.Count == 0)
                    {
                        corePopUp.exibirMensagem("Nenhum fornecedor cadastrado para este departamento", "Atenção");
                        return;
                    }

                    Dictionary<string, string> comboSourceFornecedor = new Dictionary<string, string>();
                    foreach (var item in listFornecedor)
                    {
                        comboSourceFornecedor.Add($"{item.codigo}", $"{item.cnpj}  {item.razao_social}");
                    }
                    checkList.DataSource = new BindingSource(comboSourceFornecedor, null);
                    checkList.DisplayMember = "Value";
                    checkList.ValueMember = "Key";

                    break;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmModalCheckBoxList_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void frmModalCheckBoxList_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void frmModalCheckBoxList_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void btnPronto_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= (checkList.Items.Count - 1); i++)
            {
                var atributos = checkList.Items[i].ToString().Replace("[", "").Replace("]", "").Split(',');

                if (checkList.GetItemChecked(i))
                {
                    var dto = new dtoModalCheckListBox();
                    dto.codigo = Convert.ToInt32(atributos[0]);
                    dto.descricao = atributos[1].ToString().Trim();

                    listReturn.Add(dto);
                }
            }

            this.Close();
        }

        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                //Valida para qual entidade deve funcionar
                switch (codigo_funcao)
                {
                    case 1: //Listar Setores do Departamento Pertencente

                        List<dtoSetor> listSetor = new List<dtoSetor>();

                        listSetor = bllSetor.ListSetorPorNome(txtPesquisa.Text);

                        if (listSetor.Count == 0)
                        {
                            return;
                        }

                        Dictionary<string, string> comboSourceSetor = new Dictionary<string, string>();
                        foreach (var item in listSetor)
                        {
                            comboSourceSetor.Add($"{item.codigo}", $"{item.nome}");
                        }
                        checkList.DataSource = new BindingSource(comboSourceSetor, null);
                        checkList.DisplayMember = "Value";
                        checkList.ValueMember = "Key";

                        break;
                    case 2: //Lista Todos os Fornecedores

                        var listFornecedor = bllFornecedor.ListarTodosFornecedoresPorRazaoSocial(txtPesquisa.Text);

                        if (listFornecedor.Count == 0)
                        {
                            return;
                        }

                        Dictionary<string, string> comboSourceFornecedor = new Dictionary<string, string>();
                        foreach (var item in listFornecedor)
                        {
                            comboSourceFornecedor.Add($"{item.codigo}", $"{item.cnpj}  {item.razao_social}");
                        }
                        checkList.DataSource = new BindingSource(comboSourceFornecedor, null);
                        checkList.DisplayMember = "Value";
                        checkList.ValueMember = "Key";

                        break;
                }
            }            
        }
    }
}
