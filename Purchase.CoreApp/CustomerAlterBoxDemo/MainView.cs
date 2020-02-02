using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerAlterBoxDemo
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
        }

        public void Alter(string msg, Form_Alter.EnumType type)
        {
            Form_Alter frm = new Form_Alter();
            frm.ShowAlter(msg, type);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Alter("Success", Form_Alter.EnumType.Success);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Alter("Warning", Form_Alter.EnumType.Warning);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Alter("Info", Form_Alter.EnumType.Info);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Alter("Error", Form_Alter.EnumType.Error);
        }
    }
}
