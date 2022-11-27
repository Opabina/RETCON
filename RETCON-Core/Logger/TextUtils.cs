using System;

namespace RETCON.Core.Utils
{
    public static class TextUtils
    {
        public static void ChangeConsoleColor(ConsoleColor fg = ConsoleColor.White, ConsoleColor bg = ConsoleColor.Black)
        {
            Console.ForegroundColor = fg;
            Console.BackgroundColor = bg;
        }
    }
}