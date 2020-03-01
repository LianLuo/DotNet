using BookShopDemo.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopDemo
{
    public partial class MainView : Form
    {
        int panelWidth;
        bool isCollapsed;
        public MainView()
        {
            InitializeComponent();
            panelWidth = panelNorthSide.Width;
            isCollapsed = false;
            this.MoveSidePanel(this.btnHome);
            this.timer2.Start();
            this.MoveSidePanel(this.btnHome);
            this.AddControlsToPanel(new UCHome());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainView_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(isCollapsed)
            {
                panelNorthSide.Width = panelNorthSide.Width + 10;
                if(panelNorthSide.Width >= panelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.lbTitle.Visible = true;
                    this.lbSubTitle.Visible = true;
                    this.Refresh();
                }
            }
            else
            {
                panelNorthSide.Width = panelNorthSide.Width - 10;
                if (panelNorthSide.Width <= 59)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    this.lbTitle.Visible = false;
                    this.lbSubTitle.Visible = false;
                    this.Refresh();
                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void MoveSidePanel(Control btn)
        {
            panelHighLight.Top = btn.Top;
            panelHighLight.Height = btn.Height;
        }

        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Clear();
            this.panelDesktop.Controls.Add(c);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.MoveSidePanel(this.btnHome);
            this.AddControlsToPanel(new UCHome());
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            this.MoveSidePanel(this.btnSale);
            this.AddControlsToPanel(new UCSales());
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            this.MoveSidePanel(this.btnPurchase);
        }

        private void btnExpenses_Click(object sender, EventArgs e)
        {
            this.MoveSidePanel(this.btnExpenses);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            this.MoveSidePanel(this.btnUsers);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            this.MoveSidePanel(this.btnView);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            this.MoveSidePanel(this.btnSetting);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
