using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;
using FluentAssertions;
using Xunit;

namespace Tasks.UT
{
    public class LinkedListTests
    {
        private LinkedList _linkedList;

        public LinkedListTests()
        {
            _linkedList = new LinkedList();
        }

        [Fact]
        public void RemoveDups_Should_Check_True()
        {
            //arrange
            var list = new MyDoublyLinkedList<int>();

            var node1 = new MyDoublyLinkedListNode<int>(1);
            var node2 = new MyDoublyLinkedListNode<int>(3);
            var node3 = new MyDoublyLinkedListNode<int>(4);
            var node4 = new MyDoublyLinkedListNode<int>(4);
            var node5 = new MyDoublyLinkedListNode<int>(7);
            var node6 = new MyDoublyLinkedListNode<int>(-1);
            var node7 = new MyDoublyLinkedListNode<int>(1);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;
            node5.Next = node6;
            node6.Next = node7;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;
            node5.Prev = node4;
            node6.Prev = node5;
            node7.Prev = node6;

            list.Head = node1;

            var resultList = new MyDoublyLinkedList<int>();
            var node8 = new MyDoublyLinkedListNode<int>(1);
            var node9 = new MyDoublyLinkedListNode<int>(3);
            var node10 = new MyDoublyLinkedListNode<int>(4);
            var node11 = new MyDoublyLinkedListNode<int>(7);
            var node12 = new MyDoublyLinkedListNode<int>(-1);

            node8.Next = node9;
            node9.Next = node10;
            node10.Next = node11;
            node11.Next = node12;

            node9.Prev = node8;
            node10.Prev = node9;
            node11.Prev = node10;
            node12.Prev = node11;

            resultList.Head = node8;
           
            //act
            var result = _linkedList.RemoveDups(list);

            //assert
            var head = result.Head;
            var resultListHead = resultList.Head;
            while (head != null)
            {
                head.Data.ShouldBeEquivalentTo(resultListHead.Data);
                head = head.Next;
                resultListHead = resultListHead.Next;
            }
            resultListHead.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void RemoveDups_Should_Check_Empty_List()
        {
            //arrange
            var list = new MyDoublyLinkedList<int>();

            //act
            var result = _linkedList.RemoveDups(list);

            //assert
            result.Should().NotBe(null);
            result.Head.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void RemoveDups_Should_Check_One_Element()
        {
            //arrange
            var list = new MyDoublyLinkedList<int>();
            list.Head = new MyDoublyLinkedListNode<int>(1);

            var resultList = new MyDoublyLinkedList<int>();
            resultList.Head = new MyDoublyLinkedListNode<int>(1);

            //act
            var result = _linkedList.RemoveDups(list);

            //assert
            var head = result.Head;
            var resultListHead = resultList.Head;
            while (head != null)
            {
                head.Data.ShouldBeEquivalentTo(resultListHead.Data);
                head = head.Next;
                resultListHead = resultListHead.Next;
            }
            resultListHead.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void RemoveDups_Should_Check_One_Duplicate()
        {
            //arrange
            var list = new MyDoublyLinkedList<int>();
            var node1 = new MyDoublyLinkedListNode<int>(1);
            var node2 = new MyDoublyLinkedListNode<int>(1);

            node1.Next = node2;
            node2.Prev = node1;
            list.Head = node1;

            var resultList = new MyDoublyLinkedList<int>();
            resultList.Head = new MyDoublyLinkedListNode<int>(1);

            //act
            var result = _linkedList.RemoveDups(list);

            //assert
            var head = result.Head;
            var resultListHead = resultList.Head;
            while (head != null)
            {
                head.Data.ShouldBeEquivalentTo(resultListHead.Data);
                head = head.Next;
                resultListHead = resultListHead.Next;
            }
            resultListHead.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void RemoveDups_Should_Check_Multiple_Duplicate()
        {
            //arrange
            var list = new MyDoublyLinkedList<int>();
            var node1 = new MyDoublyLinkedListNode<int>(1);
            var node2 = new MyDoublyLinkedListNode<int>(1);
            var node3 = new MyDoublyLinkedListNode<int>(1);
            var node4 = new MyDoublyLinkedListNode<int>(1);
            var node5 = new MyDoublyLinkedListNode<int>(1);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;
            node5.Prev = node4;
            list.Head = node1;

            var resultList = new MyDoublyLinkedList<int>();
            resultList.Head = new MyDoublyLinkedListNode<int>(1);

            //act
            var result = _linkedList.RemoveDups(list);

            //assert
            var head = result.Head;
            var resultListHead = resultList.Head;
            while (head != null)
            {
                head.Data.ShouldBeEquivalentTo(resultListHead.Data);
                head = head.Next;
                resultListHead = resultListHead.Next;
            }
            resultListHead.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void RemoveDups_Should_Throw_If_Null()
        {
            //arrange

            //act
            Action act = () => _linkedList.RemoveDups(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ReturnKthToLast_Should_Throw_If_Null()
        {
            //arrange

            //act
            Action act = () => _linkedList.ReturnKthToLast(null, 1);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ReturnKthToLast_Should_Check_Correct_K()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();

            //act
            Action act = () => _linkedList.ReturnKthToLast(list, -1);

            //assert
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ReturnKthToLast_Should_Return_Correct_Value()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();

            var node1 = new MySinglyLinkedListNode<int>(1);
            var node2 = new MySinglyLinkedListNode<int>(3);
            var node3 = new MySinglyLinkedListNode<int>(4);
            var node4 = new MySinglyLinkedListNode<int>(4);
            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            list.Head = node1;

            //act
            var node = _linkedList.ReturnKthToLast(list, 2);

            //assert
            node.Data.ShouldBeEquivalentTo(3);
        }

        [Fact]
        public void ReturnKthToLast_Should_Return_Last()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();

            var node1 = new MySinglyLinkedListNode<int>(1);
            var node2 = new MySinglyLinkedListNode<int>(3);
            var node3 = new MySinglyLinkedListNode<int>(4);
            var node4 = new MySinglyLinkedListNode<int>(4);
            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            list.Head = node1;

            //act
            var node = _linkedList.ReturnKthToLast(list, 0);

            //assert
            node.Data.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void ReturnKthToLast_Should_Return_First()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();

            var node1 = new MySinglyLinkedListNode<int>(1);
            var node2 = new MySinglyLinkedListNode<int>(3);
            var node3 = new MySinglyLinkedListNode<int>(4);
            var node4 = new MySinglyLinkedListNode<int>(4);
            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            list.Head = node1;

            //act
            var node = _linkedList.ReturnKthToLast(list, 3);

            //assert
            node.Data.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void ReturnKthToLast_Should_Check_Depth()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();

            var node1 = new MySinglyLinkedListNode<int>(1);
            var node2 = new MySinglyLinkedListNode<int>(3);
            var node3 = new MySinglyLinkedListNode<int>(4);
            var node4 = new MySinglyLinkedListNode<int>(4);
            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            list.Head = node1;

            //act
            var node = _linkedList.ReturnKthToLast(list, 5);

            //assert
            node.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void DeleteMiddleNode_Should_Throw_If_Null()
        {
            //arrange

            //act
            Action act = () => _linkedList.DeleteMiddleNode(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void DeleteMiddleNode_Should_Check_Length_One()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();

            var node1 = new MySinglyLinkedListNode<int>(1);

            list.Head = node1;
            //act
            Action act = () => _linkedList.DeleteMiddleNode(node1);

            //assert
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void DeleteMiddleNode_Should_Delete_Middle()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();

            var node1 = new MySinglyLinkedListNode<int>(1);
            var node2 = new MySinglyLinkedListNode<int>(3);
            var node3 = new MySinglyLinkedListNode<int>(4);
            var node4 = new MySinglyLinkedListNode<int>(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            list.Head = node1;

            var counts = new Dictionary<int, int>();
            var head = list.Head;
            while (head != null)
            {
                if (!counts.ContainsKey(head.Data))
                    counts[head.Data] = 0;
                counts[head.Data]++;
                head = head.Next;
            }

            //act
            _linkedList.DeleteMiddleNode(node1);

            head = list.Head;
            while (head != null)
            {
                counts[head.Data]--;
                head = head.Next;
            }

            //assert
            counts.Values.Sum().ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void DeleteMiddleNode_Should_Previous_Last()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();

            var node1 = new MySinglyLinkedListNode<int>(1);
            var node2 = new MySinglyLinkedListNode<int>(3);

            node1.Next = node2;
            list.Head = node1;

            //act
            _linkedList.DeleteMiddleNode(node1);

            //assert
            list.Head.Data.ShouldBeEquivalentTo(3);
            list.Head.Next.Should().BeNull();
        }

        [Fact]
        public void Partition_Should_Throw_If_Null()
        {
            //arrange

            //act
            Action act = () => _linkedList.Partition(null, 0);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Partition_Should_Check_Example()
        {
            //arrange
            int partition = 5;
            var list = new MySinglyLinkedList<int>();

            var node1 = new MySinglyLinkedListNode<int>(3);
            var node2 = new MySinglyLinkedListNode<int>(5);
            var node3 = new MySinglyLinkedListNode<int>(8);
            var node4 = new MySinglyLinkedListNode<int>(5);
            var node5 = new MySinglyLinkedListNode<int>(10);
            var node6 = new MySinglyLinkedListNode<int>(2);
            var node7 = new MySinglyLinkedListNode<int>(1);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;
            node5.Next = node6;
            node6.Next = node7;

            list.Head = node1;

            var beforeCounts = new Dictionary<int, int>()
            {
                {3, 1},
                {1, 1},
                {2, 1}
            };
            var afterCounts = new Dictionary<int, int>()
            {
                {10, 1},
                {5, 2},
                {8, 1}
            };

            //act
            var result = _linkedList.Partition(list, partition);

            //assert
            var head = result.Head;
            while (head != null)
            {
                if (head.Data < partition)
                    beforeCounts[head.Data]--;
                else
                    afterCounts[head.Data]--;
                head = head.Next;
            }

            afterCounts.Values.Sum().ShouldBeEquivalentTo(0);
            beforeCounts.Values.Sum().ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Partition_Should_All_Left()
        {
            //arrange
            int partition = 11;
            var list = new MySinglyLinkedList<int>();

            var node1 = new MySinglyLinkedListNode<int>(3);
            var node2 = new MySinglyLinkedListNode<int>(5);
            var node3 = new MySinglyLinkedListNode<int>(8);
            var node4 = new MySinglyLinkedListNode<int>(5);
            var node5 = new MySinglyLinkedListNode<int>(10);
            var node6 = new MySinglyLinkedListNode<int>(2);
            var node7 = new MySinglyLinkedListNode<int>(1);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;
            node5.Next = node6;
            node6.Next = node7;

            list.Head = node1;

            var beforeCounts = new Dictionary<int, int>()
            {
                {3, 1},
                {1, 1},
                {2, 1},
                {10, 1},
                {5, 2},
                {8, 1}
            };

            //act
            var result = _linkedList.Partition(list, partition);

            //assert
            var head = result.Head;
            while (head != null)
            {
                if (head.Data < partition)
                    beforeCounts[head.Data]--;
                head = head.Next;
            }
            beforeCounts.Values.Sum().ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Partition_Should_All_Right()
        {
            //arrange
            int partition = 0;
            var list = new MySinglyLinkedList<int>();

            var node1 = new MySinglyLinkedListNode<int>(3);
            var node2 = new MySinglyLinkedListNode<int>(5);
            var node3 = new MySinglyLinkedListNode<int>(8);
            var node4 = new MySinglyLinkedListNode<int>(5);
            var node5 = new MySinglyLinkedListNode<int>(10);
            var node6 = new MySinglyLinkedListNode<int>(2);
            var node7 = new MySinglyLinkedListNode<int>(1);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;
            node5.Next = node6;
            node6.Next = node7;

            list.Head = node1;

            var afterCounts = new Dictionary<int, int>()
            {
                {3, 1},
                {1, 1},
                {2, 1},
                {10, 1},
                {5, 2},
                {8, 1}
            };

            //act
            var result = _linkedList.Partition(list, partition);

            //assert
            var head = result.Head;
            while (head != null)
            {
                if (head.Data >= partition)
                    afterCounts[head.Data]--;
                head = head.Next;
            }
            afterCounts.Values.Sum().ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Partition_Should_Check_Empty()
        {
            //arrange
            int partition = 0;
            var list = new MySinglyLinkedList<int>();

            //act
            var result = _linkedList.Partition(list, partition);

            //assert
            result.Head.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void SumLists_Backward_Should_Throw_If_null()
        {
            //arrange
            
            //act
            Action act = () => _linkedList.SumLists_Backward(null, null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SumLists_Backward_Should_Check_Empty()
        {
            //arrange
            var first = new MySinglyLinkedList<int>();
            var second = new MySinglyLinkedList<int>();
            var resultList= new MySinglyLinkedList<int>();

            //act
            var result = _linkedList.SumLists_Backward(first, second);

            //assert
            result.Count.ShouldBeEquivalentTo(resultList.Count);
            result.Head.Should().BeNull();
        }


        [Fact]
        public void SumLists_Backward_Should_Check_Example()
        {
            //arrange
            var first = new MySinglyLinkedList<int>();
            first.AddLast(new MySinglyLinkedListNode<int>(7));
            first.AddLast(new MySinglyLinkedListNode<int>(1));
            first.AddLast(new MySinglyLinkedListNode<int>(6));

            var second = new MySinglyLinkedList<int>();
            second.AddLast(new MySinglyLinkedListNode<int>(5));
            second.AddLast(new MySinglyLinkedListNode<int>(9));
            second.AddLast(new MySinglyLinkedListNode<int>(2));

            var resultList = new MySinglyLinkedList<int>();
            resultList.AddLast(new MySinglyLinkedListNode<int>(2));
            resultList.AddLast(new MySinglyLinkedListNode<int>(1));
            resultList.AddLast(new MySinglyLinkedListNode<int>(9));
            
            //act
            var result = _linkedList.SumLists_Backward(first, second);

            //assert
            result.Count.ShouldBeEquivalentTo(resultList.Count);
            var h1 = result.Head;
            var h2 = resultList.Head;

            while (h1 != null)
            {
                h1.Data.ShouldBeEquivalentTo(h2.Data);
                h1 = h1.Next;
                h2 = h2.Next;
            }
        }

        [Fact]
        public void SumLists_Backward_Should_Check_Different_Length()
        {
            //arrange
            var first = new MySinglyLinkedList<int>();
            first.AddLast(new MySinglyLinkedListNode<int>(1));
            first.AddLast(new MySinglyLinkedListNode<int>(5));
            first.AddLast(new MySinglyLinkedListNode<int>(9));

            var second = new MySinglyLinkedList<int>();
            second.AddLast(new MySinglyLinkedListNode<int>(2));
            second.AddLast(new MySinglyLinkedListNode<int>(3));
            second.AddLast(new MySinglyLinkedListNode<int>(6));
            second.AddLast(new MySinglyLinkedListNode<int>(7));

            var resultList = new MySinglyLinkedList<int>();
            resultList.AddLast(new MySinglyLinkedListNode<int>(3));
            resultList.AddLast(new MySinglyLinkedListNode<int>(8));
            resultList.AddLast(new MySinglyLinkedListNode<int>(5));
            resultList.AddLast(new MySinglyLinkedListNode<int>(8));

            //act
            var result = _linkedList.SumLists_Backward(first, second);

            //assert
            result.Count.ShouldBeEquivalentTo(resultList.Count);
            var h1 = result.Head;
            var h2 = resultList.Head;

            while (h1 != null)
            {
                h1.Data.ShouldBeEquivalentTo(h2.Data);
                h1 = h1.Next;
                h2 = h2.Next;
            }
        }

        [Fact]
        public void SumLists_Backward_Should_Check_Overflow()
        {
            //arrange
            var first = new MySinglyLinkedList<int>();
            first.AddLast(new MySinglyLinkedListNode<int>(9));
            first.AddLast(new MySinglyLinkedListNode<int>(7));
            first.AddLast(new MySinglyLinkedListNode<int>(8));

            var second = new MySinglyLinkedList<int>();
            second.AddLast(new MySinglyLinkedListNode<int>(6));
            second.AddLast(new MySinglyLinkedListNode<int>(8));
            second.AddLast(new MySinglyLinkedListNode<int>(5));

            var resultList = new MySinglyLinkedList<int>();
            resultList.AddLast(new MySinglyLinkedListNode<int>(5));
            resultList.AddLast(new MySinglyLinkedListNode<int>(6));
            resultList.AddLast(new MySinglyLinkedListNode<int>(4));
            resultList.AddLast(new MySinglyLinkedListNode<int>(1));

            //act
            var result = _linkedList.SumLists_Backward(first, second);

            //assert
            result.Count.ShouldBeEquivalentTo(resultList.Count);
            var h1 = result.Head;
            var h2 = resultList.Head;

            while (h1 != null)
            {
                h1.Data.ShouldBeEquivalentTo(h2.Data);
                h1 = h1.Next;
                h2 = h2.Next;
            }
        }

        [Fact]
        public void SumLists_Backward_Should_Check_Empty_And_Not_Length()
        {
            //arrange
            var first = new MySinglyLinkedList<int>();

            var second = new MySinglyLinkedList<int>();
            second.AddLast(new MySinglyLinkedListNode<int>(6));
            second.AddLast(new MySinglyLinkedListNode<int>(8));
            second.AddLast(new MySinglyLinkedListNode<int>(5));

            var resultList = new MySinglyLinkedList<int>();
            resultList.AddLast(new MySinglyLinkedListNode<int>(6));
            resultList.AddLast(new MySinglyLinkedListNode<int>(8));
            resultList.AddLast(new MySinglyLinkedListNode<int>(5));

            //act
            var result = _linkedList.SumLists_Backward(first, second);

            //assert
            result.Count.ShouldBeEquivalentTo(resultList.Count);
            var h1 = result.Head;
            var h2 = resultList.Head;

            while (h1 != null)
            {
                h1.Data.ShouldBeEquivalentTo(h2.Data);
                h1 = h1.Next;
                h2 = h2.Next;
            }
        }

        [Fact]
        public void SumLists_Backward_Should_Check_Nines()
        {
            //arrange
            var first = new MySinglyLinkedList<int>();
            first.AddLast(new MySinglyLinkedListNode<int>(1));
                
            var second = new MySinglyLinkedList<int>();
            second.AddLast(new MySinglyLinkedListNode<int>(9));
            second.AddLast(new MySinglyLinkedListNode<int>(9));
            second.AddLast(new MySinglyLinkedListNode<int>(9));

            var resultList = new MySinglyLinkedList<int>();
            resultList.AddLast(new MySinglyLinkedListNode<int>(0));
            resultList.AddLast(new MySinglyLinkedListNode<int>(0));
            resultList.AddLast(new MySinglyLinkedListNode<int>(0));
            resultList.AddLast(new MySinglyLinkedListNode<int>(1));

            //act
            var result = _linkedList.SumLists_Backward(first, second);

            //assert
            result.Count.ShouldBeEquivalentTo(resultList.Count);
            var h1 = result.Head;
            var h2 = resultList.Head;

            while (h1 != null)
            {
                h1.Data.ShouldBeEquivalentTo(h2.Data);
                h1 = h1.Next;
                h2 = h2.Next;
            }
        }

        [Fact]
        public void SumLists_Forward_Should_Throw_If_null()
        {
            //arrange

            //act
            Action act = () => _linkedList.SumLists_Forward(null, null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SumLists_Forward_Should_Check_Empty()
        {
            //arrange
            var first = new MySinglyLinkedList<int>();
            var second = new MySinglyLinkedList<int>();
            var resultList = new MySinglyLinkedList<int>();

            //act
            var result = _linkedList.SumLists_Forward(first, second);

            //assert
            result.Count.ShouldBeEquivalentTo(resultList.Count);
            result.Head.Should().BeNull();
        }


        [Fact]
        public void SumLists_Forward_Should_Check_Example()
        {
            //arrange
            var first = new MySinglyLinkedList<int>();
            first.AddLast(new MySinglyLinkedListNode<int>(6));
            first.AddLast(new MySinglyLinkedListNode<int>(1));
            first.AddLast(new MySinglyLinkedListNode<int>(7));

            var second = new MySinglyLinkedList<int>();
            second.AddLast(new MySinglyLinkedListNode<int>(2));
            second.AddLast(new MySinglyLinkedListNode<int>(9));
            second.AddLast(new MySinglyLinkedListNode<int>(5));

            var resultList = new MySinglyLinkedList<int>();
            resultList.AddLast(new MySinglyLinkedListNode<int>(9));
            resultList.AddLast(new MySinglyLinkedListNode<int>(1));
            resultList.AddLast(new MySinglyLinkedListNode<int>(2));

            //act
            var result = _linkedList.SumLists_Forward(first, second);

            //assert
            result.Count.ShouldBeEquivalentTo(resultList.Count);
            var h1 = result.Head;
            var h2 = resultList.Head;

            while (h1 != null)
            {
                h1.Data.ShouldBeEquivalentTo(h2.Data);
                h1 = h1.Next;
                h2 = h2.Next;
            }
        }

        [Fact]
        public void SumLists_Forward_Should_Check_Different_Length()
        {
            //arrange
            var first = new MySinglyLinkedList<int>();
            first.AddLast(new MySinglyLinkedListNode<int>(9));
            first.AddLast(new MySinglyLinkedListNode<int>(5));
            first.AddLast(new MySinglyLinkedListNode<int>(1));

            var second = new MySinglyLinkedList<int>();
            second.AddLast(new MySinglyLinkedListNode<int>(7));
            second.AddLast(new MySinglyLinkedListNode<int>(6));
            second.AddLast(new MySinglyLinkedListNode<int>(3));
            second.AddLast(new MySinglyLinkedListNode<int>(2));

            var resultList = new MySinglyLinkedList<int>();
            resultList.AddLast(new MySinglyLinkedListNode<int>(8));
            resultList.AddLast(new MySinglyLinkedListNode<int>(5));
            resultList.AddLast(new MySinglyLinkedListNode<int>(8));
            resultList.AddLast(new MySinglyLinkedListNode<int>(3));

            //act
            var result = _linkedList.SumLists_Forward(first, second);

            //assert
            result.Count.ShouldBeEquivalentTo(resultList.Count);
            var h1 = result.Head;
            var h2 = resultList.Head;

            while (h1 != null)
            {
                h1.Data.ShouldBeEquivalentTo(h2.Data);
                h1 = h1.Next;
                h2 = h2.Next;
            }
        }

        [Fact]
        public void SumLists_Forward_Should_Check_Overflow()
        {
            //arrange
            var first = new MySinglyLinkedList<int>();
            first.AddLast(new MySinglyLinkedListNode<int>(8));
            first.AddLast(new MySinglyLinkedListNode<int>(7));
            first.AddLast(new MySinglyLinkedListNode<int>(9));

            var second = new MySinglyLinkedList<int>();
            second.AddLast(new MySinglyLinkedListNode<int>(5));
            second.AddLast(new MySinglyLinkedListNode<int>(8));
            second.AddLast(new MySinglyLinkedListNode<int>(6));

            var resultList = new MySinglyLinkedList<int>();
            resultList.AddLast(new MySinglyLinkedListNode<int>(1));
            resultList.AddLast(new MySinglyLinkedListNode<int>(4));
            resultList.AddLast(new MySinglyLinkedListNode<int>(6));
            resultList.AddLast(new MySinglyLinkedListNode<int>(5));

            //act
            var result = _linkedList.SumLists_Forward(first, second);

            //assert
            result.Count.ShouldBeEquivalentTo(resultList.Count);
            var h1 = result.Head;
            var h2 = resultList.Head;

            while (h1 != null)
            {
                h1.Data.ShouldBeEquivalentTo(h2.Data);
                h1 = h1.Next;
                h2 = h2.Next;
            }
        }

        [Fact]
        public void SumLists_Forward_Should_Check_Empty_And_Not_Length()
        {
            //arrange
            var first = new MySinglyLinkedList<int>();

            var second = new MySinglyLinkedList<int>();
            second.AddLast(new MySinglyLinkedListNode<int>(5));
            second.AddLast(new MySinglyLinkedListNode<int>(8));
            second.AddLast(new MySinglyLinkedListNode<int>(6));

            var resultList = new MySinglyLinkedList<int>();
            resultList.AddLast(new MySinglyLinkedListNode<int>(5));
            resultList.AddLast(new MySinglyLinkedListNode<int>(8));
            resultList.AddLast(new MySinglyLinkedListNode<int>(6));

            //act
            var result = _linkedList.SumLists_Forward(first, second);

            //assert
            result.Count.ShouldBeEquivalentTo(resultList.Count);
            var h1 = result.Head;
            var h2 = resultList.Head;

            while (h1 != null)
            {
                h1.Data.ShouldBeEquivalentTo(h2.Data);
                h1 = h1.Next;
                h2 = h2.Next;
            }
        }

        [Fact]
        public void SumLists_Forward_Should_Check_Nines()
        {
            //arrange
            var first = new MySinglyLinkedList<int>();
            first.AddLast(new MySinglyLinkedListNode<int>(1));

            var second = new MySinglyLinkedList<int>();
            second.AddLast(new MySinglyLinkedListNode<int>(9));
            second.AddLast(new MySinglyLinkedListNode<int>(9));
            second.AddLast(new MySinglyLinkedListNode<int>(9));

            var resultList = new MySinglyLinkedList<int>();
            resultList.AddLast(new MySinglyLinkedListNode<int>(1));
            resultList.AddLast(new MySinglyLinkedListNode<int>(0));
            resultList.AddLast(new MySinglyLinkedListNode<int>(0));
            resultList.AddLast(new MySinglyLinkedListNode<int>(0));

            //act
            var result = _linkedList.SumLists_Forward(first, second);

            //assert
            result.Count.ShouldBeEquivalentTo(resultList.Count);
            var h1 = result.Head;
            var h2 = resultList.Head;

            while (h1 != null)
            {
                h1.Data.ShouldBeEquivalentTo(h2.Data);
                h1 = h1.Next;
                h2 = h2.Next;
            }
        }

        [Fact]
        public void Palindrome_Should_Check_Is_Null()
        {
            //arrange

            //act
            Action act = () => _linkedList.Palindrome(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Palindrome_Should_Check_Empty_List()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();

            //act
            var result = _linkedList.Palindrome(list);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Palindrome_Should_Check_Palindrome_True_Odd_Length()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();
            list.AddLast(new MySinglyLinkedListNode<int>(1));
            list.AddLast(new MySinglyLinkedListNode<int>(2));
            list.AddLast(new MySinglyLinkedListNode<int>(3));
            list.AddLast(new MySinglyLinkedListNode<int>(2));
            list.AddLast(new MySinglyLinkedListNode<int>(1));

            //act
            var result = _linkedList.Palindrome(list);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Palindrome_Should_Check_Palindrome_False_Odd_Length()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();
            list.AddLast(new MySinglyLinkedListNode<int>(1));
            list.AddLast(new MySinglyLinkedListNode<int>(2));
            list.AddLast(new MySinglyLinkedListNode<int>(3));
            list.AddLast(new MySinglyLinkedListNode<int>(3));
            list.AddLast(new MySinglyLinkedListNode<int>(1));

            //act
            var result = _linkedList.Palindrome(list);

            //assert
            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Palindrome_Should_Check_Palindrome_True_Even_Length()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();
            list.AddLast(new MySinglyLinkedListNode<int>(1));
            list.AddLast(new MySinglyLinkedListNode<int>(2));
            list.AddLast(new MySinglyLinkedListNode<int>(3));
            list.AddLast(new MySinglyLinkedListNode<int>(3));
            list.AddLast(new MySinglyLinkedListNode<int>(2));
            list.AddLast(new MySinglyLinkedListNode<int>(1));

            //act
            var result = _linkedList.Palindrome(list);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Palindrome_Should_Check_Palindrome_False_Even_Length()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();
            list.AddLast(new MySinglyLinkedListNode<int>(1));
            list.AddLast(new MySinglyLinkedListNode<int>(2));
            list.AddLast(new MySinglyLinkedListNode<int>(3));
            list.AddLast(new MySinglyLinkedListNode<int>(3));
            list.AddLast(new MySinglyLinkedListNode<int>(4));
            list.AddLast(new MySinglyLinkedListNode<int>(1));

            //act
            var result = _linkedList.Palindrome(list);

            //assert
            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Palindrome_Should_Check_Palindrome_Length_One()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();
            list.AddLast(new MySinglyLinkedListNode<int>(1));

            //act
            var result = _linkedList.Palindrome(list);

            //assert
            result.ShouldBeEquivalentTo(true);
        }
    }
}
