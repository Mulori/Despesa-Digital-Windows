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
                    ImageConverter imageConverter = new System.Drawing.ImageConverter();
                    picImagem.Image = imageConverter.ConvertFrom(bImagem) as Image;
                }
            }
        }

        private void btnGirar_Click_1(object sender, System.EventArgs e)
        {
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
    }
}
