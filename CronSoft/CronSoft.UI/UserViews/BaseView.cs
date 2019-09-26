using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CronSoft.UI.UserViews
{
    public class BaseView : UserControl, IHandler
    {
        protected void SetCheckBoxText(params CheckBox[] cbList)
        {
            int i = 1;
            foreach (CheckBox cb in cbList)
            {
                cb.Text = string.Format("{0:d1}", i);
                i++;
            }
        }

        public event Action<string> SetTextBoxHandler;
    }
}
