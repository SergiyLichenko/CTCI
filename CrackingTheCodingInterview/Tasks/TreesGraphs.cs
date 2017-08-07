﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;

namespace Tasks
{
    public class TreesGraphs
    {
        public bool RouteBetweenNodes(MyGraph<int> graph, int fromIndex, int toIndex)
            => graph.BidirectionalSearch(fromIndex, toIndex) != null;

        public MyBinarySearchTree<int> MinimalTree(int[] values)
        {
            if (values == null)
                throw new ArgumentNullException();

            var tree = new MyBinarySearchTree<int>();
            MinimalTreeHelper(values, 0, values.Length - 1, tree);

            return tree;
        }

        private void MinimalTreeHelper(int[] values,
            int startIndex, int endIndex,
            MyBinarySearchTree<int> tree)
        {
            if (startIndex > endIndex)
                return;

            var middle = (startIndex + endIndex) / 2;
            tree.Insert(values[middle]);

            MinimalTreeHelper(values, startIndex, middle - 1, tree);
            MinimalTreeHelper(values, middle + 1, endIndex, tree);
        }

        public MyDoublyLinkedList<int>[] ListOfDepth(
            MyBinarySearchTree<int> tree)
        {
            if (tree == null)
                throw new ArgumentNullException();

            List<MyDoublyLinkedList<int>> lists = new List<MyDoublyLinkedList<int>>();
            ListOfDepthHelper(tree.Root, 0, lists);

            return lists.ToArray();
        }

        private void ListOfDepthHelper(
            MyBinarySearchTreeNode<int> root, int depth,
            List<MyDoublyLinkedList<int>> lists)
        {
            if (root == null)
                return;

            if (lists.Count == depth)
                lists.Add(new MyDoublyLinkedList<int>());

            lists[depth].AddLast(new MyDoublyLinkedListNode<int>(root.Data));

            ListOfDepthHelper(root.Left, depth + 1, lists);
            ListOfDepthHelper(root.Right, depth + 1, lists);
        }
    }
}
