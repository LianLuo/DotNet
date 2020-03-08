using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkThemeApp
{
    public partial class MainViews : Form
    {
        public MainViews()
        {
            InitializeComponent();
            this.SelectControl(this.btnHome);
        }

        private void SelectControl(Control btn)
        {
            this.panelSelectSide.Top = btn.Top;
            this.panelSelectSide.Height = btn.Height;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.SelectControl(this.btnHome);
        }

        private void btnSellers_Click(object sender, EventArgs e)
        {
            this.SelectControl(this.btnSellers);
        }

        private void btnCalender_Click(object sender, EventArgs e)
        {
            this.SelectControl(this.btnCalender);
        }

        private void btnTasks_Click(object sender, EventArgs e)
        {
            this.SelectControl(this.btnTasks);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    
}
