using RETCON.Core.Utils;
using System;
using System.Reflection;

namespace RETCON.Core.Logger
{
    public class Logger
    {
        private string _name;
        private int _logCount;

        public Logger(string name)
        {
            _name = name;
        }

        ~Logger()
        {

        }

        public void Log(string text, ConsoleColor fg, ConsoleColor bg = ConsoleColor.Black, bool newline = true)
        {
            TextUtils.ChangeConsoleColor(fg, bg);
            text += newline ? "\n" : string.Empty;

            Console.Write($"[{_name}]: {text}");
        }
    }

    public struct LogColors
    {
        public static ConsoleColor Critical = ConsoleColor.DarkRed;
        public static ConsoleColor Error = ConsoleColor.Red;
        public static ConsoleColor Warning = ConsoleColor.Yellow;
        public static ConsoleColor Trace = ConsoleColor.White;
        public static ConsoleColor Success = ConsoleColor.Green;
    }
}
