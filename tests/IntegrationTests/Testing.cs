using System.Collections.Generic;
using ApplicationCore.Extensions;
using ApplicationCore.Interfaces;
using IntegrationTests.TestUtils;
using Xunit.Abstractions;

namespace IntegrationTests
{
    public static class Testing
    {
        public static void LogAsTableView(List<IWindow> windows, ITestOutputHelper logger)
        {
            var options = new LoggerTableOptions
            {
                OutputTo = new TestOutputAdapter(logger),
                Columns = new List<string> {"Handle", "Class Name", "Title", "Process Name", "ProcessId"}
            };
            var tableLogger = new TestTableLogger(options);
            windows.ForEach(win =>
            {
                tableLogger.AddRow(win.Handle, win.ClassName.Truncate(40, ""), win.Title.Truncate(40, ""), win.ProcessName.Truncate(30, ""), win.ProcessId);
            });
            tableLogger.Write(Format.Minimal);
        }

    }
}