namespace DataStructures.MySinglyLinkedList
{
    public class MySinglyLinkedListNode<T>
    {
        public T Data { get; set; }

        public MySinglyLinkedListNode<T> Next { get; set; }
        public MySinglyLinkedListNode(T data)
        {
            Data = data;
        }
    }
}