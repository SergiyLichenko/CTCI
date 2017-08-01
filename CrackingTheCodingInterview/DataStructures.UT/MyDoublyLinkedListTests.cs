using System;
using FluentAssertions;
using Xunit;

namespace DataStructures.UT
{
    public class MyDoublyLinkedListTests
    {
        [Fact]
        public void Should_Create_Empty_List()
        {
            //arrange

            //act
            var list = new MyDoublyLinkedList<int>();

            //assert
            list.Head.ShouldBeEquivalentTo(null);
            list.Tail.ShouldBeEquivalentTo(null);
            list.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Should_Create_List_With_Chain_Nodes()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(1);
            var node2 = new MyDoublyLinkedListNode<int>(2);
            var node3 = new MyDoublyLinkedListNode<int>(3);
            var node4 = new MyDoublyLinkedListNode<int>(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;

            //act
            var list = new MyDoublyLinkedList<int>(node1);

            //assert
            list.Head.ShouldBeEquivalentTo(node1);
            list.Tail.ShouldBeEquivalentTo(node4);
            list.Count.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void Should_Create_List_With_Value()
        {
            //arrange
            int value = 5;

            //act
            var list = new MyDoublyLinkedList<int>(value);

            //assert
            list.Head.Should().NotBeNull();
            list.Head.Data.ShouldBeEquivalentTo(value);
            list.Tail.Should().NotBeNull();
            list.Tail.Data.ShouldBeEquivalentTo(value);
            list.Count.ShouldBeEquivalentTo(1);
        }


        [Fact]
        public void Should_Add_First_Throw_If_Null()
        {
            //arrange
            var list = new MyDoublyLinkedList<int>();

            //act
            Action act = () => list.AddFirst(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Add_First_When_List_Is_Empty()
        {
            //arrange
            var list = new MyDoublyLinkedList<int>();

            var node = new MyDoublyLinkedListNode<int>(1);
            //act
            list.AddFirst(node);

            //assert
            list.Count.ShouldBeEquivalentTo(1);
            list.Head.ShouldBeEquivalentTo(list.Tail);
            list.Head.ShouldBeEquivalentTo(node);
        }

        [Fact]
        public void Should_Add_First_When_List_Length_Greater_One()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(1);
            var node2 = new MyDoublyLinkedListNode<int>(2);
            var node3 = new MyDoublyLinkedListNode<int>(3);
            var node4 = new MyDoublyLinkedListNode<int>(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;

            var list = new MyDoublyLinkedList<int>(node1);
            var node5 = new MyDoublyLinkedListNode<int>(5);

            //act
            list.AddFirst(node5);

            //assert
            list.Count.ShouldBeEquivalentTo(5);
            list.Head.ShouldBeEquivalentTo(node5);
            list.Tail.ShouldBeEquivalentTo(node4);
            list.Head.Next.ShouldBeEquivalentTo(node1);
            list.Head.Next.Next.ShouldBeEquivalentTo(node2);
            list.Head.Next.Next.Next.ShouldBeEquivalentTo(node3);
            list.Head.Next.Next.Next.Next.ShouldBeEquivalentTo(node4);
        }

        [Fact]
        public void Should_Add_Last_Throw_If_Null()
        {
            //arrange
            var list = new MyDoublyLinkedList<int>();

            //act
            Action act = () => list.AddLast(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Add_Last_When_List_Is_Empty()
        {
            //arrange
            var list = new MyDoublyLinkedList<int>();

            var node = new MyDoublyLinkedListNode<int>(1);
            //act
            list.AddLast(node);

            //assert
            list.Count.ShouldBeEquivalentTo(1);
            list.Head.ShouldBeEquivalentTo(list.Tail);
            list.Head.ShouldBeEquivalentTo(node);
        }

        [Fact]
        public void Should_Add_Last_When_List_Length_Greater_One()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(1);
            var node2 = new MyDoublyLinkedListNode<int>(2);
            var node3 = new MyDoublyLinkedListNode<int>(3);
            var node4 = new MyDoublyLinkedListNode<int>(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;

            var list = new MyDoublyLinkedList<int>(node1);
            var node5 = new MyDoublyLinkedListNode<int>(5);

            //act
            list.AddLast(node5);

            //assert
            list.Count.ShouldBeEquivalentTo(5);
            list.Head.ShouldBeEquivalentTo(node1);
            list.Tail.ShouldBeEquivalentTo(node5);
            list.Head.Next.ShouldBeEquivalentTo(node2);
            list.Head.Next.Next.ShouldBeEquivalentTo(node3);
            list.Head.Next.Next.Next.ShouldBeEquivalentTo(node4);
            list.Head.Next.Next.Next.Next.ShouldBeEquivalentTo(node5);
        }

        [Fact]
        public void Should_Add_After_Throw_If_Null()
        {
            //arrange
            var list = new MyDoublyLinkedList<int>();

            //act
            Action act = () => list.AddAfter(null, null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Add_After_Throw_Does_Not_Have_Node()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(1);
            var node2 = new MyDoublyLinkedListNode<int>(2);
            var node3 = new MyDoublyLinkedListNode<int>(3);
            var node4 = new MyDoublyLinkedListNode<int>(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;

            var list = new MyDoublyLinkedList<int>(node1);
            var node5 = new MyDoublyLinkedListNode<int>(5);

            //act
            Action act = () => list.AddAfter(new MyDoublyLinkedListNode<int>(6), node5);

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Should_Add_After()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(1);
            var node2 = new MyDoublyLinkedListNode<int>(2);
            var node3 = new MyDoublyLinkedListNode<int>(3);
            var node4 = new MyDoublyLinkedListNode<int>(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;

            var list = new MyDoublyLinkedList<int>(node1);
            var node5 = new MyDoublyLinkedListNode<int>(5);

            //act
            list.AddAfter(node2, node5);

            //assert
            list.Count.ShouldBeEquivalentTo(5);
            list.Head.ShouldBeEquivalentTo(node1);
            list.Tail.ShouldBeEquivalentTo(node4);

            list.Head.Next.ShouldBeEquivalentTo(node2);
            list.Head.Next.Next.ShouldBeEquivalentTo(node5);
            list.Head.Next.Next.Next.ShouldBeEquivalentTo(node3);
            list.Head.Next.Next.Next.Next.ShouldBeEquivalentTo(node4);
        }

        [Fact]
        public void Should_Add_After_Check_Tail()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(1);
            var node2 = new MyDoublyLinkedListNode<int>(2);
            var node3 = new MyDoublyLinkedListNode<int>(3);
            var node4 = new MyDoublyLinkedListNode<int>(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;

            var list = new MyDoublyLinkedList<int>(node1);
            var node5 = new MyDoublyLinkedListNode<int>(5);

            //act
            list.AddAfter(node4, node5);

            //assert
            list.Count.ShouldBeEquivalentTo(5);
            list.Head.ShouldBeEquivalentTo(node1);
            list.Tail.ShouldBeEquivalentTo(node5);

            list.Head.Next.ShouldBeEquivalentTo(node2);
            list.Head.Next.Next.ShouldBeEquivalentTo(node3);
            list.Head.Next.Next.Next.ShouldBeEquivalentTo(node4);
            list.Head.Next.Next.Next.Next.ShouldBeEquivalentTo(node5);
        }

        [Fact]
        public void Should_Add_Before_Throw_If_Null()
        {
            //arrange
            var list = new MyDoublyLinkedList<int>();

            //act
            Action act = () => list.AddBefore(null, null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Add_Before_Throw_Does_Not_Have_Node()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(1);
            var node2 = new MyDoublyLinkedListNode<int>(2);
            var node3 = new MyDoublyLinkedListNode<int>(3);
            var node4 = new MyDoublyLinkedListNode<int>(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;

            var list = new MyDoublyLinkedList<int>(node1);
            var node5 = new MyDoublyLinkedListNode<int>(5);

            //act
            Action act = () => list.AddBefore(new MyDoublyLinkedListNode<int>(6), node5);

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Should_Add_Before()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(1);
            var node2 = new MyDoublyLinkedListNode<int>(2);
            var node3 = new MyDoublyLinkedListNode<int>(3);
            var node4 = new MyDoublyLinkedListNode<int>(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;

            var list = new MyDoublyLinkedList<int>(node1);
            var node5 = new MyDoublyLinkedListNode<int>(5);

            //act
            list.AddBefore(node3, node5);

            //assert
            list.Count.ShouldBeEquivalentTo(5);
            list.Head.ShouldBeEquivalentTo(node1);
            list.Tail.ShouldBeEquivalentTo(node4);

            list.Head.Next.ShouldBeEquivalentTo(node2);
            list.Head.Next.Next.ShouldBeEquivalentTo(node5);
            list.Head.Next.Next.Next.ShouldBeEquivalentTo(node3);
            list.Head.Next.Next.Next.Next.ShouldBeEquivalentTo(node4);
        }

        [Fact]
        public void Should_Add_Before_Check_Head()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(1);

            var list = new MyDoublyLinkedList<int>(node1);
            var node2 = new MyDoublyLinkedListNode<int>(2);

            //act
            list.AddBefore(node1, node2);

            //assert
            list.Count.ShouldBeEquivalentTo(2);
            list.Head.ShouldBeEquivalentTo(node2);
            list.Tail.ShouldBeEquivalentTo(node1);

            list.Head.Next.ShouldBeEquivalentTo(node1);
        }

        [Fact]
        public void Should_Find()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(1);
            var node2 = new MyDoublyLinkedListNode<int>(2);
            var node3 = new MyDoublyLinkedListNode<int>(3);
            var node4 = new MyDoublyLinkedListNode<int>(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;

            var list = new MyDoublyLinkedList<int>(node1);

            //act
            var result = list.Find(3);

            //assert
            result.ShouldBeEquivalentTo(node3);
        }

        [Fact]
        public void Should_Find_Return_Null_If_Is_Not_Found()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(1);
            var node2 = new MyDoublyLinkedListNode<int>(2);
            var node3 = new MyDoublyLinkedListNode<int>(3);
            var node4 = new MyDoublyLinkedListNode<int>(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;

            var list = new MyDoublyLinkedList<int>(node1);

            //act
            var result = list.Find(7);

            //assert
            result.Should().BeNull();
        }

        [Fact]
        public void Should_Find_Check_Order()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(2);
            var node2 = new MyDoublyLinkedListNode<int>(4);
            var node3 = new MyDoublyLinkedListNode<int>(3);
            var node4 = new MyDoublyLinkedListNode<int>(1);
            var node5 = new MyDoublyLinkedListNode<int>(3);
            var node6 = new MyDoublyLinkedListNode<int>(6);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;
            node5.Next = node6;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;
            node5.Prev = node4;
            node6.Prev = node5;

            var list = new MyDoublyLinkedList<int>(node1);

            //act
            var result = list.Find(3);

            //assert
            result.ShouldBeEquivalentTo(node3);
        }

        [Fact]
        public void Should_FindLast()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(1);
            var node2 = new MyDoublyLinkedListNode<int>(2);
            var node3 = new MyDoublyLinkedListNode<int>(3);
            var node4 = new MyDoublyLinkedListNode<int>(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;

            var list = new MyDoublyLinkedList<int>(node1);

            //act
            var result = list.FindLast(3);

            //assert
            result.ShouldBeEquivalentTo(node3);
        }

        [Fact]
        public void Should_FindLast_Return_Null_If_Is_Not_Found()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(1);
            var node2 = new MyDoublyLinkedListNode<int>(2);
            var node3 = new MyDoublyLinkedListNode<int>(3);
            var node4 = new MyDoublyLinkedListNode<int>(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;

            var list = new MyDoublyLinkedList<int>(node1);

            //act
            var result = list.FindLast(7);

            //assert
            result.Should().BeNull();
        }

        [Fact]
        public void Should_FindLast_Check_Order()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(2);
            var node2 = new MyDoublyLinkedListNode<int>(4);
            var node3 = new MyDoublyLinkedListNode<int>(3);
            var node4 = new MyDoublyLinkedListNode<int>(1);
            var node5 = new MyDoublyLinkedListNode<int>(3);
            var node6 = new MyDoublyLinkedListNode<int>(6);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;
            node5.Next = node6;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;
            node5.Prev = node4;
            node6.Prev = node5;

            var list = new MyDoublyLinkedList<int>(node1);

            //act
            var result = list.FindLast(3);

            //assert
            result.ShouldBeEquivalentTo(node5);
        }

        [Fact]
        public void Should_FindLast_Odd_Length()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(2);
            var node2 = new MyDoublyLinkedListNode<int>(4);
            var node3 = new MyDoublyLinkedListNode<int>(3);

            node1.Next = node2;
            node2.Next = node3;

            node2.Prev = node1;
            node3.Prev = node2;

            var list = new MyDoublyLinkedList<int>(node1);

            //act
            var result = list.FindLast(4);

            //assert
            result.ShouldBeEquivalentTo(node2);
        }

        [Fact]
        public void Should_FindLast_Even_Length()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(2);
            var node2 = new MyDoublyLinkedListNode<int>(4);
            var node3 = new MyDoublyLinkedListNode<int>(3);
            var node4 = new MyDoublyLinkedListNode<int>(5);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;

            var list = new MyDoublyLinkedList<int>(node1);

            //act
            var result = list.FindLast(4);

            //assert
            result.ShouldBeEquivalentTo(node2);
        }

        [Fact]
        public void Should_RemoveFirst_Throw_If_Empty()
        {
            //arrange
            var list = new MyDoublyLinkedList<int>();

            //act
            Action act = () => list.RemoveFirst();

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Should_Remove_First_When_Length_One()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(2);
            var list = new MyDoublyLinkedList<int>(node1);

            //act
            list.RemoveFirst();

            //assert
            list.Count.ShouldBeEquivalentTo(0);
            list.Head.Should().BeNull();
            list.Tail.Should().BeNull();
        }

        [Fact]
        public void Should_Remove_First()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(2);
            var node2 = new MyDoublyLinkedListNode<int>(4);
            var node3 = new MyDoublyLinkedListNode<int>(3);
            var node4 = new MyDoublyLinkedListNode<int>(5);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;

            var list = new MyDoublyLinkedList<int>(node1);

            //act
            list.RemoveFirst();

            //assert
            list.Count.ShouldBeEquivalentTo(3);
            list.Head.ShouldBeEquivalentTo(node2);
            list.Head.Next.ShouldBeEquivalentTo(node3);
            list.Head.Next.Next.ShouldBeEquivalentTo(node4);
        }

        [Fact]
        public void Should_RemoveLast_Throw_If_Empty()
        {
            //arrange
            var list = new MyDoublyLinkedList<int>();

            //act
            Action act = () => list.RemoveLast();

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Should_Remove_Last_When_Length_One()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(2);
            var list = new MyDoublyLinkedList<int>(node1);

            //act
            list.RemoveLast();

            //assert
            list.Count.ShouldBeEquivalentTo(0);
            list.Head.Should().BeNull();
            list.Tail.Should().BeNull();
        }

        [Fact]
        public void Should_Remove_Last()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(2);
            var node2 = new MyDoublyLinkedListNode<int>(4);
            var node3 = new MyDoublyLinkedListNode<int>(3);
            var node4 = new MyDoublyLinkedListNode<int>(5);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;

            var list = new MyDoublyLinkedList<int>(node1);

            //act
            list.RemoveLast();

            //assert
            list.Count.ShouldBeEquivalentTo(3);
            list.Head.ShouldBeEquivalentTo(node1);
            list.Head.Next.ShouldBeEquivalentTo(node2);
            list.Head.Next.Next.ShouldBeEquivalentTo(node3);
        }

        [Fact]
        public void Should_RemoveNode_Throw_If_Empty()
        {
            //arrange
            var list = new MyDoublyLinkedList<int>();

            //act
            Action act = () => list.Remove(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_RemoveNode_Throw_If_Node_Is_Not_Contained()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(2);
            var node2 = new MyDoublyLinkedListNode<int>(4);
            var node3 = new MyDoublyLinkedListNode<int>(3);
            var node4 = new MyDoublyLinkedListNode<int>(5);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;

            var list = new MyDoublyLinkedList<int>(node1);

            //act
            Action act = () => list.Remove(new MyDoublyLinkedListNode<int>(2));

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Should_RemoveNode_RemoveLast()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(2);
            var node2 = new MyDoublyLinkedListNode<int>(4);
            var node3 = new MyDoublyLinkedListNode<int>(3);
            var node4 = new MyDoublyLinkedListNode<int>(5);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;

            var list = new MyDoublyLinkedList<int>(node1);

            //act
            list.Remove(node4);

            //assert
            list.Count.ShouldBeEquivalentTo(3);
            list.Head.ShouldBeEquivalentTo(node1);
            list.Head.Next.ShouldBeEquivalentTo(node2);
            list.Head.Next.Next.ShouldBeEquivalentTo(node3);
        }

        [Fact]
        public void Should_RemoveNode_RemoveFirst()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(2);
            var node2 = new MyDoublyLinkedListNode<int>(4);
            var node3 = new MyDoublyLinkedListNode<int>(3);
            var node4 = new MyDoublyLinkedListNode<int>(5);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;

            var list = new MyDoublyLinkedList<int>(node1);

            //act
            list.Remove(node1);

            //assert
            list.Count.ShouldBeEquivalentTo(3);
            list.Head.ShouldBeEquivalentTo(node2);
            list.Head.Next.ShouldBeEquivalentTo(node3);
            list.Head.Next.Next.ShouldBeEquivalentTo(node4);
        }

        [Fact]
        public void Should_RemoveNode()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(2);
            var node2 = new MyDoublyLinkedListNode<int>(4);
            var node3 = new MyDoublyLinkedListNode<int>(3);
            var node4 = new MyDoublyLinkedListNode<int>(5);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;

            var list = new MyDoublyLinkedList<int>(node1);

            //act
            list.Remove(node3);

            //assert
            list.Count.ShouldBeEquivalentTo(3);
            list.Head.ShouldBeEquivalentTo(node1);
            list.Head.Next.ShouldBeEquivalentTo(node2);
            list.Head.Next.Next.ShouldBeEquivalentTo(node4);
        }

        [Fact]
        public void Should_RemoveNode_Length_One()
        {
            //arrange
            var node = new MyDoublyLinkedListNode<int>(2);
            var list = new MyDoublyLinkedList<int>(node);

            //act
            list.Remove(node);

            //assert
            list.Count.ShouldBeEquivalentTo(0);
            list.Head.ShouldBeEquivalentTo(list.Tail);
            list.Head.Should().BeNull();
        }

        [Fact]
        public void Should_RemoveValue_True()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(2);
            var node2 = new MyDoublyLinkedListNode<int>(4);
            var node3 = new MyDoublyLinkedListNode<int>(3);
            var node4 = new MyDoublyLinkedListNode<int>(5);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;

            var list = new MyDoublyLinkedList<int>(node1);

            //act
           var result =  list.Remove(4);

            //assert
            result.ShouldBeEquivalentTo(true);
            list.Count.ShouldBeEquivalentTo(3);
            list.Head.ShouldBeEquivalentTo(node1);
            list.Head.Next.ShouldBeEquivalentTo(node3);
            list.Head.Next.Next.ShouldBeEquivalentTo(node4);
        }

        [Fact]
        public void Should_RemoveValue_False()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(2);
            var node2 = new MyDoublyLinkedListNode<int>(4);
            var node3 = new MyDoublyLinkedListNode<int>(3);
            var node4 = new MyDoublyLinkedListNode<int>(5);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;

            var list = new MyDoublyLinkedList<int>(node1);

            //act
            var result = list.Remove(6);

            //assert
            result.ShouldBeEquivalentTo(false);
            list.Count.ShouldBeEquivalentTo(4);
            list.Head.ShouldBeEquivalentTo(node1);
            list.Head.Next.ShouldBeEquivalentTo(node2);
            list.Head.Next.Next.ShouldBeEquivalentTo(node3);
            list.Head.Next.Next.Next.ShouldBeEquivalentTo(node4);
        }

        [Fact]
        public void Should_Copy_To_Throw_If_Null()
        {
            //arrange
            var list = new MyDoublyLinkedList<int>();

            //act
            Action act = () => list.CopyTo(null,1);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Copy_To_Throw_If_Incorrect_ArrayIndex()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(2);
            var node2 = new MyDoublyLinkedListNode<int>(4);
            var node3 = new MyDoublyLinkedListNode<int>(3);
            var node4 = new MyDoublyLinkedListNode<int>(5);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;

            var list = new MyDoublyLinkedList<int>(node1);
            var array = new int[3];
            //act
            Action actLower = () => list.CopyTo(array, -1);
            Action actHigher = () => list.CopyTo(array, 1);

            //assert
            actLower.ShouldThrow<ArgumentOutOfRangeException>();
            actHigher.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Should_Copy_To()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(2);
            var node2 = new MyDoublyLinkedListNode<int>(4);
            var node3 = new MyDoublyLinkedListNode<int>(3);
            var node4 = new MyDoublyLinkedListNode<int>(5);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;

            var list = new MyDoublyLinkedList<int>(node1);
            var array = new int[6];
            //act
            list.CopyTo(array, 2);

            //assert
            array[0].ShouldBeEquivalentTo(0);
            array[1].ShouldBeEquivalentTo(0);
            array[2].ShouldBeEquivalentTo(2);
            array[3].ShouldBeEquivalentTo(4);
            array[4].ShouldBeEquivalentTo(3);
            array[5].ShouldBeEquivalentTo(5);
        }

        [Fact]
        public void Should_Copy_To_Empty_List()
        {
            //arrange
            var list = new MyDoublyLinkedList<int>();
            var array = new int[3];
            
            //act
            list.CopyTo(array, 1);

            //assert
            array[0].ShouldBeEquivalentTo(0);
            array[1].ShouldBeEquivalentTo(0);
            array[2].ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Should_Clear()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(2);
            var node2 = new MyDoublyLinkedListNode<int>(4);
            var node3 = new MyDoublyLinkedListNode<int>(3);
            var node4 = new MyDoublyLinkedListNode<int>(5);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;

            var list = new MyDoublyLinkedList<int>(node1);
            
            //act
            list.Clear();

            //assert
            list.Count.ShouldBeEquivalentTo(0);
            list.Head.ShouldBeEquivalentTo(list.Tail);
            list.Head.Should().BeNull();
        }

        [Fact]
        public void Should_Check_Contains_True()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(2);
            var node2 = new MyDoublyLinkedListNode<int>(4);
            var node3 = new MyDoublyLinkedListNode<int>(3);
            var node4 = new MyDoublyLinkedListNode<int>(5);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;

            var list = new MyDoublyLinkedList<int>(node1);

            //act
            var result = list.Contains(3);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_Check_Contains_False()
        {
            //arrange
            var node1 = new MyDoublyLinkedListNode<int>(2);
            var node2 = new MyDoublyLinkedListNode<int>(4);
            var node3 = new MyDoublyLinkedListNode<int>(3);
            var node4 = new MyDoublyLinkedListNode<int>(5);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            node2.Prev = node1;
            node3.Prev = node2;
            node4.Prev = node3;

            var list = new MyDoublyLinkedList<int>(node1);

            //act
            var result = list.Contains(7);

            //assert
            result.ShouldBeEquivalentTo(false);
        }
    }
}
