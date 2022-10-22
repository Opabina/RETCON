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

        private ConsoleColor _defaultForeground;
        private ConsoleColor _defaultBackground;

        public Logger(string name)
        {
            _name = name;
            _defaultForeground = Console.ForegroundColor;
            _defaultBackground = Console.BackgroundColor;
        }

        ~Logger()
        {

        }

        private static bool _prevNewline = true;
        public void Log(string text, ConsoleColor fg, ConsoleColor bg = ConsoleColor.Black, bool newline = true)
        {
            TextUtils.ChangeConsoleColor(fg, bg);
         
            // Create output string
            var output = _prevNewline ? $"[{_name}]: {text}" : $"{text}";
            
            if(newline)
            {
                output += "\n";
                _prevNewline = true;
            } else
            {
                _prevNewline = false;
            }

            // Write to output handle
            Console.Write(output);

            // Post-write
            TextUtils.ChangeConsoleColor(_defaultForeground, _defaultBackground);
            
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