using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Updater
{
    internal class Autorun
    {
        public static bool Run(Config config)
        {
            string name = config.AppName + "Updater";
            string exePath = Assembly.GetExecutingAssembly().Location;
            exePath = exePath.Replace(".dll", ".exe");
            RegistryKey reg;
            reg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
            try
            {
                reg.SetValue(name, exePath);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
