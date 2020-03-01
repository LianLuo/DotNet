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
    public partial class UCPhurchase : UserControl
    {
        public UCPhurchase()
        {
            InitializeComponent();
        }

        private void btnAddNewBook_Click(object sender, EventArgs e)
        {
            using (AddNewBookView addNewBookView = new AddNewBookView())
            {
                addNewBookView.ShowDialog();
            }
        }

        private void btnAddStock_Click(object sender, EventArgs e)
        {
            using (AddStockView addStockView = new AddStockView())
            {
                addStockView.ShowDialog();
            }
        }
    }
}
