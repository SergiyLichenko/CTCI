using System;
using System.Collections.Generic;
using System.Linq;


namespace DataStructures
{
    public class MyBinarySearchTreeNode<T> where T : IComparable
    {
        public T Data { get; set; }
        public MyBinarySearchTreeNode<T> Left { get; set; }
        public MyBinarySearchTreeNode<T> Right { get; set; }
        public MyBinarySearchTreeNode(T data)
        {
            Data = data;
        }

        public MyBinarySearchTreeNode(T data, MyBinarySearchTreeNode<T> left,
            MyBinarySearchTreeNode<T> right) : this(data)
        {
            Left = left;
            Right = right;
        }

    }
    public class MyBinarySearchTree<T> where T : IComparable
    {
        public MyBinarySearchTreeNode<T> Root;

        public int Count { get; private set; }

        public void Insert(T data)
        {
            if (Root == null)
                Root = new MyBinarySearchTreeNode<T>(data);
            else
                InsertHelper(data, Root);

            Count++;
        }

        private void InsertHelper(T data, MyBinarySearchTreeNode<T> root)
        {
            var compared = data.CompareTo(root.Data);

            if (compared == 0)
            {
                var node = new MyBinarySearchTreeNode<T>(data);

                if (root.Left != null)
                {
                    node.Left = root.Left;
                    node.Right = root.Left.Right;
                    root.Left = node;
                }
                else
                    root.Left = node;
            }
            if (compared < 0)
            {
                if (root.Left == null)
                    root.Left = new MyBinarySearchTreeNode<T>(data);
                else
                    InsertHelper(data, root.Left);
            }
            if (compared > 0)
            {
                if (root.Right == null)
                    root.Right = new MyBinarySearchTreeNode<T>(data);
                else
                    InsertHelper(data, root.Right);
            }
        }

        public bool Contains(T data)
            => ContainsHelper(Root, data);

        private bool ContainsHelper(MyBinarySearchTreeNode<T> node,
            T data)
        {
            if (node == null)
                return false;
            if (node.Data.Equals(data))
                return true;

            if (ContainsHelper(node.Left, data))
                return true;
            if (ContainsHelper(node.Right, data))
                return true;
            return false;
        }

        public IEnumerable<T> PreOrderTraversal()
            => PreOrderTraversalHelper(Root);

        private IEnumerable<T> PreOrderTraversalHelper(
            MyBinarySearchTreeNode<T> root)
        {
            if (root == null)
                yield break;

            yield return root.Data;
            List<T> data = new List<T>();
            if (root.Left != null)
                data.AddRange(PreOrderTraversalHelper(root.Left));
            if (root.Right != null)
                data.AddRange(PreOrderTraversalHelper(root.Right));

            foreach (var item in data)
                yield return item;
        }

        public IEnumerable<T> InOrderTraversal()
            => InOrderTraversalHelper(Root);

        private IEnumerable<T> InOrderTraversalHelper(
            MyBinarySearchTreeNode<T> root)
        {
            if (root == null)
                yield break;


            List<T> data = new List<T>();
            if (root.Left != null)
                data.AddRange(InOrderTraversalHelper(root.Left));
            data.Add(root.Data);
            if (root.Right != null)
                data.AddRange(InOrderTraversalHelper(root.Right));

            foreach (var item in data)
                yield return item;
        }

        public IEnumerable<T> PostOrderTraversal()
            => PostOrderTraversal(Root);

        private IEnumerable<T> PostOrderTraversal(
            MyBinarySearchTreeNode<T> root)
        {
            if (root == null)
                yield break;

            List<T> data = new List<T>();
            if (root.Left != null)
                data.AddRange(PostOrderTraversal(root.Left));
            if (root.Right != null)
                data.AddRange(PostOrderTraversal(root.Right));
            data.Add(root.Data);

            foreach (var item in data)
                yield return item;
        }

        public void Remove(T data)
        {
            if (RemoveHelper(Root, null, data))
                Count--;
        }

        private bool RemoveHelper(MyBinarySearchTreeNode<T> root,
            MyBinarySearchTreeNode<T> parent, T data)
        {
            if (root == null)
                return false;

            if (root.Data.Equals(data))
            {
                if (root.Left == null && root.Right == null)
                {
                    if (parent.Left != null && parent.Left.Data.Equals(root.Data))
                        parent.Left = null;
                    else
                        parent.Right = null;
                    return true;
                }
                if (root.Left != null && root.Right == null)
                {
                    if (parent.Right != null && parent.Right.Data.Equals(root.Data))
                        parent.Right = root.Left;
                    else
                        parent.Left = root.Left;
                    return true;
                }
                if (root.Right != null && root.Left == null)
                {
                    if (parent.Right != null && parent.Right.Data.Equals(root.Data))
                        parent.Right = root.Right;
                    else
                        parent.Left = root.Right;
                    return true;
                }
                if (root.Right != null && root.Left != null)
                {
                    var swapNode = FindLargestNodeInLeftSubStree(root.Left) ??
                        FindSmallestNodeInRightSubTree(root.Right);

                    var temp = swapNode.Data;
                    swapNode.Data = root.Data;
                    root.Data = temp;

                    return RemoveHelper(Root, null, swapNode.Data);
                }
            }

            if (RemoveHelper(root.Left, root, data))
                return true;
            if (RemoveHelper(root.Right, root, data))
                return true;

            return false;
        }

        private MyBinarySearchTreeNode<T> FindLargestNodeInLeftSubStree(MyBinarySearchTreeNode<T> root)
        {
            if (root == null)
                return root;

            var node = FindLargestNodeInLeftSubStree(root.Right);
            return node ?? root;
        }

        private MyBinarySearchTreeNode<T> FindSmallestNodeInRightSubTree(
            MyBinarySearchTreeNode<T> root)
        {
            if (root == null)
                return root;
            var node = FindSmallestNodeInRightSubTree(root.Left);
            return node ?? root;
        }
    }
}
