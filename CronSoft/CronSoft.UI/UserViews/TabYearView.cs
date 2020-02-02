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
    public partial class TabYearView : UserControl, IHandler
    {
        public TabYearView()
        {
            InitializeComponent();
        }

        public event Action<string> SetTextBoxHandler;

        private void btnRadio_Year1_Click(object sender, EventArgs e)
        {
            this.SetTextBoxYearValue(" ");
        }

        private void btnRadio_Year2_Click(object sender, EventArgs e)
        {
            this.SetTextBoxYearValue("*");
        }

        private void btnRadio_Year3_Click(object sender, EventArgs e)
        {
            this.SetTextBoxYearValue(string.Format("{0}-{1}", fromYear.Value, toYear.Value));
        }

        private void fromYear_ValueChanged(object sender, EventArgs e)
        {
            btnRadio_Year3.Checked = true;
            this.SetTextBoxYearValue(string.Format("{0}-{1}", fromYear.Value, toYear.Value));
        }

        private void toYear_ValueChanged(object sender, EventArgs e)
        {
            btnRadio_Year3.Checked = true;
            this.SetTextBoxYearValue(string.Format("{0}-{1}", fromYear.Value, toYear.Value));
        }

        private void SetTextBoxYearValue(string val)
        {
            val = string.IsNullOrEmpty(val) ? "?" : val;
            var tmp = SetTextBoxHandler;
            if (tmp != null)
            {
                tmp(val);
            }
        }
    }
}
