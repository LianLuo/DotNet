using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopDemo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginView loginView = new LoginView();
            try
            {
                if(loginView.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new MainView());
                }
            }catch(Exception e)
            {

            }
            
        }
    }
}
