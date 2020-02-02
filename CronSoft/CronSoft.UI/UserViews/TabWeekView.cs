using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CronSoft.UI.UserViews
{
    public partial class TabWeekView : UserControl, IHandler
    {
        public TabWeekView()
        {
            InitializeComponent();
            this.SetCheckBoxText(cb1, cb2, cb3, cb4, cb5, cb6, cb7);
        }

        private void SetCheckBoxText(params CheckBox[] cbList)
        {
            int i = 1;
            foreach (CheckBox cb in cbList)
            {
                cb.Text = string.Format("{0:d1}", i);
                i++;
            }
        }

        public event Action<string> SetTextBoxHandler;

        private void BindingCheckBoxEvent(object sender, EventArgs e)
        {
            btnRadio_Week6.Checked = true;
            var val = this.GetAllCheckBoxVal(cb1, cb2, cb3, cb4, cb5, cb6, cb7);
            val = string.IsNullOrEmpty(val) ? "?" : val;
            this.SetWeekTextBoxVal(val);
        }

        private void SetWeekTextBoxVal(string val)
        {
            var tmp = SetTextBoxHandler;
            if (tmp != null)
            {
                tmp(val);
            }
        }

        private string GetAllCheckBoxVal(params CheckBox[] cbList)
        {
            List<int> collect = new List<int>();
            foreach (CheckBox cb in cbList)
            {
                if (cb != null && cb.Checked)
                {
                    collect.Add(Convert.ToInt32(cb.Text));
                }
            }
            return string.Join(",", collect);
        }

        private void btnRadio_Week1_Click(object sender, EventArgs e)
        {
            this.SetWeekTextBoxVal("*");
        }

        private void btnRadio_Week2_Click(object sender, EventArgs e)
        {
            this.SetWeekTextBoxVal("?");
        }

        private void btnRadio_Week3_Click(object sender, EventArgs e)
        {
            this.SetWeekTextBoxVal(string.Format("{0}/{1}", fromWeek.Value, toWeek.Value));
        }

        private void btnRadio_Week4_Click(object sender, EventArgs e)
        {
            this.SetWeekTextBoxVal(string.Format("{0}#{1}", numWeek.Value, numWeekend.Value));
        }

        private void btnRadio_Week5_Click(object sender, EventArgs e)
        {
            this.SetWeekTextBoxVal(string.Format("{0}L",lastWeek.Value));
        }

        private void btnRadio_Week6_Click(object sender, EventArgs e)
        {
            this.BindingCheckBoxEvent(sender, e);
        }

        private void fromWeek_ValueChanged(object sender, EventArgs e)
        {
            btnRadio_Week3.Checked = true;
            this.btnRadio_Week3_Click(sender, e);
        }

        private void toWeek_ValueChanged(object sender, EventArgs e)
        {
            btnRadio_Week3.Checked = true;
            this.btnRadio_Week3_Click(sender, e);
        }

        private void numWeek_ValueChanged(object sender, EventArgs e)
        {
            btnRadio_Week4.Checked = true;
            this.btnRadio_Week4_Click(sender, e);
        }

        private void numWeekend_ValueChanged(object sender, EventArgs e)
        {
            btnRadio_Week4.Checked = true;
            this.btnRadio_Week4_Click(sender, e);
        }

        private void lastWeek_ValueChanged(object sender, EventArgs e)
        {
            btnRadio_Week5.Checked = true;
            this.btnRadio_Week5_Click(sender, e);
        }
    }
}
