using DropdownPanelDemo.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DropdownPanelDemo
{
    public partial class mainView : Form
    {
        private bool isCollapse = true;
        public mainView()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(isCollapse)
            {
                this.button7.Image = Resources.icons8_collapse_arrow_16px_1;
                panelFlow.Height += 10;
                if(panelFlow.Size == panelFlow.MaximumSize)
                {
                    timer1.Stop();
                    isCollapse = false;
                }
            }
            else
            {
                this.button7.Image = Resources.icons8_expand_arrow_16px_1;
                panelFlow.Height -= 10;
                if (panelFlow.Size == panelFlow.MinimumSize)
                {
                    timer1.Stop();
                    isCollapse = true;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr handle, int msg, int wParams, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.panelTitle.FindForm().Handle, 161, 2, 0);
            }
        }
    }
}
