using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernDashboardDemo
{
    public partial class SplashView : Form
    {
        public SplashView()
        {
            InitializeComponent();
        }

        private int move = 2;
        private void timer1_Tick(object sender, EventArgs e)
        {
            panelSide.Left += 2;
            if (panelSide.Left > 230)
            {
                panelSide.Left = 0;
            }

            if (panelSide.Left < 0)
            {
                move = 2;
            }
        }

        private void SplashView_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
