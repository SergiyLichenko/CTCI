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

        public MySinglyLinkedList<int> SumLists_Backward(MySinglyLinkedList<int> first,
            MySinglyLinkedList<int> second)
        {
            if (first == null || second == null)
                throw new ArgumentNullException();

            var h1 = first.Head;
            var h2 = second.Head;
            var result = new MySinglyLinkedList<int>();

            int carry = 0;
            while (h1 != null && h2 != null)
            {
                var number = h1.Data + h2.Data + carry;
                if (number > 9)
                {
                    carry = 1;
                    number %= 10;
                }
                else
                    carry = 0;
                result.AddLast(new MySinglyLinkedListNode<int>(number));

                h1 = h1.Next;
                h2 = h2.Next;
            }
            MySinglyLinkedListNode<int> remainder = h1 ?? h2;

            while (remainder != null)
            {
                var number = remainder.Data + carry;
                if (number > 9)
                {
                    number %= 10;
                    carry = 1;
                }
                else
                    carry = 0;

                result.AddLast(new MySinglyLinkedListNode<int>(number));
                remainder = remainder.Next;
            }
            if (carry != 0)
                result.AddLast(new MySinglyLinkedListNode<int>(carry));

            return result;
        }

        public MySinglyLinkedList<int> SumLists_Forward(MySinglyLinkedList<int> first,
            MySinglyLinkedList<int> second)
        {
            if (first == null || second == null)
                throw new ArgumentNullException();

            if (first.Count != second.Count)
            {
                var count = Math.Abs(first.Count - second.Count);
                var smallerList = first.Count > second.Count ? second : first;
                while(count-->0)
                    smallerList.AddFirst(new MySinglyLinkedListNode<int>(0));
            }

            var result = new MySinglyLinkedList<int>();
            var carry = SumLists_ForwardHelper(first.Head, second.Head, result);

            if (carry)
                result.AddFirst(new MySinglyLinkedListNode<int>(1));

            return result;
        }


        private bool SumLists_ForwardHelper(MySinglyLinkedListNode<int> first,
            MySinglyLinkedListNode<int> second,
            MySinglyLinkedList<int> result)
        {
            if (first == null || second == null)
                return false;
            bool carry = false;
            if (first.Next != null && second.Next != null)
                carry = SumLists_ForwardHelper(first.Next,second.Next,result);

            var number = first.Data + second.Data + (carry ? 1 : 0);
            result.AddFirst(new MySinglyLinkedListNode<int>(number % 10)); ;
            return number > 9;
        }
    }
}
