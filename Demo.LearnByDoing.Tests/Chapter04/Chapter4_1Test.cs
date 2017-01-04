using System.Collections.Generic;
using Demo.LearnByDoing.Tests.Core;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter04
{
    public class Chapter4_1Test : BaseTest
    {
        private readonly Chapter4_1 _sut = new Chapter4_1();

        public Chapter4_1Test(ITestOutputHelper output) : base(output)
        {
        }
    }

    public class Chapter4_1
    {
    }

    public class Chapter4_1Data : TestDataBase
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            
        };
    }
}
