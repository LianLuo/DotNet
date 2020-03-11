using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BabyMallDemo
{
    public class DragControl : Component
    {
        private Control _SelectControl;

        public Control SelectControl
        {
            get { return this._SelectControl; }
            set
            {
                this._SelectControl = value;
                this._SelectControl.MouseDown += new MouseEventHandler(DragControl_MouseDown);
            }
        }

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr handle, int msg, int wParams, int lParams);

        private void DragControl_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this._SelectControl.FindForm().Handle, 161, 2, 0);
            }
        }
    }
}
