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
    public partial class AddNewBookView : Form
    {
        public AddNewBookView()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //this.Dispose();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            using (AddCategoryView addCategoryView = new AddCategoryView())
            {
                addCategoryView.ShowDialog();
            }
        }
    }
}
