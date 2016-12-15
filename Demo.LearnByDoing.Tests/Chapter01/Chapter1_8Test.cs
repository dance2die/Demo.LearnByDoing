using Demo.LearnByDoing.Tests.Core;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    /// <summary>
    /// Zero Matrix:
    /// Write an algorithm such that if an element in an MxN matrix is 0, 
    /// its entire row and column are set to 0
    /// </summary>
    public class Chapter1_8Test : BaseTest
    {
        private readonly Chapter1_8 _sut = new Chapter1_8();

        public Chapter1_8Test(ITestOutputHelper output) : base(output)
        {
        }
    }

    public class Chapter1_8
    {
    }

    public class Chapter1_8Data
    {
    }
}
