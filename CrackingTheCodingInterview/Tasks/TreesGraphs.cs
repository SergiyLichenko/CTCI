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
    }
}
