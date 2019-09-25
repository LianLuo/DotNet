using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CronSoft.UI
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
            tabSecondView1.SetTextBoxHandler += (msg) =>
            {
                SetTextBoxCtrl(tbSecond, msg);
            };
        }

        private delegate void SetTextBoxValueHandler(string msg);

        private void SetTextBoxCtrl(TextBox tb, string msg)
        {
            if (tb.InvokeRequired)
            {
                SetTextBoxValueHandler handler = (f)=>{
                    tb.Text = f;
                };
                tb.Invoke(handler, new object[] { msg });
            }
            else
            {
                tb.Text = msg;
            }
        }

        private void BindingTextBoxValueChanged(object sender, EventArgs e)
        {
            List<string> collect = new List<string>();
            collect.Add(tbSecond.Text);
            collect.Add(tbMins.Text);
            collect.Add(tbHour.Text);
            collect.Add(tbDay.Text);
            collect.Add(tbMonth.Text);
            collect.Add(tbWeek.Text);
            collect.Add(tbYear.Text);

            SetTextBoxCtrl(tbExpression, string.Join(" ", collect));
        }
    }
}
