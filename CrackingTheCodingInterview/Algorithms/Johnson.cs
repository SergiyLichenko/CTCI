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
        public int[,] Compute(MyGraphAdj<char> graph)
        {
            if (graph == null)
                throw new ArgumentNullException();
            if (!graph.IsWeighted)
                throw new InvalidOperationException();

            MyGraphAdj<char> tempGraph = ExtendGraph(graph);
            var newWeights = ReveightEdges(tempGraph).ToArray();
            UpdateWeights(tempGraph, newWeights);

            int[,] result = new int[graph.Count, graph.Count];
            var vertexes = graph.GetAllVertexes().ToDictionary(x=>x.Key, x=>x.Value);
            
            for (int i = 0; i < vertexes.Count; i++)
            {
                var path = GetShortestPathsFromSource(vertexes.Keys.ElementAt(i),
                    tempGraph, newWeights);

                for (int j = 0; j < result.GetLength(1); j++)
                    result[i, j] = Int32.MinValue;

                foreach (var pair in path)
                {
                    if(pair.Key == vertexes.ElementAt(i).Key)
                        continue;
                    int index = vertexes[pair.Key];
                    result[i, index] = pair.Value;
                }
            }

            return result;
        }

        private Dictionary<char, int> GetShortestPathsFromSource(char source, MyGraphAdj<char> graph,
            int[] weights)
        {
            var vertexes = graph.GetAllVertexes().ToList();
            var edges = graph.GetAllEdges().ToList();

            Dictionary<char, int> distances = new Dictionary<char, int>();
            Dictionary<char, char?> parent = new Dictionary<char, char?>();
            Dictionary<char, int> heapMinDistances = new Dictionary<char, int>();

            var heap = new MyBinaryHeap<MyGraphKeyNode<char, int>>(MyBinaryHeapType.MinHeap);
            foreach (var vertex in vertexes)
            {
                heap.Insert(new MyGraphKeyNode<char, int>(vertex.Key, vertex.Key == source ? 0 : Int32.MaxValue));
                heapMinDistances.Add(vertex.Key, Int32.MaxValue);
            }

            parent[source] = null;
            distances[source] = 0;


            while (heap.Count > 0)
            {
                var current = heap.ExtractTop();
                var nodes = edges.Where(x => x[0].Equals(
                    vertexes.First(y => y.Key == current.Key).Value)).ToList();
                if (nodes.Count == 0)
                    break;
                var parentNode = vertexes.First(x => x.Key == current.Key);
                foreach (var node in nodes)
                {
                    var vertex = vertexes.First(x => x.Value == node[1]);
                    if(parent.ContainsKey(vertex.Key))
                        continue;

                    parent[vertex.Key] = current.Key;

                    var currentDistance = edges.First(x =>
                        x[0] == parentNode.Value && x[1] == vertex.Value)[2];
                    distances[vertex.Key] = distances[current.Key] + currentDistance;

                    if (heapMinDistances[vertex.Key] >= distances[vertex.Key])
                    {
                        heap.Decrease(new MyGraphKeyNode<char, int>(vertex.Key, Int32.MaxValue),
                            new MyGraphKeyNode<char, int>(vertex.Key, currentDistance));
                        heapMinDistances[vertex.Key] = currentDistance;
                    }
                }
            }

            Dictionary<char, int> result = new Dictionary<char, int>();
            foreach (var item in parent)
            {
                if (item.Value == null)
                {
                    result.Add(item.Key, 0);
                    continue;
                }


                var u = vertexes.First(x => x.Key == item.Value.Value);
                var v = vertexes.Find(x => x.Key == item.Key);

                var edge = edges.First(x => x[0] == u.Value && x[1] == v.Value);
                var weight = weights[v.Value] - weights[u.Value] + edge[2];

                result.Add(item.Key, result[u.Key] + weight);
            }

            return result;
        }

        private void UpdateWeights(MyGraphAdj<char> tempGraph, IEnumerable<int> newWeights)
        {
            List<int[]> edgesToDelete = tempGraph.GetAllEdges().Where(x => x[2] == 0).ToList();
            foreach (var edge in edgesToDelete)
                tempGraph.RemoveEdge(edge[0], edge[1]);

            tempGraph.Remove((char)(tempGraph.GetAllVertexes().Last().Key));

            var restEdges = tempGraph.GetAllEdges();
            foreach (var edge in restEdges)
            {
                int newWeight = edge[2] + newWeights.ElementAt(edge[0]) - newWeights.ElementAt(edge[1]);
                tempGraph.UpdateWeight(edge[0], edge[1], newWeight);
            }
        }

        private IEnumerable<int> ReveightEdges(MyGraphAdj<char> tempGraph)
        {
            var vertexes = tempGraph.GetAllVertexes().ToList();
            var edges = tempGraph.GetAllEdges().ToList();

            var distances = new Dictionary<int, int>();
            foreach (var item in vertexes)
                distances[item.Value] = Int32.MaxValue;
            distances[tempGraph.Count - 1] = 0;

            for (int i = 0; i < vertexes.Count - 1; i++)
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

        private MyGraphAdj<char> ExtendGraph(MyGraphAdj<char> graph)
        {
            var result = new MyGraphAdj<char>(graph.Count + 1, true);

            var vertexes = graph.GetAllVertexes().ToList();

            for (int i = 0; i < graph.Count; i++)
                result.AddVertex(i, vertexes[i].Key);
            foreach (var item in graph.GetAllEdges().ToList())
                result.AddEdge(item[0], item[1], item[2]);

            result.AddVertex(graph.Count, (char)(vertexes.Max(x => x.Key) + 1));
            foreach (var item in vertexes)
                result.AddEdge(graph.Count, item.Value, 0);

            return result;
        }
    }
}
