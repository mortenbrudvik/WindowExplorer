using Shouldly;
using window_lib;
using Xunit;
using Xunit.Abstractions;

namespace IntegrationTests
{
    public class WindowFactoryTests
    {
        private readonly ITestOutputHelper _output;

        public WindowFactoryTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void GetWindows_ShouldWindows_WhenNormalMatchingFilter()
        {
            var factory = new WindowFactory();
            var windows = factory.GetWindows(WindowFilter.IsNormalWindow);

            _output.WriteLine("Matches {0} windows", windows.Count);
            windows.ForEach(win=>_output.WriteLine("Window title: {0}", win.Title));
            windows.ShouldNotBeEmpty();
        }
    }
}