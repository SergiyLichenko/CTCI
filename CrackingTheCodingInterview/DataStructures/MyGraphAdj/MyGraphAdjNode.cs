namespace DataStructures.MyGraphAdj
{
    public class MyGraphAdjNode<T>
    {
        public T Data { get; private set; }

        public MyGraphAdjNode(T data)
        {
            Data = data;
        }
    }
}