using System.Collections.Generic;
using ApplicationCore.Extensions;
using ApplicationCore.Window;
using Infrastructure;
using IntegrationTests.TestUtils;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace IntegrationTests
{
    public class WindowFactoryTests
    {
        private readonly ITestOutputHelper _logger;
        private readonly TableLogger _tableLogger;

        public WindowFactoryTests(ITestOutputHelper logger)
        {
            _logger = logger;
            var options = new LoggerTableOptions
            {
                OutputTo = new TestOutputAdapter(logger),
                Columns = new List<string>(){"Handle", "Class Name", "Title"}
            };
            _tableLogger = new TableLogger(options);
        }

        [Fact]
        public void GetWindows_ShouldFetchWindows_WhenNormalMatchingFilter()
        {
            var factory = new WindowFactory();
            var windows = factory.GetWindows(WindowFilter.IsNormalWindow);

            _logger.WriteLine("Matches {0} windows", windows.Count);
            windows.ForEach(win =>
            {
                _tableLogger.AddRow(win.Handle, win.ClassName.Truncate(40, ""), win.Title.Truncate(40, ""));
            });

            _tableLogger.Write(Format.Minimal);

            windows.ShouldNotBeEmpty();
        }
    }
}