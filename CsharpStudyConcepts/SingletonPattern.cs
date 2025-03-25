using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpStudyConcepts
{
    public class Logger
    {
        private static readonly Lazy<Logger> instance = new Lazy<Logger>(() => new Logger());

        private Logger() { }

        public static Logger Instance => instance.Value;

        public void Log(string message) {

            Console.WriteLine(message);
        }
    }
}
