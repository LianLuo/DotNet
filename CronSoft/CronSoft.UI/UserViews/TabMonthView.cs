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
            this.SetCheckBoxText(cb1, cb2, cb3, cb4, cb5, cb6, cb7, cb8, cb9, cb10,
               cb11, cb12);
        }

        public event Action<string> SetTextBoxHandler;
        private void SetCheckBoxText(params CheckBox[] cbList)
        {
            int i = 1;
            foreach (CheckBox cb in cbList)
            {
                cb.Text = string.Format("{0:d1}", i);
                i++;
            }
        }
    }
}
