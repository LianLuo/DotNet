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
    public partial class TabMonthView : UserControl, IHandler
    {
        public TabMonthView()
        {
            InitializeComponent();
            this.SetCheckBoxText(cb1, cb2, cb3, cb4, cb5, cb6, cb7, cb8, cb9, cb10, cb11, cb12);
        }

        public event Action<string> SetTextBoxHandler;
        private void SetCheckBoxText(params CheckBox[] cbList)
        {
            int i = 1;
            foreach (CheckBox cb in cbList)
            {
                cb.Text = string.Format("{0:d1}", i);
                cb.Click += BindingCheckBoxEvent;
                i++;
            }
        }

        private void TabMonthView_Click(object sender, EventArgs e)
        {

        }

        private void btnRadio_Month2_Click(object sender, EventArgs e)
        {

        }

        private void btnRadio_Month3_Click(object sender, EventArgs e)
        {

        }

        private void btnRadio_Month4_Click(object sender, EventArgs e)
        {

        }

        private void btnRadio_Month5_Click(object sender, EventArgs e)
        {

        }

        private void BindingCheckBoxEvent(object sender, EventArgs e)
        {
            btnRadio_Month5.Checked = true;
            var val = this.GetAllTextBoxVal(cb1, cb2, cb3, cb4, cb5, cb6, cb7, cb8, cb9, cb10, cb11, cb12);
            val = string.IsNullOrEmpty(val) ? "?" : val;
            this.SetMonthTextBoxVal(val);
        }

        private string GetAllTextBoxVal(params CheckBox[] cbList)
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

        private void SetMonthTextBoxVal(string val)
        {
            var tmp = SetTextBoxHandler;
            if (tmp != null)
            {
                tmp(val);
            }
        }
    }
}
