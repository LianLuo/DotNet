using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BabyMallDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.timer1.Start();
        }

        private int nextPicIndex=1;
        private void NextPicture()
        {
            if(nextPicIndex == 10)
            {
                nextPicIndex = 1;
            }
            sidePic.ImageLocation = $"Images/{nextPicIndex}.jpg";
            nextPicIndex++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            NextPicture();
        }
    }
}
