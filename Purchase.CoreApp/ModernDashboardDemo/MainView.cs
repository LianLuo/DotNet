using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernDashboardDemo
{
    public partial class MainView : Form
    {
        public MainView()
        {
            Thread tread = new Thread(formRun);
            tread.Start();
            Thread.Sleep(10000);
            InitializeComponent();
            tread.Abort();
        }

        private void formRun()
        {
            Application.Run(new SplashView());
        }
    }
}
