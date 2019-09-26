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
    public partial class TabDayView : UserControl, IHandler
    {
        public TabDayView()
        {
            InitializeComponent();
            this.SetCheckBoxText(cb1, cb2, cb3, cb4, cb5, cb6, cb7, cb8, cb9, cb10,
                cb11, cb12, cb13, cb14, cb15, cb16, cb17, cb18, cb19, cb20,
                cb21, cb22, cb23, cb24, cb25, cb26, cb27, cb28, cb29, cb30,
                cb31);
            var currTime = DateTime.Now;
            var monthOfDay = DateTime.DaysInMonth(currTime.Year, currTime.Month);
            startDay.Maximum = monthOfDay;
            perDay.Maximum = monthOfDay;
            fromDay.Maximum = monthOfDay;
            toDay.Maximum = monthOfDay;
            LastDay.Maximum = monthOfDay;
            if (monthOfDay == 30)
            {
                cb31.Visible = false;
            }
            else if (monthOfDay == 29)
            {
                cb31.Visible = false;
                cb30.Visible = false;
            }
            else if (monthOfDay == 28)
            {
                cb31.Visible = false;
                cb30.Visible = false;
                cb29.Visible = false;
            }
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
