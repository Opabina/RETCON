using RETCON.Core.Logger;
using System;

namespace Testing
{
    public class Testing : RETCON.Core.Application
    {
        public override void Run()
        {
            Logger log = new Logger("Application");
            log.Log("Logger init success!", LogColors.Success);
            log.Log("Testing Log Colors\n\n", LogColors.Trace, default(ConsoleColor), false);

            log.Log("TRACE", LogColors.Trace);
            log.Log("WARNING", LogColors.Warning);
            log.Log("ERROR", LogColors.Error);
            log.Log("CRITICAL", LogColors.Critical);
            log.Log("SUCCESS", LogColors.Success);

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
