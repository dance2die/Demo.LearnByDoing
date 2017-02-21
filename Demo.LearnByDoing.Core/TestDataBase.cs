using System.Collections;
using System.Collections.Generic;

namespace Demo.LearnByDoing.Core
{
    public abstract class TestDataBase : IEnumerable<object[]>
    {
        public abstract List<object[]> Data { get; set; }

        public IEnumerator<object[]> GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}