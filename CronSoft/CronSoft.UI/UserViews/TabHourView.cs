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
    public partial class TabHourView : UserControl, IHandler
    {
        public TabHourView()
        {
            InitializeComponent();
            this.SetCheckBoxText(cb1, cb2, cb3, cb4, cb5, cb6, cb7, cb8, cb9, cb10,
                cb11, cb12, cb13, cb14, cb15, cb16, cb17, cb18, cb19, cb20,
                cb21, cb22, cb23, cb24);
        }

        public event Action<string> SetTextBoxHandler;
        private void SetCheckBoxText(params CheckBox[] cbList)
        {
            int i = 0;
            foreach (CheckBox cb in cbList)
            {
                cb.Text = string.Format("{0:d2}", i);
                i++;
            }
        }
    }
}
