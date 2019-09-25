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
    public partial class TabSecondView : UserControl, IHandler
    {
        public TabSecondView()
        {
            InitializeComponent();
            this.SetCheckBoxText(cb1, cb2, cb3, cb4, cb5, cb6, cb7, cb8, cb9, cb10,
                cb11, cb12, cb13, cb14, cb15, cb16, cb17, cb18, cb19, cb20,
                cb21, cb22, cb23, cb24, cb25, cb26, cb27, cb28, cb29, cb30,
                cb31, cb32, cb33, cb34, cb35, cb36, cb37, cb38, cb39, cb40,
                cb41, cb42, cb43, cb44, cb45, cb46, cb47, cb48, cb49, cb50,
                cb51, cb52, cb53, cb54, cb55, cb56, cb57, cb58, cb59, cb60);
        }

        private void SetCheckBoxText(params CheckBox[] cbList)
        {
            int i = 0;
            foreach (CheckBox cb in cbList)
            {
                cb.Text = string.Format("{0:d2}", i);
                i++;
            }
        }

        private void fromNum_ValueChanged(object sender, EventArgs e)
        {
            btnRadio_Second2.Checked = true;
            this.SetValue(string.Format("{0}-{1}", fromNum.Value, toNum.Value));
        }

        private void toNum_ValueChanged(object sender, EventArgs e)
        {
            btnRadio_Second2.Checked = true;
            this.SetValue(string.Format("{0}-{1}", fromNum.Value, toNum.Value));
        }

        private void startNum_ValueChanged(object sender, EventArgs e)
        {
            btnRadio_Second3.Checked = true;
            this.SetValue(string.Format("{0}/{1}", startNum.Value, endNum.Value));
        }

        private void endNum_ValueChanged(object sender, EventArgs e)
        {
            btnRadio_Second3.Checked = true;
            this.SetValue(string.Format("{0}/{1}", startNum.Value, endNum.Value));
        }

        private void BindingSecondCtrl(object sender, EventArgs e)
        {
            btnRadio_Second4.Checked = true;
            this.btnRadio_Second4_Click(sender, e);
        }

        public event Action<string> SetTextBoxHandler;

        private string GetCheckBoxCtrlValue(params CheckBox[] cbList)
        {
            List<int> collection = new List<int>();
            foreach (CheckBox cb in cbList)
            {
                if (cb != null && cb.Checked)
                {
                    collection.Add(Convert.ToInt32(cb.Text));
                }
            }

            return string.Join(",", collection);
        }

        private void btnRadio_Second1_Click(object sender, EventArgs e)
        {
            this.SetValue("*");
        }

        private void btnRadio_Second2_Click(object sender, EventArgs e)
        {
            this.SetValue(string.Format("{0}-{1}", fromNum.Value, toNum.Value));
        }

        private void btnRadio_Second3_Click(object sender, EventArgs e)
        {
            this.SetValue(string.Format("{0}/{1}", startNum.Value, endNum.Value));
        }

        private void btnRadio_Second4_Click(object sender, EventArgs e)
        {
            var val = this.GetCheckBoxCtrlValue(cb1, cb2, cb3, cb4, cb5, cb6, cb7, cb8, cb9, cb10,
                                cb11, cb12, cb13, cb14, cb15, cb16, cb17, cb18, cb19, cb20,
                                cb21, cb22, cb23, cb24, cb25, cb26, cb27, cb28, cb29, cb30,
                                cb31, cb32, cb33, cb34, cb35, cb36, cb37, cb38, cb39, cb40,
                                cb41, cb42, cb43, cb44, cb45, cb46, cb47, cb48, cb49, cb50,
                                cb51, cb52, cb53, cb54, cb55, cb56, cb57, cb58, cb59, cb60);
            val = string.IsNullOrEmpty(val) ? "?" : val;
            var tmp = SetTextBoxHandler;
            if (tmp != null)
            {
                tmp(val);
            }
        }

        private void SetValue(string msg)
        {
            var tmp = SetTextBoxHandler;
            if (tmp != null)
            {
                tmp(msg);
            }
        }
    }
}
