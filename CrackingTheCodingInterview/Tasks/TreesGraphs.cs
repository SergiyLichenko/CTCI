using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;
using DataStructures.MyBinarySearchTree;
using DataStructures.MyDoublyLinkedList;
using DataStructures.MyGraph;

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
            return SuccessorHelper(tree.Root, node, ref isNext);
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

        public IEnumerable<char> BuildOrder(MyGraph<char> graph)
        {
            if (graph == null)
                throw new ArgumentNullException();

            int getNodeIndex(char data)
            {
                for (int i = 0; i < graph.Nodes.Length; i++)
                    if (graph.Nodes[i] != null && graph.Nodes[i].Data.Equals(data))
                        return i;
                return -1;
            }

            var order = new List<char>();
            var builtNodes = new HashSet<MyGraphNode<char>>();

            int lastCount = -1;
            while (builtNodes.Count != graph.Count)
            {
                if (lastCount == builtNodes.Count)
                    throw new ArgumentException();
                lastCount = builtNodes.Count;

                foreach (var node in graph.Nodes)
                {
                    if (node == null || builtNodes.Contains(node))
                        continue;

                    int currentNodeIndex = getNodeIndex(node.Data);
                    var items = graph.Nodes.Where(x =>
                        x?.Children.Count(y => y.Data.Equals(node.Data)) > 0).ToList();

                    if (!items.Any())
                    {
                        builtNodes.Add(node);
                        order.Add(node.Data);

                        var indices = node.Children.Select(x => getNodeIndex(x.Data)).ToList();
                        indices.ForEach(x => graph.RemoveEdge(currentNodeIndex, x));
                    }

                }
            }

            return order;
        }

        public MyBinarySearchTreeNode<int> FirstCommonAncestor(MyBinarySearchTree<int> tree,
            MyBinarySearchTreeNode<int> firstNode, MyBinarySearchTreeNode<int> secondNode)
        {
            if (tree == null || firstNode == null || secondNode == null)
                throw new ArgumentNullException();

            return FirstCommonAncestorHelper(tree.Root, firstNode, secondNode);
        }

        private MyBinarySearchTreeNode<int> FirstCommonAncestorHelper(
            MyBinarySearchTreeNode<int> root,
            MyBinarySearchTreeNode<int> firstNode,
            MyBinarySearchTreeNode<int> secondNode)
        {
            var firstLeft = FirstCommonAncestorHelperCheckContains(root.Left, firstNode);
            var firstRight = FirstCommonAncestorHelperCheckContains(root.Right, firstNode);

            var secondLeft = FirstCommonAncestorHelperCheckContains(root.Left, secondNode);
            var secondRight = FirstCommonAncestorHelperCheckContains(root.Right, secondNode);

            if ((firstLeft && secondRight) || (firstRight && secondLeft))
                return root;
            if (firstLeft && secondLeft)
            {
                var result = FirstCommonAncestorHelper(root.Left, firstNode, secondNode);
                return result ?? root;
            }
            if (firstRight && secondRight)
            {
                var result = FirstCommonAncestorHelper(root.Right, firstNode, secondNode);
                return result ?? root;
            }

            return null;
        }

        private bool FirstCommonAncestorHelperCheckContains(
            MyBinarySearchTreeNode<int> root,
            MyBinarySearchTreeNode<int> node)
        {
            if (root == null)
                return false;

            if (root == node)
                return true;

            if (FirstCommonAncestorHelperCheckContains(root.Left, node))
                return true;
            if (FirstCommonAncestorHelperCheckContains(root.Right, node))
                return true;

            return false;
        }

        public List<int[]> BSTSequences(MyBinarySearchTree<int> tree)
        {
            if (tree == null)
                throw new ArgumentNullException();
            var result = BSTSequencesHelper(tree.Root);

            return result.Select(x => x.ToArray()).ToList();
        }

        private List<List<int>> BSTSequencesHelper(MyBinarySearchTreeNode<int> root)
        {
            if (root == null)
                return new List<List<int>>();

            var leftItems = BSTSequencesHelper(root.Left);
            var rightItems = BSTSequencesHelper(root.Right);

            var bigger = rightItems.Count > leftItems.Count ? rightItems : leftItems;
            var smaller = rightItems.Count <= leftItems.Count ? rightItems : leftItems;

            List<List<int>> permutations = new List<List<int>>();

            foreach (var item in bigger)
            {
                foreach (var value in smaller)
                {
                    var result = new List<List<int>>();
                    var current = new HashSet<int>();
                    FindOrderedPermutations(current, item, value, 0, 0, result);
                    permutations.AddRange(result);
                }
                if (smaller.Count == 0)
                    permutations.Add(item);
            }


            foreach (var item in permutations)
                item.Insert(0, root.Data);

            if (permutations.Count == 0)
                permutations.Add(new List<int>() { root.Data });

            return permutations;
        }

        private void FindOrderedPermutations(
            HashSet<int> current, List<int> first, List<int> second, int firstStartIndex,
            int secondStartIndex, List<List<int>> result)
        {
            if (firstStartIndex == first.Count &&
                secondStartIndex == second.Count)
            {
                result.Add(new List<int>(current));
                return;
            }

            if (first.Count != firstStartIndex)
            {
                current.Add(first[firstStartIndex]);
                FindOrderedPermutations(current, first, second,
                    firstStartIndex + 1, secondStartIndex, result);
                current.Remove(first[firstStartIndex]);
            }

            if (second.Count != secondStartIndex)
            {
                current.Add(second[secondStartIndex]);
                FindOrderedPermutations(current, first, second,
                    firstStartIndex, secondStartIndex + 1, result);
                current.Remove(second[secondStartIndex]);
            }
        }

        public bool CheckSubtree(MyBinarySearchTree<int> biggerTree,
            MyBinarySearchTree<int> smallerTree)
        {
            if (biggerTree == null || smallerTree == null)
                throw new ArgumentNullException();

            var biggerBuilder = new MyStringBuilder();
            var smallerBuilder = new MyStringBuilder();

            GetMarkedPreOrderTraversal(biggerTree.Root, biggerBuilder);
            GetMarkedPreOrderTraversal(smallerTree.Root, smallerBuilder);

            return biggerBuilder.ToString().Contains(smallerBuilder.ToString());
        }

        private void GetMarkedPreOrderTraversal(MyBinarySearchTreeNode<int> root,
            MyStringBuilder result)
        {
            if (root == null)
            {
                result.Append("*");
                return;
            }

            result.Append(root.Data.ToString());
            GetMarkedPreOrderTraversal(root.Left, result);
            GetMarkedPreOrderTraversal(root.Right, result);
        }

        public MyBinarySearchTreeNode<int> RandomNode(MyBinarySearchTree<int> tree)
        {
            if (tree == null)
                throw new ArgumentNullException();
            if (tree.Count == 0)
                return null;

            var index = 0;
            var number = new Random().Next(0, tree.Count);

            return GetNthNode(tree.Root, ref index, number);
        }

        private MyBinarySearchTreeNode<int> GetNthNode(MyBinarySearchTreeNode<int> root,
            ref int index, int endIndex)
        {
            if (index == endIndex)
                return root;
            index++;

            MyBinarySearchTreeNode<int> leftRes = null;

            if (root.Left != null)
                leftRes = GetNthNode(root.Left, ref index, endIndex);
            if (leftRes != null)
                return leftRes;

            return root.Right != null ? GetNthNode(root.Right, ref index, endIndex) : null;
        }

        //First implementation
        public int PathsWithSum(MyBinarySearchTree<int> tree, int target)
        {
            if (tree == null)
                throw new ArgumentNullException();
            var map = new Dictionary<MyBinarySearchTreeNode<int>, List<int>>();
            PathsWithSumHelper(tree.Root, map, null);
            return map.Sum(x => x.Value.Count(y => y == target));
        }

        private void PathsWithSumHelper(MyBinarySearchTreeNode<int> root,
            Dictionary<MyBinarySearchTreeNode<int>, List<int>> map,
            MyBinarySearchTreeNode<int> parent)
        {
            if (root == null)
                return;

            var currentValues = new List<int>() { root.Data };
            if (parent != null)
            {
                var parentValues = map[parent];
                currentValues.AddRange(parentValues.Select(x => x + root.Data));
            }
            map[root] = currentValues;

            PathsWithSumHelper(root.Left, map, root);
            PathsWithSumHelper(root.Right, map, root);
        }

        //Second implementation
       /* public int PathsWithSum(MyBinarySearchTree<int> tree, int target)
        {
            if (tree == null)
                throw new ArgumentNullException();
            var map = new Dictionary<int, int>();
            var result = PathsWithSumHelper(tree.Root, map, target, 0);

            return result;
        }

        private int PathsWithSumHelper(MyBinarySearchTreeNode<int> root,
            Dictionary<int, int> map,
            int target, int runningSum)
        {
            if (root == null)
                return 0;

            runningSum += root.Data;
            var sum = runningSum - target;

            int count = 0;
            if (sum == 0)
                count++;
            if (map.ContainsKey(sum))
                count = map[sum];

            if (!map.ContainsKey(runningSum))
                map[runningSum] = 0;
            map[runningSum]++;

            count += PathsWithSumHelper(root.Left, map, target, runningSum);
            count += PathsWithSumHelper(root.Right, map, target, runningSum);
            map[runningSum]--;

            return count;
        }*/
    }
}
