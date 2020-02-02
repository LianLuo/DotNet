using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlDemo
{
    public partial class UCHome : UserControl
    {
        public UCHome()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!MainView.Instance.PnlContainer.Controls.ContainsKey("UCNext"))
            {
                UCNext un = new UCNext();
                un.Dock = DockStyle.Fill;
                MainView.Instance.PnlContainer.Controls.Add(un);
            }
            MainView.Instance.PnlContainer.Controls["UCNext"].BringToFront();
            MainView.Instance.BackButton.Visible = true;
        }
    }
}
