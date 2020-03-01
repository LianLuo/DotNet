using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopDemo.UserControls
{
    public partial class UCSales : UserControl
    {
        public UCSales()
        {
            InitializeComponent();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            using (FinishOrderView finishOrderView = new FinishOrderView())
            {
                finishOrderView.ShowDialog();
            }
        }
    }
}
