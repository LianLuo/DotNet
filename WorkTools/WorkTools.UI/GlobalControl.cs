using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XTime.Wolf.Commons;

namespace WorkTools.UI
{
    public class GlobalControl
    {
        private MainView _MainView;
        private bool _IsRegistered = false;
        private DateTime _FirstTime = new DateTime(0x7E0, 11, 11, 0, 0, 0);
        private List<DateTime> _TimeList = new List<DateTime>();
        private bool _IsProxy;

        public MainView MainView
        {
            get { return _MainView; }
            set { _MainView = value; }
        }

        public bool IsRegistered
        {
            get { return _IsRegistered; }
            set { _IsRegistered = value; }
        }

        public DateTime FirstTime
        {
            get { return _FirstTime; }
            set { _FirstTime = value; }
        }

        public List<DateTime> TimeList
        {
            get { return _TimeList; }
            set { _TimeList = value; }
        }

        public bool IsProxy
        {
            get { return _IsProxy; }
            set { _IsProxy = value; }
        }

        #region public functionality
        public void Quit()
        {
            Environment.Exit(1);
        }

        public void About()
        {

        }

        public bool Register(string serialNumber)
        {
            return RegisterClass.ValidateCode(this.GetHardNumber(), serialNumber);
        }

        private string GetHardNumber()
        {
            return HardwareInfoHelper.GetCPUId() + this.GetHexString(HardwareInfoHelper.GetCPUName());
        }

        public string GetHexString(string source)
        {
            byte[] bytes = Encoding.Default.GetBytes(source);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("X2", System.Globalization.CultureInfo.CurrentCulture));
            }
            return sb.ToString();
        }

        public bool CheckRegistered()
        {
            string serialNumber = string.Empty;
            RegistryKey key = Registry.CurrentUser.OpenSubKey(UIConstants.SoftwareRegistryKey, true);
            if(!ReferenceEquals(null,key))
            {
                serialNumber = key.GetValue("SerialNumber").ToString();
                _IsRegistered = this.Register(serialNumber);
            }
            return _IsRegistered;
        }
        #endregion
    }
}
