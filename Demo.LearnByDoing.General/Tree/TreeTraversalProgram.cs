﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.LearnByDoing.General.Tree
{
    public class TreeTraversalProgram
    {
        public static void Main(string[] args)
        {
            TreeNode<int> root = CreateSampleBinaryTree();

            List<int> inOrderList = new List<int>();
            InOrderTraversal(root, inOrderList);
            PrintListWithHeader("In-Order Traversal", inOrderList);

            List<int> preOrderList = new List<int>();
            //PreOrderTraversal(root, preOrderList);
        }

        private static void PrintListWithHeader(string header, List<int> list)
        {
            Console.Write("{0}: {1}", header, string.Join(" ", list.Select(val => val.ToString()).ToArray()));
            Console.WriteLine();
        }

        private static void InOrderTraversal(TreeNode<int> node, List<int> list)
        {
            if (node == null) return;

            InOrderTraversal(node.Left, list);
            list.Add(node.Value);
            InOrderTraversal(node.Right, list);
        }

        private static TreeNode<int> CreateSampleBinaryTree()
        {
            TreeNode<int> root = new TreeNode<int>(4)
            {
                Left = new TreeNode<int>(2, new TreeNode<int>(1), new TreeNode<int>(3)),
                Right = new TreeNode<int>(6, new TreeNode<int>(5), new TreeNode<int>(7))
            };
            return root;
        }
    }
}
