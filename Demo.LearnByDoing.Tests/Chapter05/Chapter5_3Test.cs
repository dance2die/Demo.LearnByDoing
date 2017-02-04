using Demo.LearnByDoing.Tests.Core;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter05
{
    /// <summary>
    /// Flip Bit to Win:
    /// You have an integer and you can flip exactly one bit from a 0 to a 1.
    /// Write code to find the length of the longest sequence of 1s you could create.
    /// 
    /// EXAMPLE
    /// Input:  1775 (or: 11011101111)
    /// Output: 8 => Flipping 7th bit turns 1775 to => 110 + 11111111
    /// Hints: #159, #226, #314, #352
    /// </summary>
    public class Chapter5_3Test : BaseTest
    {
        private readonly Chapter5_3 _sut = new Chapter5_3();

        public Chapter5_3Test(ITestOutputHelper output) : base(output)
        {
        }
    }

    public class Chapter5_3
    {
    }
}
