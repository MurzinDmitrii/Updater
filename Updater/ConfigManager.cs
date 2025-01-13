using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Updater
{
    internal static class ConfigManager
    {
        private readonly static string appDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private readonly static string configPath = Path.Combine(appDirectory, "UpdaterConfig.json");

        internal static Config Loading()
        {
            string json = GetJsonConfig(configPath);
            Config item = JsonConvert.DeserializeObject<Config>(json);

            return item;
        }

        private static string GetJsonConfig(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                return r.ReadToEnd();
            }
        }
    }
}
