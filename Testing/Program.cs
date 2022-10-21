using System;
using RETCON.Core.Logger;

namespace Testing
{
    public class Testing : RETCON.Core.Application
    {
        public override void Run()
        {
            Logger.Engine.Log("-- RETCON GAME ENGINE TESTING --", LogColors.Trace, LogColors.Critical);
            Logger.Engine.Log("Testing Engine Logger\n\n", LogColors.Trace, default(ConsoleColor), false);

            // Engine Logger Testing
            Logger.Engine.Log("ENGINE LOG COUNT SHOULD BE 3", LogColors.Trace);
            Logger.Engine.Log($"LOG COUNT: {Logger.Engine.GetLogCount()}\n\n", LogColors.Trace, default(ConsoleColor), false);

            Logger.Engine.Log($"ASSERTION TEST", LogColors.Trace);
            Logger.Engine.Log($"ASSERT [false]:", LogColors.Trace);
            Logger.Engine.Assert(false);

            Logger.Engine.Log($"ASSERT [true]:", LogColors.Trace);
            Logger.Engine.Assert(true);

            base.Run();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Testing t = new Testing();
            t.Run();
        }
    }
}
