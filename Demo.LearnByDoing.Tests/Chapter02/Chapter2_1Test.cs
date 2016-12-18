using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Tests.Core;
using Xunit;
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

        [Theory]
        [ClassData(typeof(Chapter2_1Data))]
        public void TestRemovingDuplicatesFromUnsortedLinkedList(LinkedList<int> input, LinkedList<int> expected)
        {
            LinkedList<int> actual = _sut.RemoveDuplicates(input);

            Assert.True(expected.SequenceEqual(actual));
        }
    }

    public class Chapter2_1
    {
        /// <summary>
        /// First try: Remove duplicates using a temporary buffer.
        /// </summary>
        public LinkedList<int> RemoveDuplicates(LinkedList<int> input)
        {
            LinkedList<int> result = new LinkedList<int>();

            foreach (var value in input)
            {
                if (!result.Contains(value))
                    result.AddLast(value);
            }

            return result;;
        }
    }

    public class Chapter2_1Data : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            {
                new LinkedListWithInit<int> { 3, 1, 1, 2, 2, 3 },
                new LinkedListWithInit<int> { 3, 1, 2 },
            },
            new object[]
            {
                new LinkedListWithInit<int> { 4, 5, 5, 1, 2, 3, 1 },
                new LinkedListWithInit<int> { 4, 5, 1, 2, 3 },
            },
            new object[]
            {
                new LinkedListWithInit<int> { 1, 1, 2, 2, 3, 3 },
                new LinkedListWithInit<int> { 1, 2, 3 },
            },
            new object[]
            {
                new LinkedListWithInit<int> { 1, 2, 3 },
                new LinkedListWithInit<int> { 1, 2, 3 },
            },
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    /// <summary>
    /// http://stackoverflow.com/a/414638/4035
    /// </summary>
    public class LinkedListWithInit<T> : LinkedList<T>
    {
        public void Add(T item)
        {
            ((ICollection<T>)this).Add(item);
        }
    }
}
