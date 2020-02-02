using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlDemo
{
    public partial class MainView : Form
    {
        static MainView mainFrm;
        public static MainView Instance
        {
            get
            {
                if(mainFrm == null)
                {
                    mainFrm = new MainView();
                }
                return mainFrm;
            }

        }

        public Panel PnlContainer
        {
            get
            {
                return this.panelContainer;
            }
            set
            {
                this.panelContainer = value;
            }
        }

        public Button BackButton
        {
            get
            {
                return this.btnBack;
            }
            set
            {
                this.btnBack = value;
            }
        }
        public MainView()
        {
            InitializeComponent();
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            btnBack.Visible = false;
            mainFrm = this;
            UCHome uc = new UCHome();
            uc.Dock = DockStyle.Fill;
            this.panelContainer.Controls.Add(uc);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.panelContainer.Controls["UCHome"].BringToFront();
            btnBack.Visible = false;
        }
    }
}
