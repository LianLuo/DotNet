using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkypeDemo
{
    public partial class MainView : Form
    {
        int panelWith;
        bool Hidden;
        public MainView()
        {
            InitializeComponent();
            panelWith = PanelSide.Width;
            Hidden = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Hidden)
            {
                PanelSide.Width = PanelSide.Width + 10;
                if (PanelSide.Width >= panelWith)
                {
                    timer1.Stop();
                    Hidden = false;
                    this.Refresh();
                }

            }
            else
            {
                PanelSide.Width = PanelSide.Width - 10;
                if (PanelSide.Width <= 0)
                {
                    timer1.Stop();
                    Hidden = true;
                    this.Refresh();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
