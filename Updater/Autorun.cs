using Cifra.Classes.Logging;
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
            try
            {
                string exePath = Assembly.GetExecutingAssembly().Location;
                string name = config.AppName + "Updater";
                exePath = exePath.Replace(".dll", ".exe");
                RegistryKey reg;
                reg = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                reg.SetValue(name, exePath);
                return true;
            }
            catch (Exception ex)
            {
                Log.Write("Ошибка в классе Autorun: " + ex.Message);
                return false;
            }
        }
    }
}
