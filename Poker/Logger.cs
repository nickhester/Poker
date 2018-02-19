using System;

namespace Poker
{
    // this is a minimal logging class so log level can be controlled as an option
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
