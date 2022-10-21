using System;
using RETCON.Core.Utils;

namespace RETCON.Core.Logger
{
    public class Logger
    {
        public static Logger Engine = new Logger("Engine");
        public static Logger Application = new Logger("Application");

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
            _logCount++;
        }

        public int GetLogCount()
        {
            return _logCount;
        }

        public void Assert(bool assert, string success = "Assertion Successful!", string fail = "Assertion Failed!")
        {
            if (assert)
            {
                Log(success, LogColors.Success);
                return;
            }

            Log(fail, LogColors.Error);
        }

        public override string ToString()
        {
            return $"[{_name}]";
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