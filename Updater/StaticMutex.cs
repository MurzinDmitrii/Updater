using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Updater
{
    internal static class StaticMutex
    {
        internal readonly static Mutex mutex = new Mutex(false, $"Global\\Updater");
    }
}
