using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MySinglyLinkedList<T>
    {
        public virtual MySinglyLinkedListNode<T> Head { get; set; }

        public int Count { get; private set; }

        public MySinglyLinkedList(MySinglyLinkedListNode<T> head)
        {
            Head = head;

            var h = head;
            while (h != null)
            {
                Count++;
                h = h.Next;
            }
        }

        public MySinglyLinkedList(T data)
        {
            Head = new MySinglyLinkedListNode<T>(data);
            Count = 1;
        }

        public MySinglyLinkedList()
        {

        }

        public void AddAfter(MySinglyLinkedListNode<T> node, MySinglyLinkedListNode<T> newNode)
        {
            if (node == null || newNode == null)
                throw new ArgumentNullException();
            if (Count == 0)
                throw new ArgumentException();
            MySinglyLinkedListNode<T> head = Head;

            while (head != null && head != node)
                head = head.Next;
            if (head == null)
                throw new ArgumentException();

            newNode.Next = head.Next;
            head.Next = newNode;
            Count++;
        }

        public void AddFirst(MySinglyLinkedListNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException();

            if (Head == null)
                Head = node;
            else
            {
                node.Next = Head;
                Head = node;
            }
            Count++;
        }

        public void AddLast(MySinglyLinkedListNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException();
            if (Head == null)
                Head = node;
            else
            {
                var h = Head;
                while (h.Next != null)
                    h = h.Next;
                h.Next = node;
            }
            Count++;
        }

        public void AddBefore(MySinglyLinkedListNode<T> node, MySinglyLinkedListNode<T> newNode)
        {
            if (node == null || newNode == null)
                throw new ArgumentNullException();
            if (Count == 0)
                throw new ArgumentException();

            if (node == Head)
                AddFirst(newNode);
            else
            {
                var h = Head;
                while (h != null && h.Next != node)
                    h = h.Next;
                if (h == null)
                    throw new ArgumentException();
                newNode.Next = h.Next;
                h.Next = newNode;
                Count++;
            }
        }

        public void Clear()
        {
            Head = null;
            Count = 0;
        }

        public MySinglyLinkedListNode<T> Find(T value)
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

        public bool Remove(MySinglyLinkedListNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException();

            var h = Head;
            while (h != null)
            {
                if (h.Next == node)
                {
                    h.Next = h.Next.Next;
                    Count--;
                    return true;
                }
                h = h.Next;
            }
            return false;
        }

        public void RemoveFirst()
        {
            if (Head == null)
                throw new InvalidOperationException();
            Count--;
            Head = Head.Next;
        }

        public void RemoveLast()
        {
            if (Head == null)
                throw new InvalidOperationException();
            if (Head.Next == null)
                RemoveFirst();
            else
            {
                var h = Head;
                while (h.Next.Next != null)
                    h = h.Next;
                h.Next = null;
                Count--;
            }
        }

        public bool Contains(MySinglyLinkedListNode<T> node)
            => Find(node.Data) != null;

        public MySinglyLinkedListNode<T> FindLast(T value)
        {
            return FindLastHelper(Head, value);
        }

        private MySinglyLinkedListNode<T> FindLastHelper(
            MySinglyLinkedListNode<T> node, T value)
        {
            if (node.Next != null)
            {
                var res = FindLastHelper(node.Next, value);
                if (res != null)
                    return res;
            }
            if (node.Data.Equals(value))
                return node;
            return null;
        }

        public void CopyTo(T[] array, int startArrayIndex)
        {
            if (array == null || array.Length - startArrayIndex < Count ||
                startArrayIndex < 0)
                throw new ArgumentException();
            var h = Head;
            while (h != null)
            {
                array[startArrayIndex++] = h.Data;
                h = h.Next;
            }
        }
    }

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
