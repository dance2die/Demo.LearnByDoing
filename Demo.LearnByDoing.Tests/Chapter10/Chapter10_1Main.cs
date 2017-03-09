using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.LearnByDoing.Core;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter10
{
    public class Chapter10_1Main : BaseTest
    {
        private readonly Chapter10_1 _sut = new Chapter10_1();

        public Chapter10_1Main(ITestOutputHelper output) : base(output)
        {
        }
    }

    public class Chapter10_1
    {
    }
}
