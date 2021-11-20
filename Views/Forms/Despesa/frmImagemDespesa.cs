using DespesaDigital.Code.BLL.bllImagem;
using DespesaDigital.Code.BLL.bllLogSistema;
using DespesaDigital.Code.DTO.dtoImagem;
using DespesaDigital.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Despesa
{
    public partial class frmImagemDespesa : Form
    {
        public long _codigo_despesa { get; set; }
        public byte[] imagem { get; set; }
        private bool bloqueia_visualizacao { get; set; }
        private int quantidade_arquivos { get; set; }
        private int index_visualizacao { get; set; }
        private List<dtoImagem> bImagensList;
        private bool primeira_visualizacao { get; set; }

        public frmImagemDespesa(long codigo_despesa)
        {
            InitializeComponent();

            quantidade_arquivos = 0;
            bImagensList = new List<dtoImagem>();
            bImagensList = bllImagem.ObterByteImagemDespesaPorCodigo(codigo_despesa);
            InicializarImagem(bImagensList);
            _codigo_despesa = codigo_despesa;
        }

        private void InicializarImagem(List<dtoImagem> bImagem)
        {            
            quantidade_arquivos = bImagem.Count;

            lblImagemVisualizando.Text = "1/" + quantidade_arquivos.ToString();            

            if (bImagem.Count > 0)
            {
                imagem = bImagem[0].b_dados_imagem;

                index_visualizacao = 1;

                using (MemoryStream productImageStream = new MemoryStream(bImagem[0].b_dados_imagem))
                {
                    primeira_visualizacao = true;
                    try
                    {
                        ImageConverter imageConverter = new ImageConverter();
                        picImagem.Image = imageConverter.ConvertFrom(bImagem[0].b_dados_imagem) as Image;
                    }
                    catch
                    {
                        picImagem.Image = null;
                        linkSalvarComputador.Visible = true;
                        bloqueia_visualizacao = true;
                    }
                }
            }
            else
            {
                corePopUp.exibirMensagem("Não foi encontrado nenhum arquivo para visualização.", "Atenção");
                bloqueia_visualizacao = true;
                btnSalvar.Enabled = false;
                btnGirar.Enabled = false;
                btnAvanca.Enabled = false;
                btnRetrocede.Enabled = false;
            }
        }

        private void btnGirar_Click_1(object sender, System.EventArgs e)
        {
            if (bloqueia_visualizacao)
                return;

            picImagem.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            picImagem.Refresh();            
        }

        private void btnSalvar_Click(object sender, System.EventArgs e)
        {
            var path = "";

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowser.SelectedPath;
            }

            if (path == "")
                return;

            File.WriteAllBytes(path + $@"\imagem-despesa-{_codigo_despesa}-{DateTime.Now.ToString("ddMMyyyy-HHmmss")}.png", imagem);

            bllLogSistema.Insert($"Exportou o arquivo da despesa de codigo: {_codigo_despesa} para o seguinte diretorio: {path}");

            corePopUp.exibirMensagem("Imagem salva com sucesso!", "Atenção");
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkSalvarComputador_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var path = "";

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowser.SelectedPath;
            }

            if (path == "")
                return;

            string format = "";

            if (primeira_visualizacao)
            {
                format = bllImagem.ObterFormatoImagemDespesaPorCodigo(_codigo_despesa, bImagensList[0].codigo);
            }
            else
            {
                format = bllImagem.ObterFormatoImagemDespesaPorCodigo(_codigo_despesa, bImagensList[index_visualizacao -1].codigo);
            }

            primeira_visualizacao = false;

            path = path + $@"\arquivo-despesa -{ _codigo_despesa}-{ DateTime.Now.ToString("ddMMyyyy-HHmmss")}.{format}";

            bllLogSistema.Insert($"Exportou o arquivo da despesa de codigo: {_codigo_despesa} para o seguinte diretorio: {path}");

            try
            {
                FileStream Stream = new FileStream(path, FileMode.Create);
                Stream.Write(imagem, 0, imagem.Length);
                Stream.Close();
                corePopUp.exibirMensagem("Arquivo salvo com sucesso!", "Atenção");
            }
            catch
            {
                corePopUp.exibirMensagem("Ocorreu um problema ao salvar o arquivo no diretorio escolhido. \nVerifique se você possui permissão!", "Atenção");
            }            
        }

        private void btnAvanca_Click(object sender, EventArgs e)
        {
            if(index_visualizacao >= quantidade_arquivos)
            {
                index_visualizacao = 1;
            }
            else
            {
                index_visualizacao++;
            }

            imagem =  bImagensList[index_visualizacao - 1].b_dados_imagem;

            if (bImagensList.Count > 0)
            {
                lblImagemVisualizando.Text = index_visualizacao +"/" + quantidade_arquivos.ToString();
                primeira_visualizacao = false;

                using (MemoryStream productImageStream = new MemoryStream(bImagensList[index_visualizacao -1].b_dados_imagem))
                {

                    try
                    {
                        ImageConverter imageConverter = new ImageConverter();
                        picImagem.Image = imageConverter.ConvertFrom(bImagensList[index_visualizacao - 1].b_dados_imagem) as Image;

                        linkSalvarComputador.Visible = false;
                        bloqueia_visualizacao = false;
                        btnSalvar.Enabled = true;
                    }
                    catch
                    {
                        picImagem.Image = null;
                        linkSalvarComputador.Visible = true;
                        bloqueia_visualizacao = true;
                        btnSalvar.Enabled = false;
                    }
                }
            }
            else
            {
                corePopUp.exibirMensagem("Não foi encontrado nenhum arquivo para visualização.", "Atenção");
                bloqueia_visualizacao = true;
                btnSalvar.Enabled = false;
                btnGirar.Enabled = false;
                btnAvanca.Enabled = false;
                btnRetrocede.Enabled = false;
            }
        }

        private void btnRetrocede_Click(object sender, EventArgs e)
        {
            if (index_visualizacao <= 1)
            {
                index_visualizacao = quantidade_arquivos;
            }
            else
            {
                index_visualizacao--;
            }

            imagem = bImagensList[index_visualizacao -1].b_dados_imagem;

            if (bImagensList.Count > 0)
            {
                lblImagemVisualizando.Text = index_visualizacao + "/" + quantidade_arquivos.ToString();
                primeira_visualizacao = false;

                using (MemoryStream productImageStream = new MemoryStream(bImagensList[index_visualizacao -1].b_dados_imagem))
                {

                    try
                    {
                        ImageConverter imageConverter = new ImageConverter();
                        picImagem.Image = imageConverter.ConvertFrom(bImagensList[index_visualizacao -1].b_dados_imagem) as Image;

                        linkSalvarComputador.Visible = false;
                        bloqueia_visualizacao = false;
                        btnSalvar.Enabled = true;
                    }
                    catch
                    {
                        picImagem.Image = null;
                        linkSalvarComputador.Visible = true;
                        bloqueia_visualizacao = true;
                        btnSalvar.Enabled = false;
                    }
                }
            }
            else
            {
                corePopUp.exibirMensagem("Não foi encontrado nenhum arquivo para visualização.", "Atenção");
                bloqueia_visualizacao = true;
                btnSalvar.Enabled = false;
                btnGirar.Enabled = false;
                btnAvanca.Enabled = false;
                btnRetrocede.Enabled = false;
            }
        }
    }
}
