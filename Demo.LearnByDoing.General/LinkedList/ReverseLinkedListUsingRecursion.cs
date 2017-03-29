﻿using System;

namespace Demo.LearnByDoing.General.LinkedList
{
    public class ReverseLinkedListUsingRecursion
    {
        public static void Main(string[] args)
        {
            Node<int> nodes = GetNodes();
            Console.WriteLine("Before Sorting: {0}", nodes);
            //ReverseUsingRecursion(nodes);

            Console.WriteLine("After Sorting: {0}", nodes);
        }

        private static Node<int> GetNodes()
        {
            Node<int> root = new Node<int>(1, null);
            Node<int> head = root;

            root.Next = new Node<int>(2, null);
            root = root.Next;
            root.Next = new Node<int>(3, null);
            root = root.Next;
            root.Next = new Node<int>(4, null);
            root = root.Next;
            root.Next = new Node<int>(5, null);

            return head;
        }
    }
}
