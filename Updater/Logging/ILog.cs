using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cifra.Classes.Logging
{
    internal interface ILog
    {
        private static object sync = new object();

        /// <summary>
        /// Для логирования ошибок
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="path">Путь к папке для записи</param>
        public static void Write(string message, string path)
        {
            try
            {
                string pathToLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
                if (!Directory.Exists(pathToLog))
                    Directory.CreateDirectory(pathToLog);
                string filename = Path.Combine(pathToLog, string.Format("{0}_{1:dd.MM.yyy}.log",
                AppDomain.CurrentDomain.FriendlyName, DateTime.Now));
                string fullText = string.Format("[{0:dd.MM.yyy HH:mm:ss.fff}]{1}\r\n",
                DateTime.Now, message);
                lock (sync)
                {
                    File.AppendAllText(filename, fullText, Encoding.GetEncoding("UTF-8"));
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// Метод для удаления логов
        /// </summary>
        /// <param name="path">Путь к папке, в которой необходимо удалить логи</param>
        /// <param name="duration">Период, в течении которого логи надо оставить</param>
        public static void DeleteLog(string path, int duration)
        {
            string pathToLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
            string filecorrectname = Path.Combine(pathToLog, string.Format("{0}_{1:dd.MM.yyy}.log",
            AppDomain.CurrentDomain.FriendlyName, DateTime.Now.AddDays(-duration)));
            if (File.Exists(filecorrectname))
            {
                File.Delete(filecorrectname);
            }
        }
    }
}
