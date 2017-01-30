using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.LearnByDoing.Tests.Core;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter05
{
    /// <summary>
    /// Binary to String:
    /// Given a real number between 0 and 1 (e.g., 0.72) that is passed in as a double,
    /// print the binary representation.
    /// If the number cannot be represented accurantely in binary with at most 32 characters,
    /// print "ERROR".
    /// 
    /// Hints: #143, #167, #173, #269, #297
    /// </summary>
    public class Chapter5_2Test : BaseTest
    {
        private readonly Chapter5_2 _sut = new Chapter5_2();

        public Chapter5_2Test(ITestOutputHelper output) : base(output)
        {
        }
    }

    public class Chapter5_2
    {
    }
}
