using Demo.LearnByDoing.Tests.Core;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter02
{
    /// <summary>
    /// Remove Dups:
    /// Write code to remove duplicates from an unsorted linked list.
    /// FOLLOW UP
    /// How would you solve this problem if a temporary buffer is not allowed?
    /// </summary>
    public class Chapter2_1Test : BaseTest
    {
        private readonly Chapter2_1 _sut = new Chapter2_1();

        public Chapter2_1Test(ITestOutputHelper output) : base(output)
        {
        }
    }

    public class Chapter2_1
    {
    }
}
