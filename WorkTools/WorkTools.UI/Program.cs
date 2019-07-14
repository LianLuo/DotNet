using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using XTime.Wolf.Commons;

namespace WorkTools.UI
{
    static class Program
    {
        private static Mutex _Mutex;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            GlobalMutex();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Application_ThreadException;
            Application.Run(new MainView());
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string msg = $"{e.Exception.Message}\r\nYou operator occurs exception, are you quite?";
            if(MessageUtil.ShowYesNoAndError(msg) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private static void GlobalMutex()
        {
            bool createNew = false;
            string applicateName = @"Global\WorkTools";
            try
            {
                _Mutex = new Mutex(false, applicateName, out createNew);
            }catch(AbandonedMutexException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            if(createNew)
            {
                Console.WriteLine("This app was running.");
            }
            else
            {
                MessageUtil.ShowYesNoAndTips("this execute has been running, dont run again.");
                Thread.Sleep(0x3E8);
                Environment.Exit(1);
            }
        }
        private static void SetUIConstants()
        {
            string expireDate = "12/29/2018";
            string projectName = "WorkTools";
            string version = "1.0";
            string publicKey = "";
            XTime.Wolf.Commons.UIConstants.SetValue(expireDate, version, projectName, publicKey);
        }
    }
}
