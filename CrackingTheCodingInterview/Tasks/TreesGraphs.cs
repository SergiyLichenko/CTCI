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
    }
}
