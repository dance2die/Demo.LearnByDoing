using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.LearnByDoing.Tests.RandomStuff.Glassdoor.Asana
{
    class BinarySearchTreeCheckTest
    {
        public static IEnumerable<object[]> GetTestCases()
        {
            yield return new object[]
            {
                true,
                new BinarySearchTreeNode(10)
                {
                    Left = new BinarySearchTreeNode(5)
                    {
                        Left = new BinarySearchTreeNode(3),
                        Right = new BinarySearchTreeNode(7)
                    },
                    Right = new BinarySearchTreeNode(18)
                    {
                        Left = new BinarySearchTreeNode(13),
                        Right = new BinarySearchTreeNode(28)
                    }
                }
            };
            yield return new object[]
            {
                false,
                new BinarySearchTreeNode(99)
                {
                    Left = new BinarySearchTreeNode(5)
                    {
                        Left = new BinarySearchTreeNode(3),
                        Right = new BinarySearchTreeNode(7)
                    },
                    Right = new BinarySearchTreeNode(18)
                    {
                        Left = new BinarySearchTreeNode(13),
                        Right = new BinarySearchTreeNode(28)
                    }
                }
            };

            yield return new object[]
            {
                false,
                new BinarySearchTreeNode(10)
                {
                    Left = new BinarySearchTreeNode(5)
                    {
                        Left = new BinarySearchTreeNode(3)
                        {
                            Left = new BinarySearchTreeNode(10)
                        },
                        Right = new BinarySearchTreeNode(7)
                    },
                    Right = new BinarySearchTreeNode(18)
                    {
                        Left = new BinarySearchTreeNode(13),
                        Right = new BinarySearchTreeNode(28)
                    }
                }
            };
        }

        [Theory]
        [MemberData(nameof(GetTestCases))]
        public void TestSearchTree(bool expected, BinarySearchTreeNode root)
        {
            var actual = IsBinarySearchTree(root);
            Assert.Equal(expected, actual);
        }

        private bool IsBinarySearchTree(BinarySearchTreeNode node)
        {
            throw new NotImplementedException();
        }
    }

    class BinarySearchTreeNode
    {
        public int Value { get; }
        public BinarySearchTreeNode Left { get; set; }
        public BinarySearchTreeNode Right { get; set; }

        public BinarySearchTreeNode(int value)
        {
            Value = value;
        }

        public BinarySearchTreeNode InsertLeft(int leftValue)
        {
            Left = new BinarySearchTreeNode(leftValue);
            return Left;
        }

        public BinarySearchTreeNode InsertRight(int rightValue)
        {
            Right = new BinarySearchTreeNode(rightValue);
            return Right;
        }
    }
}
