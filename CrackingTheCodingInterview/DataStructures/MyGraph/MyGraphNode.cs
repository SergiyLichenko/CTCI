using System.Collections.Generic;

namespace DataStructures.MyGraph
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
}