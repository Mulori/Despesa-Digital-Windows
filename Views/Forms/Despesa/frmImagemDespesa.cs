using DespesaDigital.Code.BLL.bllImagem;
using DespesaDigital.Core;
using System;
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
        public frmImagemDespesa(long codigo_despesa)
        {
            InitializeComponent();
            InicializarImagem(codigo_despesa);
            _codigo_despesa = codigo_despesa;
        }

        private void InicializarImagem(long codigo_despesa)
        {
            var bImagem = bllImagem.ObterByteImagemDespesaPorCodigo(codigo_despesa);

            imagem = bImagem;

            if (bImagem != null)
            {
                using (MemoryStream productImageStream = new MemoryStream(bImagem))
                {
                    try
                    {
                        ImageConverter imageConverter = new System.Drawing.ImageConverter();
                        picImagem.Image = imageConverter.ConvertFrom(bImagem) as Image;
                    }
                    catch
                    {
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

            var format = bllImagem.ObterFormatoImagemDespesaPorCodigo(_codigo_despesa);
            path = path + $@"\arquivo-despesa -{ _codigo_despesa}-{ DateTime.Now.ToString("ddMMyyyy-HHmmss")}.{format}";

            FileStream Stream = new FileStream(path, FileMode.Create);
            Stream.Write(imagem, 0, imagem.Length);
            Stream.Close();

            corePopUp.exibirMensagem("Arquivo salvo com sucesso!", "Atenção");
        }
    }
}
