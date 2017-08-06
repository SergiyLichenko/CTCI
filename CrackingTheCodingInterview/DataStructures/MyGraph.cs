using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MyGraphNode<T>
    {
        public List<MyGraphNode<T>> Children { get; private set; }
        public T Data { get; private set; }
        public MyGraphNode(T data)
        {
            Data = data;
            Children = new List<MyGraphNode<T>>();
        }
    }
    public class MyGraph<T>
    {
        private MyGraphNode<T>[] _nodes;
        public int Capacity => _nodes.Length;
        public int Count { get; private set; }
        public MyGraph(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException();
            _nodes = new MyGraphNode<T>[capacity];
        }

        public void AddVertex(int index, T data)
        {
            if (index < 0 || index >= Capacity)
                throw new ArgumentOutOfRangeException();

            _nodes[index] = new MyGraphNode<T>(data);
            Count++;
        }

        public void AddEdge(int from, int to)
        {
            if (from < 0 || from >= Capacity ||
                to < 0 || to >= Capacity)
                throw new ArgumentOutOfRangeException();

            _nodes[from].Children.Add(_nodes[to]);
        }

        public IEnumerable<T> BreadthFirstSearch(int startIndex)
        {
            if (startIndex < 0 || startIndex >= Capacity)
                throw new ArgumentOutOfRangeException();
            if (_nodes[startIndex] == null)
                throw new ArgumentException();

            var queue = new Queue<MyGraphNode<T>>();
            var visited = new HashSet<MyGraphNode<T>>();

            queue.Enqueue(_nodes[startIndex]);
            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                if (visited.Contains(item))
                    continue;

                visited.Add(item);
                foreach (var child in item.Children)
                    queue.Enqueue(child);

                yield return item.Data;
            }
        }

        public IEnumerable<T> DepthFirstSearch(int startIndex)
        {
            if (startIndex < 0 || startIndex >= Capacity)
                throw new ArgumentOutOfRangeException();
            if (_nodes[startIndex] == null)
                throw new ArgumentException();

            var stack = new Stack<MyGraphNode<T>>();
            var visited = new HashSet<MyGraphNode<T>>();

            stack.Push(_nodes[startIndex]);
            while (stack.Count > 0)
            {
                var item = stack.Pop();
                if (visited.Contains(item))
                    continue;

                visited.Add(item);
                foreach (var child in item.Children)
                    stack.Push(child);

                yield return item.Data;
            }
        }

        public IEnumerable<T>[] BidirectionalSearch(int from, int to)
        {
            if (from < 0 || from >= Capacity ||
                to < 0 || to >= Capacity)
                throw new ArgumentOutOfRangeException();
            if (_nodes[from] == null || _nodes[to] == null)
                throw new ArgumentException();

            var visitedFrom = new HashSet<MyGraphNode<T>>();
            var visitedTo = new HashSet<MyGraphNode<T>>();
            var fromQueue = new Queue<MyGraphNode<T>>();
            var toQueue = new Queue<MyGraphNode<T>>();

            var fromPath = new List<MyGraphNode<T>>();
            var toPath = new List<MyGraphNode<T>>();

            fromQueue.Enqueue(_nodes[from]);
            toQueue.Enqueue(_nodes[to]);
            bool isFound = false;

            while (fromQueue.Count > 0 && toQueue.Count > 0)
            {
                var fromItem = fromQueue.Dequeue();
                var toItem = toQueue.Dequeue();

                if (!visitedFrom.Contains(fromItem))
                {
                    visitedFrom.Add(fromItem);
                    fromPath.Add(fromItem);
                    foreach (var item in fromItem.Children)
                        fromQueue.Enqueue(item);
                }
                if (!visitedTo.Contains(toItem))
                {
                    visitedTo.Add(toItem);
                    toPath.Add(toItem);
                    foreach (var item in toItem.Children)
                        toQueue.Enqueue(item);
                }

                if (visitedFrom.Contains(toItem) ||
                    visitedTo.Contains(fromItem))
                {
                    return new[] {fromPath.Select(x=>x.Data),
                        toPath.Select(x=>x.Data) };
                }
            }
            return null;
        }

        public void Remove(T data)
        {
            var index = _nodes.ToList().FindIndex(x => x.Data.Equals(data));
            if (index == -1)
                return;

            foreach (var item in _nodes)
            {
                if (item == null)
                    continue;

                for (int i = 0; i < item.Children.Count; i++)
                    if (item.Children[i].Equals(_nodes[index]))
                        item.Children.RemoveAt(i--);
            }

            _nodes[index] = null;
            Count--;
        }
    }
}
