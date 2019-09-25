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
        }

        public event Action<string> SetTextBoxHandler;
    }
}
