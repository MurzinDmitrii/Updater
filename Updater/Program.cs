using Cifra.Classes.Logging;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Reflection;

namespace Updater
{
    internal class Program
    {
        internal static async Task Main(string[] args)
        {
            try
            {
                Config config = ConfigManager.Loading();
                Mutex mutex = StaticMutex.mutex;
                if (!mutex.WaitOne(0, false))
                {
                    Environment.Exit(0);
                }
                Autorun.Run(config);
                Log.DeleteLog();
                string mainAppExePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + config.AppName + "\\" + config.AppName + ".exe";

                Process[] processes = Process.GetProcessesByName(config.AppName);
                foreach (Process process in processes)
                {
                    process.Kill();
                }

                bool update = await Checker.Check(config);
                if (update)
                {
                    await Downloader.DownloadAllFilesFromRepo(config);
                }

                Process startProcess = new Process();
                startProcess.StartInfo.FileName = mainAppExePath;
                startProcess.Start();
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Log.Write("Ошибка в классе Program: " + ex.Message);
            }
        }
    }
}