using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;
using DataStructures.MyBinaryHeap;
using DataStructures.MyGraphAdj;

namespace Algorithms
{
    //Johnson's Algorithm - All Pairs Shortest Path
    public class Johnson<T> where T : struct, IComparable
    {
        public int[,] Compute(MyGraphAdj<T> graph)
        {
            if (graph == null)
                throw new ArgumentNullException();
            if (!graph.IsWeighted)
                throw new InvalidOperationException();
            if(graph.Count==0)
                return new int[0,0];

            MyGraphAdj<T> tempGraph = ExtendGraph(graph);
            var newWeights = ReveightEdges(tempGraph).ToArray();
            UpdateWeights(tempGraph, newWeights);

            var result =  ComputeAllPairs(graph, tempGraph, newWeights);
            for(int i = 0 ; i<result.GetLength(0);i++)
            for (int j = 0; j < result.GetLength(1); j++)
                result[i, j] = result[i, j] == Int32.MinValue ? Int32.MaxValue : result[i, j];

            return result;
        }

        private int[,] ComputeAllPairs(MyGraphAdj<T> graph, MyGraphAdj<T> tempGraph,
            int[] newWeights)
        {
            int[,] result = new int[graph.Count, graph.Count];
            var vertexes = graph.GetAllVertexes().ToDictionary(x => x.Key, x => x.Value);

            for (int i = 0; i < vertexes.Count; i++)
            {
                var path = GetShortestPathsFromSource(vertexes.Keys.ElementAt(i),
                    tempGraph, newWeights);

                for (int j = 0; j < result.GetLength(1); j++)
                    result[i, j] = Int32.MinValue;

                foreach (var pair in path)
                {
                    int index = vertexes[pair.Key];
                    result[i, index] = pair.Key.CompareTo(vertexes.ElementAt(i).Key) == 0 ?
                        0 : pair.Value;
                }
            }

            return result;
        }

        private Dictionary<T, int> GetShortestPathsFromSource(T source, MyGraphAdj<T> graph,
            int[] weights)
        {
            var vertexes = graph.GetAllVertexes().ToList();
            var edges = graph.GetAllEdges().ToList();

            var parent = ComputePaths(source, graph).
                OrderByDescending(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            Dictionary<T, int> result = new Dictionary<T, int>();
            foreach (var item in parent)
            {
                if (item.Value == null)
                {
                    result.Add(item.Key, 0);
                    continue;
                }
                int distance = 0;
                var u = vertexes.First(x => x.Key.CompareTo(item.Value.Value) == 0);
                var v = vertexes.Find(x => x.Key.CompareTo(item.Key) == 0);

                while (true)
                {
                    distance += weights[v.Value] - weights[u.Value] + edges.First(x => x[0] == u.Value && x[1] == v.Value)[2];

                    if (parent[u.Key] == null)
                        break;

                    var temp = parent[u.Key].Value;
                    var prev = vertexes.First(x => x.Key.CompareTo(temp) == 0);
                    v = u;
                    u = prev;
                }
                result.Add(item.Key, distance);
            }
            return result;
        }

        private Dictionary<T, T?> ComputePaths(T source, MyGraphAdj<T> graph)
        {
            var vertexes = graph.GetAllVertexes().ToList();
            var edges = graph.GetAllEdges().ToList();

            Dictionary<T, int> distances = new Dictionary<T, int>();
            Dictionary<T, T?> parent = new Dictionary<T, T?>();
            Dictionary<T, int> heapMinDistances = new Dictionary<T, int>();

            var heap = new MyBinaryHeap<MyBinaryHeapKeyNode<T, int>>(MyBinaryHeapType.MinHeap);
            foreach (var vertex in vertexes)
            {
                heap.Insert(new MyBinaryHeapKeyNode<T, int>(vertex.Key, vertex.Key.CompareTo(source) == 0 ? 0 : Int32.MaxValue));
                heapMinDistances.Add(vertex.Key, Int32.MaxValue);
            }
            parent[source] = null;
            distances[source] = 0;

            while (heap.Count > 0)
            {
                var current = heap.ExtractTop();
                var nodes = edges.Where(x => x[0].Equals(
                    vertexes.First(y => y.Key.CompareTo(current.Key) == 0).Value)).ToList();
                if (nodes.Count == 0)
                    break;
                var parentNode = vertexes.First(x => x.Key.CompareTo(current.Key) == 0);
                foreach (var node in nodes)
                {
                    var vertex = vertexes.First(x => x.Value == node[1]);
                    if (!heap.Contains(new MyBinaryHeapKeyNode<T, int>(vertex.Key, vertex.Value)))
                        continue;

                    var currentDistance = edges.First(x =>
                        x[0] == parentNode.Value && x[1] == vertex.Value)[2];
                    distances[vertex.Key] = distances[current.Key] + currentDistance;

                    if (heapMinDistances[vertex.Key] >= distances[vertex.Key])
                    {
                        parent[vertex.Key] = current.Key;

                        heap.Decrease(new MyBinaryHeapKeyNode<T, int>(vertex.Key, Int32.MaxValue),
                            new MyBinaryHeapKeyNode<T, int>(vertex.Key, currentDistance));
                        heapMinDistances[vertex.Key] = currentDistance;
                    }
                }
            }

            return parent;
        }

        private void UpdateWeights(MyGraphAdj<T> tempGraph, IEnumerable<int> newWeights)
        {
            List<int[]> edgesToDelete = tempGraph.GetAllEdges().Where(x => x[2] == 0).ToList();
            foreach (var edge in edgesToDelete)
                tempGraph.RemoveEdge(edge[0], edge[1]);

            tempGraph.Remove((tempGraph.GetAllVertexes().Last().Key));

            var restEdges = tempGraph.GetAllEdges();
            foreach (var edge in restEdges)
            {
                int newWeight = edge[2] + newWeights.ElementAt(edge[0]) - newWeights.ElementAt(edge[1]);
                tempGraph.UpdateWeight(edge[0], edge[1], newWeight);
            }
        }

        private IEnumerable<int> ReveightEdges(MyGraphAdj<T> tempGraph)
        {
            var vertexes = tempGraph.GetAllVertexes().ToList();
            var edges = tempGraph.GetAllEdges().ToList();

            var distances = new Dictionary<int, int>();
            foreach (var item in vertexes)
                distances[item.Value] = Int32.MaxValue;
            distances[tempGraph.Count - 1] = 0;

            for (int i = 0; i < vertexes.Count; i++)
            {
                for (int j = 0; j < edges.Count; j++)
                {
                    var u = edges[j][0];
                    var v = edges[j][1];
                    var weight = edges[j][2] == Int32.MinValue ? 0 : edges[j][2];

                    if (distances[u] != Int32.MaxValue &&
                        distances[v] > distances[u] + weight)
                    {
                        if(i==vertexes.Count-1)
                            throw new ArgumentException("Negative cycle detected");

                        distances[v] = distances[u] + weight;
                    }
                }
            }

            return distances.Select(x => x.Value).Take(tempGraph.Count - 1);
        }

        private MyGraphAdj<T> ExtendGraph(MyGraphAdj<T> graph)
        {
            var result = new MyGraphAdj<T>(graph.Count + 1, true);

            var vertexes = graph.GetAllVertexes().ToList();

            for (int i = 0; i < graph.Count; i++)
                result.AddVertex(i, vertexes[i].Key);
            foreach (var item in graph.GetAllEdges().ToList())
                result.AddEdge(item[0], item[1], item[2]);

            result.AddVertex(graph.Count, (T)((dynamic)vertexes.Max(x => x.Key) + 1));
            foreach (var item in vertexes)
                result.AddEdge(graph.Count, item.Value, 0);

            return result;
        }
    }
}
