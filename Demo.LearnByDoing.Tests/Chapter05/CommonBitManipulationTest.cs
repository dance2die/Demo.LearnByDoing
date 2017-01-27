using System;
using Demo.LearnByDoing.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter05
{
    public class CommonBitManipulationTest : BaseTest
    {
        private readonly CommonBitManipulation _sut = new CommonBitManipulation();

        public CommonBitManipulationTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void TestGettingSettingBits()
        {
            int val8 = 8;
            for (int i = 0; i < 4; i++)
            {
                _output.WriteLine("{0} gets bit: {1} at position {2}", Convert.ToString(val8, 2), GetBit(val8, i), i);
            }
        }

        private bool GetBit(int num, int i)
        {
            int mask = 1 << i;
            return (num & mask) != 0;
        }

        private int SetBit(int num, int i)
        {
            int mask = 1 << 1;
            return (num | mask);
        }
    }

    public class CommonBitManipulation
    {
    }
}
