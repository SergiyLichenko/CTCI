using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;

namespace Algorithms
{
    //Johnson's Algorithm - All Pairs Shortest Path
    public class Johnson
    {
        public int[,] Compute(MyGraphAdj<int> graph)
        {
            if (graph == null)
                throw new ArgumentNullException();
            if (!graph.IsWeighted)
                throw new InvalidOperationException();

            MyGraphAdj<int> tempGraph = ExtendGraph(graph);
            var newWeights = ReveightEdges(tempGraph);
            UpdateWeights(tempGraph, newWeights);

            return null;
        }

        private int[] GetShortestPathsFromSource(int source, MyGraphAdj<int> graph)
        {
            return null;
        }

        private void UpdateWeights(MyGraphAdj<int> tempGraph, IEnumerable<int> newWeights)
        {
            List<int[]> edgesToDelete = tempGraph.GetAllEdges().Where(x => x[2] == Int32.MinValue).ToList();
            foreach (var edge in edgesToDelete)
                tempGraph.RemoveEdge(edge[0], edge[1]);

            var restEdges = tempGraph.GetAllEdges();
            foreach (var edge in restEdges)
            {
                int newWeight = edge[2] + newWeights.ElementAt(edge[0]) - newWeights.ElementAt(edge[1]);
                tempGraph.UpdateWeight(edge[0], edge[1], newWeight);
            }
        }

        private IEnumerable<int> ReveightEdges(MyGraphAdj<int> tempGraph)
        {
            var verteces = tempGraph.GetAllVerteces().ToList();
            var edges = tempGraph.GetAllEdges().ToList();

            var distances = new Dictionary<int, int>();
            foreach (var item in verteces)
                distances[item] = Int32.MaxValue;
            distances[tempGraph.Count - 1] = 0;

            for (int i = 0; i < verteces.Count - 1; i++)
            {
                for (int j = 0; j < edges.Count; j++)
                {
                    var u = edges[j][0];
                    var v = edges[j][1];
                    var weight = edges[j][2] == Int32.MinValue ? 0 : edges[j][2];

                    if (distances[u] != Int32.MaxValue &&
                        distances[v] > distances[u] + weight)
                    {
                        distances[v] = distances[u] + weight;
                    }
                }
            }

            return distances.Select(x => x.Value).Take(tempGraph.Count - 1);
        }

        private MyGraphAdj<int> ExtendGraph(MyGraphAdj<int> graph)
        {
            var result = new MyGraphAdj<int>(graph.Count + 1, true);

            var verteces = graph.GetAllVerteces().ToList();

            for (int i = 0; i < graph.Count; i++)
                result.AddVertex(i, verteces[i]);
            foreach (var item in graph.GetAllEdges().ToList())
                result.AddEdge(item[0], item[1], item[2]);

            result.AddVertex(graph.Count, graph.Count);
            foreach (var item in verteces)
                result.AddEdge(graph.Count, item, Int32.MinValue);

            return result;
        }
    }
}
