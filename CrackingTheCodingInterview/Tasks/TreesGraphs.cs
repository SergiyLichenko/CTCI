using System;
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

        public bool CheckBalanced(MyBinarySearchTree<int> tree)
        {
            if (tree == null)
                throw new ArgumentNullException();

            return CheckBalancedHelper(tree.Root) != Int32.MinValue;
        }

        private int CheckBalancedHelper(
            MyBinarySearchTreeNode<int> root)
        {
            if (root == null)
                return 0;
            var left = CheckBalancedHelper(root.Left);
            var right = CheckBalancedHelper(root.Right);

            if (Math.Abs(left - right) > 1 || left == -1 || right == -1)
                return Int32.MinValue;

            return Math.Max(left + 1, right + 1);
        }

        public bool ValidateBST(MyBinarySearchTree<int> tree)
        {
            if (tree == null)
                throw new ArgumentNullException();
            return ValidateBSTHelper(tree.Root);
        }

        private bool ValidateBSTHelper(MyBinarySearchTreeNode<int> root)
        {
            if (root == null)
                return true;

            var leftResult = ValidateBSTHelper(root.Left);
            if (!leftResult)
                return false;
            var rightResult = ValidateBSTHelper(root.Right);
            if (!rightResult)
                return false;

            if (root.Left != null && root.Left.Data > root.Data)
                return false;
            if (root.Right != null && root.Right.Data <= root.Data)
                return false;

            return true;
        }

        public MyBinarySearchTreeNode<int> Successor(MyBinarySearchTree<int> tree,
            MyBinarySearchTreeNode<int> node)
        {
            if (tree == null || node == null)
                throw new ArgumentNullException();

            bool isNext = false;
            return SuccessorHelper(tree.Root, node,ref isNext);
        }

        private MyBinarySearchTreeNode<int> SuccessorHelper(
            MyBinarySearchTreeNode<int> root,
            MyBinarySearchTreeNode<int> node,
            ref bool isNext)
        {
            if (root == null)
                return null;

            var leftResult = SuccessorHelper(root.Left, node, ref isNext);
            if (leftResult != null)
                return leftResult;

            if (isNext)
                return root;

            isNext = isNext || root.Equals(node);
           
            var rightResult = SuccessorHelper(root.Right, node, ref isNext);
            if (rightResult != null)
                return rightResult;

            return null;
        }
    }
}
