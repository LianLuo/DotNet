using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootWaterTrial
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            this.RoundPanels(panelAnalysist);
            this.RoundPanels(panelBottom);
            this.RoundPanels(panelBtn);
            this.RoundPanels(panelText);
            
        }

        private void RoundPanels(Panel myPanel)
        {
            this.bunifuElipse1.ApplyElipse(myPanel, 40);
        }

        private void SelectedButton(Button btn)
        {
            this.selectedItem.Top = btn.Top;
            this.selectedItem.Height = btn.Height;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            this.SelectedButton(this.btnDashboard);
        }

        private void btnTaskViewer_Click(object sender, EventArgs e)
        {
            this.SelectedButton(this.btnTaskViewer);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            this.SelectedButton(this.btnReports);
        }

        private void btnAnalytics_Click(object sender, EventArgs e)
        {
            this.SelectedButton(this.btnAnalytics);
        }

        private void btnTestButton_Click(object sender, EventArgs e)
        {
            this.SelectedButton(this.btnTestButton);
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            this.SelectedButton(this.btnCustomers);
        }

        private void btnDataSetting_Click(object sender, EventArgs e)
        {
            this.SelectedButton(this.btnDataSetting);
        }
    }
}
