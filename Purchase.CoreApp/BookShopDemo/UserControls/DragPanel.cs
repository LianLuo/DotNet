using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopDemo.UserControls
{
    internal class DragPanel : Component
    {
        private Control _HandleControl;

        public Control SelectControl
        {
            get
            {
                return this._HandleControl;
            }
            set
            {
                this._HandleControl = value;
                this._HandleControl.MouseDown += new MouseEventHandler(Drag_MouseDown);
            }
        }

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr handle, int msg, int wParams, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Drag_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this._HandleControl.FindForm().Handle, 161, 2, 0);
            }
        }
    }
}
