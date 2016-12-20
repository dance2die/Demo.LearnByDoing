using Demo.LearnByDoing.Tests.Core;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter02
{
    public class Chapter2TestBase : BaseTest
    {
        protected Chapter2TestBase(ITestOutputHelper output) : base(output)
        {
        }

        protected bool AreNodesEqual(Node<int> expected, Node<int> actual)
        {
            while (expected != null && actual != null)
            {
                if (expected.Data != actual.Data) return false;

                expected = expected.Next;
                actual = actual.Next;

                if ((expected != null && actual == null) || (expected == null && actual != null)) return false;
            }

            return true;
        }
    }
}