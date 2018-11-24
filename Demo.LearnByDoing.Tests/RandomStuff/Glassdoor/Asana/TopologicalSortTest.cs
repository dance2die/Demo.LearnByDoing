using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.LearnByDoing.Tests.RandomStuff.Glassdoor.Asana
{
    /// <summary>
    /// Tushar Roy
    /// https://www.youtube.com/watch?v=ddTC4Zovtbc
    /// </summary>
    public class TopologicalSortTest
    {
        [Fact]
        public void TestHappyPath()
        {
            var graph = new Dictionary<char, List<char>>
            {
                {'a', new List<char> {'c'}},
                {'b', new List<char> {'d', 'e'}},
                {'c', new List<char> {'d'}},
                {'d', new List<char> {'f'}},
                {'e', new List<char> {'f'}},
                {'f', new List<char> {'g'}},
            };

            var actual = GetTopologicallySorted(graph);
            var expected = new [] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };
            Assert.True(expected.SequenceEqual(actual));
        }

        private IEnumerable<char> GetTopologicallySorted(Dictionary<char, List<char>> g)
        {
            yield break;
        }
    }
}
