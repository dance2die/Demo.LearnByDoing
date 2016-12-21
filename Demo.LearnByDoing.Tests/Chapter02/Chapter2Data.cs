using System.Collections;
using System.Collections.Generic;

namespace Demo.LearnByDoing.Tests.Chapter02
{
    public abstract class Chapter2Data : IEnumerable<object[]>
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

        protected static Node<string> GetInputNode(params string[] nodeData)
        {
            Node<string> head = new Node<string>(nodeData[0]);
            Node<string> result = head;

            for (int i = 1; i < nodeData.Length; i++)
            {
                result.Next = new Node<string>(nodeData[i]);
                result = result.Next;
            }

            return head;
        }
    }

    public class Chapter2DataRemoveMiddle : Chapter2Data
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] { "b", GetInputNode("a", "b", "c", "d", "e", "f"), GetInputNode("a", "c", "d", "e", "f") },
            new object[] { "c", GetInputNode("a", "b", "c", "d", "e", "f"), GetInputNode("a", "b", "d", "e", "f") },
            new object[] { "d", GetInputNode("a", "b", "c", "d", "e", "f"), GetInputNode("a", "b", "c", "e", "f") },
            new object[] { "e", GetInputNode("a", "b", "c", "d", "e", "f"), GetInputNode("a", "b", "c", "d", "f") },
        };
    }

    public class Chapter2DataMiddle : Chapter2Data
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] { GetInputNode("a", "b", "c", "d", "e", "f"), GetInputNode("b", "c", "d", "e") },
            new object[] { GetInputNode("a", "b", "c", "d", "e"), GetInputNode("b", "c", "d") },
            new object[] { GetInputNode("a", "b", "c", "d"), GetInputNode("b", "c") },
            new object[] { GetInputNode("a", "b", "c"), GetInputNode("b") },
        };
    }

    public class Chapter2DataLength : Chapter2Data
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] { GetInputNode("a", "b", "c", "d", "e", "f"), 6 },
            new object[] { GetInputNode("a", "b", "c", "d", "e"), 5 },
            new object[] { GetInputNode("a", "b", "c", "d"), 4 },
            new object[] { GetInputNode("a", "b", "c"), 3 },
        };
    }
}