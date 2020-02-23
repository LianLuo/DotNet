using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernDashboardDemo
{
    public partial class CustomerControl : UserControl
    {
        public CustomerControl()
        {
            InitializeComponent();
        }

        public Image UserAvator
        {
            get { return this.userAvatar.Image; }
            set { this.userAvatar.Image = value; }
        }

        public string UserName
        {
            get { return this.userName.Text; }
            set { this.userName.Text = value; }
        }

        public string UserSubTitle
        {
            get { return this.userSubTitle.Text; }
            set { this.userSubTitle.Text = value; }
        }
    }
}
