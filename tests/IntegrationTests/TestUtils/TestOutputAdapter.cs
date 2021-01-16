using Xunit.Abstractions;

namespace IntegrationTests.TestUtils
{
    public class TestOutputAdapter : TextWriterAdapter
    {
        private readonly ITestOutputHelper _logger;

        public TestOutputAdapter(ITestOutputHelper logger)
        {
            _logger = logger;
        }
        public override void WriteLine(string message)
        {
            _logger.WriteLine(message);
        }
    }
}