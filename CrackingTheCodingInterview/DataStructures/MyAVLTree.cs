using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MyAVLTreeNode<T> where T : IComparable
    {
        public T Data { get; private set; }
        public int TreeHeight { get; set; }

        public MyAVLTreeNode<T> Left { get; set; }
        public MyAVLTreeNode<T> Right { get; set; }
        public MyAVLTreeNode(T data)
        {
            Data = data;
        }

        public MyAVLTreeNode(T data, int treeHeight) : this(data)
        {
            TreeHeight = treeHeight;
        }
    }
    public class MyAVLTree<T> where T : IComparable
    {
        public MyAVLTreeNode<T> Root { get; private set; }

        public int Count { get; private set; }

        public void Insert(T data)
        {
            if (Root == null)
                Root = new MyAVLTreeNode<T>(data);
            else
                Root = InsertHelper(data, Root);

            Count++;
        }

        private MyAVLTreeNode<T> InsertHelper(T data,
            MyAVLTreeNode<T> root)
        {
            if (root == null)
                return null;
            var compared = data.CompareTo(root.Data);

            if (compared > 0)
            {
                if (root.Right == null)
                    root.Right = new MyAVLTreeNode<T>(data, 1);
                else
                    root.Right = InsertHelper(data, root.Right);
            }
            else
            {
                if (root.Left == null)
                    root.Left = new MyAVLTreeNode<T>(data, 1);
                else
                    root.Left = InsertHelper(data, root.Left);
            }

            root.TreeHeight = Math.Max(root.Left?.TreeHeight ?? 0,
                                  root.Right?.TreeHeight ?? 0) + 1;


            int firstDif = (root.Left?.TreeHeight ?? 0) - (root.Right?.TreeHeight ?? 0);

            if (firstDif > 1)
            {
                int secondDif = (root.Left?.Left?.TreeHeight ?? 0) -
                    (root.Left?.Right?.TreeHeight ?? 0);

                if (secondDif < 0)
                    root = LeftRightRotation(root);
                root = LeftLeftRotation(root);
                UpdateHeight(root);
            }
            else if (firstDif < -1)
            {
                int secondDif = (root.Right?.Left?.TreeHeight ?? 0) -
                                (root.Right?.Right?.TreeHeight ?? 0);
                if (secondDif > 0)
                    root = RightLeftRotation(root);
                root = RightRightRotation(root);
                UpdateHeight(root);
            }

            return root;
        }

        private MyAVLTreeNode<T> RightRightRotation(MyAVLTreeNode<T> root)
        {
            var left = root;

            root = root.Right;
            left.Right = root.Left;
            root.Left = left;

            return root;
        }

        private MyAVLTreeNode<T> RightLeftRotation(MyAVLTreeNode<T> root)
        {
            var right = root.Right;
            root.Right = root.Right.Left;

            var temp = root.Right;
            while (temp.Right != null)
                temp = temp.Right;

            temp.Right = right;
            right.Left = null;

            return root;
        }

        private MyAVLTreeNode<T> LeftLeftRotation(MyAVLTreeNode<T> root)
        {
            var right = root;

            root = root.Left;
            right.Left = root.Right;
            root.Right = right;

            return root;
        }

        private MyAVLTreeNode<T> LeftRightRotation(MyAVLTreeNode<T> root)
        {
            var left = root.Left;
            root.Left = root.Left.Right;

            var temp = root.Left;
            while (temp.Left != null)
                temp = temp.Left;

            temp.Left = left;
            left.Right = null;

            return root;
        }

        private int UpdateHeight(MyAVLTreeNode<T> root)
        {
            if (root == null)
                return 0;
            var left = UpdateHeight(root.Left);
            var right = UpdateHeight(root.Right);

            root.TreeHeight = Math.Max(left, right) + 1;
            return root.TreeHeight;
        }
    }
}
