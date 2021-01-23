using System;
using System.Collections.Generic;
using ApplicationCore.Extensions;
using ApplicationCore.Window;
using Infrastructure;

namespace WindowExplorer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var windowFactory = new WindowFactory();
                var windows = windowFactory.GetWindows(WindowFilter.NormalWindow);

                var options = new LoggerTableOptions { Columns = new List<string> {"Handle", "Class Name", "Title", "Process Name", "ProcessId"}};
                var tableLogger = new TableLogger(options);
                windows.ForEach(win =>
                {
                    tableLogger.AddRow(win.Handle, win.ClassName.Truncate(50, ""), win.Title.Truncate(50, ""), win.ProcessName.Truncate(30, ""), win.ProcessId);
                });
                tableLogger.Write(Format.Minimal);
                Console.Out.WriteLine($"Windows found: {windows.Count}");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred when listing the windows. Error message: " + e.Message);
            }            
        }
    }
}
