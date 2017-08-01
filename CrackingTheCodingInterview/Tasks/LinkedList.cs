using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;

namespace Tasks
{
    public class LinkedList
    {
        public MyDoublyLinkedList<int> RemoveDups(MyDoublyLinkedList<int> list)
        {
            if (list == null)
                throw new ArgumentNullException();
            var head = list.Head;

            while (head != null)
            {
                var current = head.Next;
                while (current != null)
                {
                    if (current.Data == head.Data)
                    {
                        current.Prev.Next = current.Next;
                        if (current.Next != null)
                            current.Next.Prev = current.Prev;
                    }
                    current = current.Next;
                }
                head = head.Next;
            }

            return list;
        }

        public MySinglyLinkedListNode<int> ReturnKthToLast(MySinglyLinkedList<int> list, int k)
        {
            if (list == null)
                throw new ArgumentNullException();
            if (k < 0)
                throw new ArgumentOutOfRangeException();
            int offset = 0;

            var result = ReturnKthToLastHelper(list.Head, k, ref offset);
            return result;
        }

        private MySinglyLinkedListNode<int> ReturnKthToLastHelper(
            MySinglyLinkedListNode<int> head, int k, ref int offset)
        {
            if (head.Next != null)
            {
                var res = ReturnKthToLastHelper(head.Next, k, ref offset);
                if (res != null)
                    return res;
            }
            if (k == offset)
                return head;

            offset++;
            return null;
        }

        public void DeleteMiddleNode(MySinglyLinkedListNode<int> node)
        {
            if (node == null)
                throw new ArgumentNullException();
            if (node.Next == null)
                throw new ArgumentException();

            var head = node.Next;
            MySinglyLinkedListNode<int> prev = null;
            while (head != null)
            {
                node.Data = head.Data;

                prev = node;
                node = node.Next;
                head = head.Next;
            }
            if (prev != null)
                prev.Next = null;
        }

        public MySinglyLinkedList<int> Partition(MySinglyLinkedList<int> list, int partition)
        {
            if (list == null)
                throw new ArgumentNullException();
            MySinglyLinkedList<int> lowerList = new MySinglyLinkedList<int>();
            MySinglyLinkedList<int> higherList = new MySinglyLinkedList<int>();

            var head = list.Head;
            MySinglyLinkedListNode<int> lowerHead = null;
            MySinglyLinkedListNode<int> higherHead = null;
            while (head != null)
            {
                if (head.Data < partition)
                {
                    if (lowerHead == null)
                    {
                        lowerList.Head = new MySinglyLinkedListNode<int>(head.Data);
                        lowerHead = lowerList.Head;
                    }
                    else
                    {
                        lowerHead.Next = new MySinglyLinkedListNode<int>(head.Data);
                        lowerHead = lowerHead.Next;
                    }
                }
                else
                {
                    if (higherHead == null)
                    {
                        higherList.Head = new MySinglyLinkedListNode<int>(head.Data);
                        higherHead = higherList.Head;
                    }
                    else
                    {
                        higherHead.Next = new MySinglyLinkedListNode<int>(head.Data);
                        higherHead = higherHead.Next;
                    }
                }
                head = head.Next;
            }

            higherHead = higherList.Head;

            while (higherHead != null)
            {
                if (lowerHead == null)
                {
                    lowerList.Head = new MySinglyLinkedListNode<int>(higherHead.Data);
                    lowerHead = lowerList.Head;
                }
                else
                {
                    lowerHead.Next = new MySinglyLinkedListNode<int>(higherHead.Data);
                    lowerHead = lowerHead.Next;
                }
              
                higherHead = higherHead.Next;
            }


            return lowerList;
        }
    }
}
