using System;

namespace DataStructures.MyAVLTree
{
    public class MyAVLTree<T> where T : IComparable
    {
        public MyAVLTreeNode<T> Root { get; private set; }

        public int Count { get; private set; }
        public MyAVLTreeNode<T> Find(T data)
            => FindHelper(Root, data);

        private MyAVLTreeNode<T> FindHelper(MyAVLTreeNode<T> root,
            T data)
        {
            if (root == null)
                return root;

            if (root.Data.Equals(data))
                return root;

            var leftResult = FindHelper(root.Left, data);
            if (leftResult != null)
                return leftResult;

            var rightResult = FindHelper(root.Right, data);
            return rightResult;
        }


        public void Remove(T data)
        {
            if (RemoveHelper(Root, null, data))
                Count--;
        }

        private bool RemoveHelper(MyAVLTreeNode<T> root,
            MyAVLTreeNode<T> parent, T data)
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
            {
                BalanceParent(parent, root);
                return true;
            }
            if (RemoveHelper(root.Right, root, data))
            {
                BalanceParent(parent, root);
                return true;
            }


            return false;
        }


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

            return Balance(root);
        }

        private void BalanceParent(MyAVLTreeNode<T> parent,
            MyAVLTreeNode<T> root)
        {
            if (parent != null)
            {
                if (parent.Left != null && parent.Left.Equals(root))
                    parent.Left = Balance(root);
                else
                    parent.Right = Balance(root);
            }
            else
                Root = Balance(root);
        }

        private MyAVLTreeNode<T> Balance(MyAVLTreeNode<T> root)
        {
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

        private MyAVLTreeNode<T> FindLargestNodeInLeftSubStree(MyAVLTreeNode<T> root)
        {
            if (root == null)
                return root;

            var node = FindLargestNodeInLeftSubStree(root.Right);
            return node ?? root;
        }

        private MyAVLTreeNode<T> FindSmallestNodeInRightSubTree(
            MyAVLTreeNode<T> root)
        {
            if (root == null)
                return root;
            var node = FindSmallestNodeInRightSubTree(root.Left);
            return node ?? root;
        }
    }
}
