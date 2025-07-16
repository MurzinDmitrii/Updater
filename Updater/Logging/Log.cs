using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cifra.Classes.Logging
{
    /// <summary>
    /// Класс для логирования
    /// </summary>
    public class Log : ILog
    {
        private static string path = "Log";
        /// <summary>
        /// Для логирования ошибок
        /// </summary>
        /// <param name="message">Сообщение</param>

        public static void Write(string message)
        {
            ILog.Write(message, path);
        }

        /// <summary>
        /// Удаление старых логов
        /// </summary>
        /// <param name="filename">Название файла</param>
        /// <param name="duration">Период удаления</param>
        public static void DeleteLog()
        {
            ILog.DeleteLog(path, 5);
        }
    }
}
