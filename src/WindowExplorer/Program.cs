using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using ApplicationCore.Extensions;
using ApplicationCore.Services;
using CommandLine;
using CsvHelper;
using Infrastructure;

namespace WindowExplorer
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var windowService = new WindowService(new WindowFactory());
                
                Parser.Default.ParseArguments<Options>(args)
                    .WithParsed(options =>
                    {
                        if (options.Dump)
                            WriteToFile(windowService);
                        else
                            WriteToConsole(windowService);
                    });
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred when listing the windows. Error message: " + e.Message);
            }            
        }

        private static void WriteToFile(WindowService windowService)
        {
            var watch = new Stopwatch();
            watch.Start();
            using var writer = new StreamWriter("window-dump.csv");
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            var windows = windowService.GetWindows();

            try
            {
                csv.WriteRecords(windows);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to write windows data to file \"window-dump.csv\". Error Msg: {e.Message}");
                return;
            }
            watch.Stop();
            Console.Out.WriteLine($"Saved {windows.Count} windows to file \"window-dump.csv\".");
        }

        private static void WriteToConsole(WindowService windowService)
        {
            var watch = new Stopwatch();
            watch.Start();
            var windows = windowService.GetWindows();

            var options = new LoggerTableOptions
                {Columns = new List<string> {"Handle", "Class Name", "Title", "Process Name", "ProcessId", "Process Arguments"}};
            var tableLogger = new TableLogger(options);
            windows.ToList().ForEach(win =>             {
                tableLogger.AddRow(win.Handle, win.ClassName.Truncate(70, ""), win.Title.Truncate(70, ""), win.ProcessName.Truncate(30, ""), win.ProcessId, win.ProcessArguments.Truncate(120)); });
            tableLogger.Write(Format.Minimal);
            watch.Stop();
            Console.Out.WriteLine($"Windows found: {windows.Count}. Search time: {watch.ElapsedMilliseconds / 1000}.{watch.ElapsedMilliseconds % 1000} seconds.");
        }
    }
    
    public class Options
    {
        [Option('d', "dump", Required = false, HelpText = "Dump window data to file (window-dump.csv)")]
        public bool Dump { get; set; }
    }
}
