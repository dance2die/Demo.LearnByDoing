using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Core
{
    public abstract class BaseTest
    {
        protected readonly ITestOutputHelper _output;

        protected BaseTest(ITestOutputHelper output)
        {
            _output = output;
        }
    }
}