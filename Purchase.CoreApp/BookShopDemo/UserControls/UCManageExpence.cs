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
    public partial class UCManageExpence : UserControl
    {
        public UCManageExpence()
        {
            InitializeComponent();
        }

        private void btnAddNewBExpense_Click(object sender, EventArgs e)
        {
            using (AddExpenseView addExpenseView = new AddExpenseView())
            {
                addExpenseView.ShowDialog();
            }
        }
    }
}
