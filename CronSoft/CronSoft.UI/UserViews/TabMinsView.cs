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
    public partial class TabMinsView : UserControl, IHandler
    {
        public TabMinsView()
        {
            InitializeComponent();
            this.SetCheckBoxText(cb1, cb2, cb3, cb4, cb5, cb6, cb7, cb8, cb9, cb10,
                cb11, cb12, cb13, cb14, cb15, cb16, cb17, cb18, cb19, cb20,
                cb21, cb22, cb23, cb24, cb25, cb26, cb27, cb28, cb29, cb30,
                cb31, cb32, cb33, cb34, cb35, cb36, cb37, cb38, cb39, cb40,
                cb41, cb42, cb43, cb44, cb45, cb46, cb47, cb48, cb49, cb50,
                cb51, cb52, cb53, cb54, cb55, cb56, cb57, cb58, cb59, cb60);
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
