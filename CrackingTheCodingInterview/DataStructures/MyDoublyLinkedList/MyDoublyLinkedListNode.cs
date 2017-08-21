namespace DataStructures.MyDoublyLinkedList
{
    public class MyDoublyLinkedListNode<T>
    {
        public T Data { get; set; }
        public MyDoublyLinkedListNode<T> Next { get; set; }
        public MyDoublyLinkedListNode<T> Prev { get; set; }
        public MyDoublyLinkedListNode(T data)
        {
            Data = data;
        }
    }
}