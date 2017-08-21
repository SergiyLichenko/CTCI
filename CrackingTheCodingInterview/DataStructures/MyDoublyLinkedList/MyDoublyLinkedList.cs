using System;

namespace DataStructures.MyDoublyLinkedList
{
    public class MyDoublyLinkedList<T>
    {
        public MyDoublyLinkedListNode<T> Head { get; set; }
        public MyDoublyLinkedListNode<T> Tail { get; set; }
        public int Count { get; private set; }
        public MyDoublyLinkedList(MyDoublyLinkedListNode<T> head)
        {
            Head = head;

            Count++;

            var h = Head;
            while (h.Next != null)
            {
                Count++;
                h = h.Next;
            }
            Tail = h;
        }

        public MyDoublyLinkedList(T data)
        {
            Head = new MyDoublyLinkedListNode<T>(data);
            Tail = Head;
            Count = 1;
        }

        public MyDoublyLinkedList() { }

        public void AddFirst(MyDoublyLinkedListNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException();
            if (Head == null)
                Head = Tail = node;
            else
            {
                node.Next = Head;
                Head.Prev = node;
                Head = node;
            }
            Count++;
        }

        public void AddLast(MyDoublyLinkedListNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException();
            if (Count == 0)
                AddFirst(node);
            else
            {
                node.Prev = Tail;
                Tail.Next = node;
                Tail = node;
                Count++;
            }
        }

        private bool ContainsNode(MyDoublyLinkedListNode<T> node)
        {
            bool isFound = false;
            var h = Head;
            var t = Tail;
            while (h != t && h != null && t != null)
            {
                if (h.Equals(node) || t.Equals(node))
                {
                    isFound = true;
                    break;
                }
                h = h.Next;
                t = t.Prev;
            }
            if (h == t && h == node && h != null)
                isFound = true;
            return isFound;
        }

        public void AddAfter(MyDoublyLinkedListNode<T> node, MyDoublyLinkedListNode<T> newNode)
        {
            if (node == null || newNode == null)
                throw new ArgumentNullException();
            if (!ContainsNode(node))
                throw new InvalidOperationException();
            if (node == Tail)
                AddLast(newNode);
            else
            {
                node.Next.Prev = newNode;
                newNode.Next = node.Next;
                node.Next = newNode;
                newNode.Prev = node;
                Count++;
            }
        }

        public void AddBefore(MyDoublyLinkedListNode<T> node, MyDoublyLinkedListNode<T> newNode)
        {
            if (node == null || newNode == null)
                throw new ArgumentNullException();
            if (!ContainsNode(node))
                throw new InvalidOperationException();
            if (node == Head)
                AddFirst(newNode);
            else
            {
                node.Prev.Next = newNode;
                newNode.Prev = node.Prev;
                newNode.Next = node;
                node.Prev = newNode;
                Count++;
            }
        }

        public MyDoublyLinkedListNode<T> Find(T value)
        {
            var h = Head;
            while (h != null)
            {
                if (h.Data.Equals(value))
                    return h;
                h = h.Next;
            }

            return null;
        }

        public MyDoublyLinkedListNode<T> FindLast(T value)
        {
            var h = Head;
            MyDoublyLinkedListNode<T> result = null;
            while (h != null)
            {
                if (h.Data.Equals(value))
                    result = h;
                h = h.Next;
            }

            return result;
        }


        public void Remove(MyDoublyLinkedListNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException();
            if (!ContainsNode(node))
                throw new InvalidOperationException();
            if (node == Head)
            {
                RemoveFirst();
                return;
            }
            if (node == Tail)
            {
                RemoveLast();
                return;
            }
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
            node.Next = null;
            node.Prev = null;
            Count--;
        }

        public void RemoveFirst()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            if (Count == 1)
                Head = Tail = null;
            else
            {
                Head.Next.Prev = null;
                Head = Head.Next;
            }

            Count--;
        }

        public void RemoveLast()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            if (Count == 1)
                RemoveFirst();
            else
            {
                Tail.Prev.Next = null;
                Tail = Tail.Prev;
                Count--;
            }
        }

        public bool Remove(T value)
        {
            var node = Find(value);
            if (node == null)
                return false;
            Remove(node);
            return true;
        }

        public void CopyTo(T[] array, int arrayStartIndex)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (arrayStartIndex < 0 || array.Length - arrayStartIndex < Count)
                throw new ArgumentOutOfRangeException();

            var h = Head;
            while (h != null)
            {
                array[arrayStartIndex++] = h.Data;
                h = h.Next;
            }
        }

        public void Clear()
        {
            Count = 0;
            Head = Tail = null;
        }

        public bool Contains(T value)
         => Find(value) != null;
    }
}