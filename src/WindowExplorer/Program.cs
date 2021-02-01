using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                var watch = new Stopwatch();
                watch.Start();
                var windowFactory = new WindowFactory();
                var windows = windowFactory.GetWindows(WindowFilter.NormalWindow);

                var options = new LoggerTableOptions { Columns = new List<string> {"Handle", "Class Name", "Title", "Process Name", "ProcessId"}};
                var tableLogger = new TableLogger(options);
                windows.ForEach(win =>
                {
                    tableLogger.AddRow(win.Handle, win.ClassName.Truncate(50, ""), win.Title.Truncate(50, ""), win.ProcessName.Truncate(30, ""), win.ProcessId);
                });
                tableLogger.Write(Format.Minimal);
                watch.Stop();
                Console.Out.WriteLine($"Windows found: {windows.Count}. Search time: {watch.ElapsedMilliseconds/1000}.{watch.ElapsedMilliseconds%1000} seconds.");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred when listing the windows. Error message: " + e.Message);
            }            
        }
    }
}
