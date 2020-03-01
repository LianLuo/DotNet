using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircularFormDemo
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
            this.MoveSidePanel(this.btnHome);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MoveSidePanel(Control btn)
        {
            this.panelHighLight.Top = btn.Top;
            this.panelHighLight.Height = btn.Height;
        }

        private void btnEat_Click(object sender, EventArgs e)
        {
            this.MoveSidePanel(this.btnEat);
        }

        private void btnCollection_Click(object sender, EventArgs e)
        {
            this.MoveSidePanel(this.btnCollection);
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            this.MoveSidePanel(this.btnDelivery);
        }

        private void btnTakeAway_Click(object sender, EventArgs e)
        {
            this.MoveSidePanel(this.btnTakeAway);
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            this.MoveSidePanel(this.btnPayment);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            this.MoveSidePanel(this.btnCustomer);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.MoveSidePanel(this.btnHome);
        }
    }
}
