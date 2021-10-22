using DespesaDigital.Code.DAL.dalConexao;
using DespesaDigital.Code.DAL.dalDespesa;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Despesa
{
    public partial class frmDespesa : Form
    {
        public frmDespesa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sQL = "select * from imagem";
            using (var command = new NpgsqlCommand(sQL, dalConexao.cnn))
            {
                byte[] productImageByte = null;
                var rdr = command.ExecuteReader();
                if (rdr.Read())
                {
                    productImageByte = (byte[])rdr[1];
                }
                rdr.Close();
                if (productImageByte != null)
                {
                    using (MemoryStream productImageStream = new System.IO.MemoryStream(productImageByte))
                    {
                        ImageConverter imageConverter = new System.Drawing.ImageConverter();
                        pictureBox1.Image = imageConverter.ConvertFrom(productImageByte) as System.Drawing.Image;
                    }
                }
            }
        }
    }
}
