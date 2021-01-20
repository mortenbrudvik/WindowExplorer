using ApplicationCore.Window;
using Infrastructure;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

using static IntegrationTests.Testing;

namespace IntegrationTests
{
    public class WindowFactoryTests
    {
        private readonly ITestOutputHelper _logger;

        public WindowFactoryTests(ITestOutputHelper logger)
        {
            _logger = logger;
        }

        [Fact]
        public void GetWindows_ShouldFetchWindows_WhenNormalMatchingFilter()
        {
            var factory = new WindowFactory();

            var windows = factory.GetWindows(WindowFilter.IsNormalWindow);

            windows.ShouldNotBeEmpty();
            LogAsTableView(windows, _logger);
        }
    }
}