using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpStudyConcepts
{
    public class Logger
    {
        private static Lazy<Logger> instance = new Lazy<Logger>(() => new Logger());

        private static readonly object loggerLock = new object();

        private Logger() { }

        public static Lazy<Logger> Instance()
        {
            if (instance == null)
            {
                lock (loggerLock)
                {
                    if (instance == null)
                    {
                        instance = new Lazy<Logger>(() => new Logger());
                    }
                }
            }
            return instance;
        }
        private void Log(string message) {

            Console.WriteLine(message);
        }
    }
}
