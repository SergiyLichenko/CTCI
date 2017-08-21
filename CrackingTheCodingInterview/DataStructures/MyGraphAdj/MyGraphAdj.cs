using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.MyGraphAdj
{
    public class MyGraphAdj<T>
    {
        private int[,] _adjacencyMatrix;
        private MyGraphAdjNode<T>[] _nodes;
        private int NoEdgeSign => IsWeighted ? Int32.MinValue : 0;

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

        public void AddEdge(int indexFrom, int indexTo)
        {
            if (indexFrom < 0 || indexFrom >= Capacity ||
                indexTo < 0 || indexTo >= Capacity || indexFrom == indexTo)
                throw new ArgumentOutOfRangeException();
            if (_nodes[indexFrom] == null || _nodes[indexTo] == null)
                throw new InvalidOperationException();

            _adjacencyMatrix[indexFrom, indexTo] = 1;
        }

        public void AddEdge(int indexFrom, int indexTo, int weight)
        {
            if (indexFrom < 0 || indexFrom >= Capacity ||
                indexTo < 0 || indexTo >= Capacity || indexFrom == indexTo)
                throw new ArgumentOutOfRangeException();
            if (_nodes[indexFrom] == null || _nodes[indexTo] == null || !IsWeighted)
                throw new InvalidOperationException();
            if (_adjacencyMatrix[indexFrom, indexTo] != NoEdgeSign)
                throw new ArgumentException();

            _adjacencyMatrix[indexFrom, indexTo] = weight;
        }

        public void UpdateWeight(int indexFrom, int indexTo, int weight)
        {
            if (indexFrom < 0 || indexFrom >= Capacity ||
                indexTo < 0 || indexTo >= Capacity || indexFrom == indexTo)
                throw new ArgumentOutOfRangeException();
            if (_nodes[indexFrom] == null || _nodes[indexTo] == null || !IsWeighted)
                throw new InvalidOperationException();
            if (_adjacencyMatrix[indexFrom, indexTo] == NoEdgeSign)
                throw new ArgumentException();

            _adjacencyMatrix[indexFrom, indexTo] = weight;
        }

        public IEnumerable<T> BreadthFirstSearch(int startIndex)
        {
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
                    if (_adjacencyMatrix[item, i] != NoEdgeSign)
                        queue.Enqueue(i);
            }
        }

        public IEnumerable<T> DepthFirstSearch(int startIndex)
        {
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
                    if (_adjacencyMatrix[item, i] != NoEdgeSign)
                        stack.Push(i);
            }
        }

        public IEnumerable<T>[] BidirectionalSearch(int from, int to)
        {
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
                        if (_adjacencyMatrix[fromItem, i] != NoEdgeSign)
                            visitedFromQueue.Enqueue(i);
                    }
                }
                if (!visitedTo.Contains(_nodes[toItem]))
                {
                    visitedTo.Add(_nodes[toItem]);
                    for (int i = 0; i < _adjacencyMatrix.GetLength(1); i++)
                    {
                        if (_adjacencyMatrix[toItem, i] != NoEdgeSign)
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
                    _adjacencyMatrix[index, i] = NoEdgeSign;
                    _adjacencyMatrix[i, index] = NoEdgeSign;
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

            _adjacencyMatrix[from, to] = NoEdgeSign;
        }

        public IEnumerable<int[]> GetAllEdges()
        {
            List<int[]> result = new List<int[]>();

            for (int i = 0; i < _adjacencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < _adjacencyMatrix.GetLength(1); j++)
                {
                    if (_adjacencyMatrix[i, j] != NoEdgeSign)
                        result.Add(IsWeighted ? new[] { i, j, _adjacencyMatrix[i, j] } : new[] { i, j });
                }
            }

            return result;
        }

        public IEnumerable<KeyValuePair<T, int>> GetAllVertexes()
            => _nodes.Where(x => x != null).Select((x, index) => new KeyValuePair<T, int>(x.Data, index));
    }
}
