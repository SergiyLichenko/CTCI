using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MyGraphAdjNode<T>
    {
        public T Data { get; private set; }

        public MyGraphAdjNode(T data)
        {
            Data = data;
        }
    }
    public class MyGraphAdj<T>
    {
        private int[,] _adjacencyMatrix;
        private MyGraphAdjNode<T>[] _nodes;

        public int Capacity => _adjacencyMatrix.GetLength(0);
        public int Count { get; private set; }
        public bool IsWeighted { get; private set; }
        public MyGraphAdj(int capacity, bool isWeighted = false)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException();
            _adjacencyMatrix = new int[capacity, capacity];

            if (isWeighted)
                for (int i = 0; i < capacity; i++)
                    for (int j = 0; j < capacity; j++)
                        _adjacencyMatrix[i, j] = Int32.MinValue;

            _nodes = new MyGraphAdjNode<T>[capacity];
            IsWeighted = isWeighted;
        }

        public void AddVertex(int index, T data)
        {
            if (index < 0 || index >= Capacity)
                throw new ArgumentOutOfRangeException();
            _nodes[index] = new MyGraphAdjNode<T>(data);
            Count++;
        }

        public void AddEdge(int from, int to)
        {
            if (from < 0 || from >= Capacity ||
                to < 0 || to >= Capacity || from == to)
                throw new ArgumentOutOfRangeException();
            if (_nodes[from] == null || _nodes[to] == null)
                throw new InvalidOperationException();

            _adjacencyMatrix[from, to] = 1;
        }

        public void AddEdge(int from, int to, int weight)
        {
            if (from < 0 || from >= Capacity ||
                to < 0 || to >= Capacity || from == to)
                throw new ArgumentOutOfRangeException();
            if (_nodes[from] == null || _nodes[to] == null || !IsWeighted)
                throw new InvalidOperationException();
            if (_adjacencyMatrix[from, to] != Int32.MinValue)
                throw new ArgumentException();

            _adjacencyMatrix[from, to] = weight;
        }

        public void UpdateWeight(int from, int to, int weight)
        {
            if (from < 0 || from >= Capacity ||
                to < 0 || to >= Capacity || from == to)
                throw new ArgumentOutOfRangeException();
            if (_nodes[from] == null || _nodes[to] == null || !IsWeighted)
                throw new InvalidOperationException();
            if (_adjacencyMatrix[from, to] == Int32.MinValue)
                throw new ArgumentException();

            _adjacencyMatrix[from, to] = weight;
        }

        public IEnumerable<T> BreadthFirstSearch(int startIndex)
        {
            if (IsWeighted)
                throw new InvalidOperationException();
            if (startIndex < 0 || startIndex >= Capacity)
                throw new ArgumentOutOfRangeException();
            if (_nodes[startIndex] == null)
                throw new ArgumentException();

            var queue = new Queue<int>();
            queue.Enqueue(startIndex);
            var visited = new HashSet<MyGraphAdjNode<T>>();

            while (queue.Count > 0)
            {
                var item = queue.Dequeue();

                if (_nodes[item] == null ||
                    visited.Contains(_nodes[item]))
                    continue;

                yield return _nodes[item].Data;

                visited.Add(_nodes[item]);
                for (int i = 0; i < Capacity; i++)
                    if (_adjacencyMatrix[item, i] != 0)
                        queue.Enqueue(i);
            }
        }

        public IEnumerable<T> DepthFirstSearch(int startIndex)
        {
            if (IsWeighted)
                throw new InvalidOperationException();
            if (startIndex < 0 || startIndex >= Capacity)
                throw new ArgumentOutOfRangeException();
            if (_nodes[startIndex] == null)
                throw new ArgumentException();

            var stack = new Stack<int>();
            stack.Push(startIndex);
            var visited = new HashSet<MyGraphAdjNode<T>>();

            while (stack.Count > 0)
            {
                var item = stack.Pop();

                if (_nodes[item] == null ||
                    visited.Contains(_nodes[item]))
                    continue;

                yield return _nodes[item].Data;

                visited.Add(_nodes[item]);
                for (int i = 0; i < Capacity; i++)
                    if (_adjacencyMatrix[item, i] != 0)
                        stack.Push(i);
            }
        }

        public IEnumerable<T>[] BidirectionalSearch(int from, int to)
        {
            if (IsWeighted)
                throw new InvalidOperationException();
            if (from < 0 || from >= Capacity ||
                to < 0 || to >= Capacity)
                throw new ArgumentOutOfRangeException();
            if (_nodes[from] == null || _nodes[to] == null)
                throw new ArgumentException();

            var visitedFrom = new HashSet<MyGraphAdjNode<T>>();
            var visitedTo = new HashSet<MyGraphAdjNode<T>>();

            var visitedFromQueue = new Queue<int>();
            var visitedToQueue = new Queue<int>();
            visitedFromQueue.Enqueue(from);
            visitedToQueue.Enqueue(to);

            bool isFound = false;
            while (visitedToQueue.Count > 0 &&
                   visitedFromQueue.Count > 0)
            {
                var fromItem = visitedFromQueue.Dequeue();
                var toItem = visitedToQueue.Dequeue();

                if (!visitedFrom.Contains(_nodes[fromItem]))
                {
                    visitedFrom.Add(_nodes[fromItem]);
                    for (int i = 0; i < _adjacencyMatrix.GetLength(1); i++)
                    {
                        if (_adjacencyMatrix[fromItem, i] != 0)
                            visitedFromQueue.Enqueue(i);
                    }
                }
                if (!visitedTo.Contains(_nodes[toItem]))
                {
                    visitedTo.Add(_nodes[toItem]);
                    for (int i = 0; i < _adjacencyMatrix.GetLength(1); i++)
                    {
                        if (_adjacencyMatrix[toItem, i] != 0)
                            visitedToQueue.Enqueue(i);
                    }
                }
                if (visitedFrom.Any(x => visitedTo.Contains(x)))
                {
                    isFound = true;
                    break;
                }
            }

            return isFound ? new[]{visitedFrom.Select(x=>x.Data),
                visitedTo.Select(x=>x.Data) } : null;
        }

        public void Remove(T data)
        {
            var index = Array.FindIndex(_nodes, x => x != null &&
                                            x.Data.Equals(data));
            if (index != -1)
            {
                for (int i = 0; i < Capacity; i++)
                {
                    _adjacencyMatrix[index, i] = IsWeighted ? Int32.MinValue : 0;
                    _adjacencyMatrix[i, index] = IsWeighted ? Int32.MinValue : 0;
                }
                _nodes[index] = null;
                Count--;
            }
        }

        public void RemoveEdge(int from, int to)
        {
            if (from < 0 || from >= Capacity ||
                to < 0 || to >= Capacity)
                throw new ArgumentOutOfRangeException();

            _adjacencyMatrix[from, to] = IsWeighted ? Int32.MinValue : 0;
        }

        public IEnumerable<int[]> GetAllEdges()
        {
            List<int[]> result = new List<int[]>();

            for (int i = 0; i < _adjacencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < _adjacencyMatrix.GetLength(1); j++)
                {
                    if (IsWeighted && _adjacencyMatrix[i, j] != Int32.MinValue)
                        result.Add(new[] { i, j, _adjacencyMatrix[i, j] });
                    else if(!IsWeighted && _adjacencyMatrix[i, j] != 0)
                        result.Add(new[] { i, j });
                }
            }

            return result;
        }

        public IEnumerable<KeyValuePair<T, int>> GetAllVertexes()
            => _nodes.Where(x => x != null).Select((x, index) => new KeyValuePair<T, int>(x.Data, index));
    }
}
