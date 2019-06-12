using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace GenBarcode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtEncode.Text)) return;

            BarcodeWriter writter = new BarcodeWriter()
            {
                Format = BarcodeFormat.CODE_128,
                Options = new ZXing.Common.EncodingOptions {
                    PureBarcode = false,
                }
            };

            pictureBox1.Image = writter.Write(txtEncode.Text);
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;

            BarcodeReader reader = new BarcodeReader();
            var result = reader.Decode((Bitmap)pictureBox1.Image);
            if (result != null)
                txtDecode.Text = result.Text;
        }
    }
}
