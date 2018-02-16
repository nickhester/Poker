using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public static class Logger
    {
        public static bool LogDebug = true;

        public static void Log(string s)
        {
            if (LogDebug)
                Console.WriteLine(s);
        }
    }
}
