using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElipseTool
{
    public partial class BarCodeView : Form
    {
        public BarCodeView()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string barCode = txtBarCode.Text;
            // QR Code
            if (ckQR.Checked)
            {
                QRCoder.QRCodeGenerator gr = new QRCoder.QRCodeGenerator();
                var myData = gr.CreateQrCode(barCode, QRCoder.QRCodeGenerator.ECCLevel.H);
                var code = new QRCoder.QRCode(myData);
                pictureBox1.Image = code.GetGraphic(50);
            }
            else
            {
                // Bar Code
                
                try
                {
                    Zen.Barcode.Code128BarcodeDraw barCodeObj = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                    pictureBox1.Image = barCodeObj.Draw(barCode, 60);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
        }
    }
}
