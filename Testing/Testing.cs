using System;
using RETCON.Core.Event;
using RETCON.Core.Logger;

namespace Testing
{
    public class TestApp : RETCON.Core.Application
    {
        public override void Run()
        {
            Logger.Engine.Log("", LogColors.Trace, newline: false);
            Logger.Engine.Log(" - RETCON GAME ENGINE - ", LogColors.Trace, ConsoleColor.Blue, true);

            Logger.Application.Log("", LogColors.Trace, newline: false);
            Logger.Application.Log(" - TESTING APPLICATION - ", LogColors.Trace, ConsoleColor.DarkBlue, true);

            Logger.Application.Log("Application started\n\n", LogColors.Trace, newline: false);

            Logger.Application.Log("-- EVENT TESTING --", LogColors.Trace, ConsoleColor.DarkRed);

            var ev = new WindowMovedEvent(60, 50);
            Logger.Application.Log($"{ev}\n", LogColors.Trace, newline: false);

            Logger.Application.Log("-- EVENT TESTING --", LogColors.Trace, ConsoleColor.DarkRed);

            RETCON.Core.Window.Window test = new RETCON.Core.Window.Window("RETCON - WINDOW TESTING", 500, 500);
            
            test.Render();
            base.Run();
        }
    }

    internal class Testing
    {
        static void Main(string[] args)
        {
            TestApp t = new TestApp();
            t.Run();
        }
    }
}
