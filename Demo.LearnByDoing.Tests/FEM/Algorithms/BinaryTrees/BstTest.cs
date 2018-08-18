using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.FEM.Algorithms.BinaryTrees
{
    public class BstTest : BaseTest
    {
        public BstTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void TestBstInsert()
        {
            var bst = new FemBinarySearchTree { Value = 10 };
            bst.Insert(5);
            bst.Insert(15);
            bst.Insert(3);
            bst.Insert(12);
            bst.Insert(6);
            bst.Insert(13);
            Console.WriteLine(bst);
        }
    }

    internal class FemBinarySearchTree
    {
        public int? Value { get; set; }
        public FemBinarySearchTree Left { get; set; }
        public FemBinarySearchTree Right { get; set; }

        public void Insert(int value)
        {
            if (Value.HasValue)
            {
                if (value < Value)
                {
                    if (Left == null)
                        Left = new FemBinarySearchTree {Value = value};
                    else
                        Left.Insert(value);
                }
                else if (value > Value)
                {
                    if (Right == null)
                        Right = new FemBinarySearchTree {Value = value};
                    else
                        Right.Insert(value);
                }
            }
            else
            {
                Value = value;
            }
        }
    }
}
