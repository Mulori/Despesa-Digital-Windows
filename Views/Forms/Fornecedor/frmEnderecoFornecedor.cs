using DespesaDigital.Code.BLL.bllFornecedor;
using DespesaDigital.Code.BLL.bllLogSistema;
using DespesaDigital.Code.DTO.dtoFornecedor;
using DespesaDigital.Code.DTO.dtoWebApi;
using DespesaDigital.Code.WEB;
using DespesaDigital.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Fornecedor
{
    public partial class frmEnderecoFornecedor : Form
    {
        public string codigoPaisPadrao = "6255150";
        public string codigoEstadoPadrao = "3469034";
        public string codigoCidadePadrao = "3448433";
        private int codigo_fornecedor { get; set; }
        private int codigo_endereco { get; set; }

        public frmEnderecoFornecedor(int _codigo_fornecedor)
        {
            InitializeComponent();

            codigo_fornecedor = _codigo_fornecedor;

            inicializarPaises();
            inicializarEstados();
            inicializarCidades();
        }

        /// <summary>
        /// Busca todos os paises da america do sul para pegar as cidades pertencentes
        /// </summary>
        /// <returns>dtoWebApiPaises</returns>
        public void inicializarPaises()
        {           
            string paises = webApi.TodosPaisesAmericaSul($"childrenJSON?geonameId={codigoPaisPadrao}");
            var objPaises = JsonConvert.DeserializeObject<dtoWebApiPaises>(paises);

            cmbPais.Items.Clear();

            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            foreach (var item in objPaises.geonames)
            {
                comboSource.Add($"{item.geonameId}", $"{item.name}");
            }

            cmbPais.DataSource = new BindingSource(comboSource, null);
            cmbPais.DisplayMember = "Value";
            cmbPais.ValueMember = "Key";
            cmbPais.Text = "Brazil";
        }

        public void inicializarEstados()
        {
            string paises = webApi.TodosPaisesAmericaSul($"childrenJSON?geonameId={codigoEstadoPadrao}");
            var objPaises = JsonConvert.DeserializeObject<dtoWebApiPaises>(paises);

            cmbEstados.Items.Clear();

            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            foreach (var item in objPaises.geonames)
            {
                comboSource.Add($"{item.geonameId}", $"{item.name}");
            }

            cmbEstados.DataSource = new BindingSource(comboSource, null);
            cmbEstados.DisplayMember = "Value";
            cmbEstados.ValueMember = "Key";
            cmbEstados.Text = "São Paulo";
        }

        public void inicializarCidades()
        {
            string paises = webApi.TodosPaisesAmericaSul($"childrenJSON?geonameId={codigoCidadePadrao}");
            var objPaises = JsonConvert.DeserializeObject<dtoWebApiPaises>(paises);

            cmbCidades.Items.Clear();

            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            foreach (var item in objPaises.geonames)
            {
                comboSource.Add($"{item.geonameId}", $"{item.name}");
            }

            cmbCidades.DataSource = new BindingSource(comboSource, null);
            cmbCidades.DisplayMember = "Value";
            cmbCidades.ValueMember = "Key";
            cmbCidades.Text = "Ribeirão Preto";
        }

        private void btnSalvar_Click(object sender, System.EventArgs e)
        {
            if(string.IsNullOrEmpty(cmbPais.Text) || string.IsNullOrEmpty(cmbEstados.Text) 
                || string.IsNullOrEmpty(cmbCidades.Text) || string.IsNullOrEmpty(txtLogradouro.Text) 
                    || string.IsNullOrEmpty(txtBairro.Text) || string.IsNullOrEmpty(mskCep.Text))
            {
                corePopUp.exibirMensagem("Preencha todos os campos.", "Atenção");
                return;
            }

            var dto = new dtoFornecedorEndereco();
            dto.codigo_fornecedor = codigo_fornecedor;
            dto.logradouro = txtLogradouro.Text.Trim();
            dto.bairro = txtBairro.Text.Trim();
            dto.cidade = cmbCidades.Text;
            dto.estado = "SP"; //cmbEstados.Text;
            dto.pais = cmbPais.Text;
            dto.cep = mskCep.Text.Replace("-", string.Empty);

            if(codigo_endereco > 0) //Alteração
            {
                dto.codigo = codigo_endereco;

                if (!bllFornecedorEndereco.Update(dto))
                {
                    corePopUp.exibirMensagem("Ocorreu um erro ao salvar o cadastro", "Atenção");
                    return;
                }
                else
                {
                    bllLogSistema.Insert($"Alterou informações do cadastro de endereço para o fornecedor de codigo[{codigo_fornecedor}] Logradouro: [{txtLogradouro.Text}] Cidade: [{cmbCidades.Text}]");

                    corePopUp.exibirMensagem("Cadastro salvo com sucesso!", "Atenção");
                    Close();
                    return;
                }
            }
            else //Inclusão
            {
                if (!bllFornecedorEndereco.Insert(dto))
                {
                    corePopUp.exibirMensagem("Ocorreu um erro ao incluir o cadastro", "Atenção");
                    return;
                }
                else
                {
                    bllLogSistema.Insert($"Incluiu um novo endereço para o fornecedor de codigo[{codigo_fornecedor}] Logradouro: [{txtLogradouro.Text}] Cidade: [{cmbCidades.Text}]");

                    corePopUp.exibirMensagem("Cadastro incluido com sucesso!", "Atenção");
                }
            }
        }

        private void btnExcluir_Click(object sender, System.EventArgs e)
        {
            if (codigo_endereco < 1)
            {
                corePopUp.exibirMensagem("Para excluir selecione um endereço.", "Atenção");
                return;
            }

            if (!corePopUp.exibirPergunta("Atenção:", "Deseja excluir este endereço?", 2))
            {
                return;
            }

            if (bllFornecedorEndereco.Delete(codigo_endereco, codigo_fornecedor))
            {
                bllLogSistema.Insert($"Exclusão do endereço: codigo:[{codigo_endereco}] codigo fornecedor:[{codigo_fornecedor}] Logradouro: [{txtLogradouro.Text}] Cidade: [{cmbCidades.Text}]");

                corePopUp.exibirMensagem("Endereço excluido com sucesso!.", "Atenção");
                Close();
                return;
            }
            else
            {
                corePopUp.exibirMensagem("Não foi possivel excluir o endereço.", "Atenção");
                return;
            }
        }
    }
}
