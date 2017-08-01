using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace DataStructures.UT
{
    public class MySinglyLinkedListTests
    {
        [Fact]
        public void Should_Create_Empty_List()
        {
            //arrange

            //act
            var list = new MySinglyLinkedList<int>();

            //assert
            list.Head.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void Should_Create_List_With_One_Node_Data()
        {
            //arrange
            int data = 1;

            //act
            var list = new MySinglyLinkedList<int>(data);

            //assert
            list.Head.Should().NotBeNull();
            list.Head.Data.ShouldBeEquivalentTo(data);
            list.Count.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Should_Create_List_With_One_Node()
        {
            //arrange
            int data = 1;
            var node = new MySinglyLinkedListNode<int>(data);

            //act
            var list = new MySinglyLinkedList<int>(node);

            //assert
            list.Head.Should().NotBeNull();
            list.Head.Data.ShouldBeEquivalentTo(data);
            list.Count.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Should_Throw_When_Add_After_And_List_Is_Empty()
        {
            //arrange
            int data = 1;
            var node = new MySinglyLinkedListNode<int>(data);
            var list = new MySinglyLinkedList<int>();

            //act

            Action act = () => list.AddAfter(node, new MySinglyLinkedListNode<int>(1));

            //assert
            act.ShouldThrow<ArgumentException>();
            list.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Should_Add_After_When_Length_Is_One()
        {
            //arrange
            int data = 1;
            var node = new MySinglyLinkedListNode<int>(data);
            var list = new MySinglyLinkedList<int>(node);

            //act

            list.AddAfter(node, new MySinglyLinkedListNode<int>(2));

            //assert
            list.Count.ShouldBeEquivalentTo(2);
            list.Head.Should().NotBeNull();
            list.Head.Data.ShouldBeEquivalentTo(1);
            list.Head.Next.Data.ShouldBeEquivalentTo(2);
        }

        [Fact]
        public void Should_Throw_When_Add_After_And_Node_Is_Not_Found()
        {
            //arrange
            var node = new MySinglyLinkedListNode<int>(1);
            var node2 = new MySinglyLinkedListNode<int>(2);
            var list = new MySinglyLinkedList<int>(node);

            //act

            Action act = () => list.AddAfter(node2, new MySinglyLinkedListNode<int>(2));

            //assert
            act.ShouldThrow<ArgumentException>();
            list.Count.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Should_Add_After_When_Node_Is_In_The_Middle()
        {
            //arrange
            var node1 = new MySinglyLinkedListNode<int>(1);
            var node2 = new MySinglyLinkedListNode<int>(2);
            var node3 = new MySinglyLinkedListNode<int>(3);
            var node4 = new MySinglyLinkedListNode<int>(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            var list = new MySinglyLinkedList<int>(node1);

            //act
            list.AddAfter(node2, new MySinglyLinkedListNode<int>(5));

            //assert
            list.Count.ShouldBeEquivalentTo(5);
            list.Head.Should().NotBeNull();
            list.Head.Data.ShouldBeEquivalentTo(1);
            list.Head.Next.Data.ShouldBeEquivalentTo(2);
            list.Head.Next.Next.Data.ShouldBeEquivalentTo(5);
            list.Head.Next.Next.Next.Data.ShouldBeEquivalentTo(3);
            list.Head.Next.Next.Next.Next.Data.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void Should_Add_First_When_List_Is_Empty()
        {
            //arrange
            var node = new MySinglyLinkedListNode<int>(1);
            var list = new MySinglyLinkedList<int>();

            //act
            list.AddFirst(node);

            //assert
            list.Count.ShouldBeEquivalentTo(1);
            list.Head.Data.ShouldBeEquivalentTo(node.Data);
        }

        [Fact]
        public void Should_Add_First_Throw_When_Null()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();

            //act
            Action act = () => list.AddFirst(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Add_First()
        {
            //arrange
            var node1 = new MySinglyLinkedListNode<int>(1);
            var node2 = new MySinglyLinkedListNode<int>(2);
            var node3 = new MySinglyLinkedListNode<int>(3);
            var node4 = new MySinglyLinkedListNode<int>(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            var node5 = new MySinglyLinkedListNode<int>(5);
            var list = new MySinglyLinkedList<int>(node1);

            //act
            list.AddFirst(node5);

            //assert
            list.Count.ShouldBeEquivalentTo(5);
            list.Head.Should().NotBeNull();
            list.Head.Data.ShouldBeEquivalentTo(5);
            list.Head.Next.Data.ShouldBeEquivalentTo(1);
            list.Head.Next.Next.Data.ShouldBeEquivalentTo(2);
            list.Head.Next.Next.Next.Data.ShouldBeEquivalentTo(3);
            list.Head.Next.Next.Next.Next.Data.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void Should_Add_Last_Throw_If_Null()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();

            //act
            Action act = () => list.AddLast(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Add_Last_When_List_Is_Empty()
        {
            //arrange
            var node = new MySinglyLinkedListNode<int>(1);
            var list = new MySinglyLinkedList<int>();

            //act
            list.AddLast(node);

            //assert
            list.Count.ShouldBeEquivalentTo(1);
            list.Head.Data.ShouldBeEquivalentTo(node.Data);
        }

        [Fact]
        public void Should_Add_Last()
        {
            //arrange
            var node1 = new MySinglyLinkedListNode<int>(1);
            var node2 = new MySinglyLinkedListNode<int>(2);
            var node3 = new MySinglyLinkedListNode<int>(3);
            var node4 = new MySinglyLinkedListNode<int>(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            var node5 = new MySinglyLinkedListNode<int>(5);
            var list = new MySinglyLinkedList<int>(node1);

            //act
            list.AddLast(node5);

            //assert
            list.Count.ShouldBeEquivalentTo(5);
            list.Head.Should().NotBeNull();
            list.Head.Data.ShouldBeEquivalentTo(1);
            list.Head.Next.Data.ShouldBeEquivalentTo(2);
            list.Head.Next.Next.Data.ShouldBeEquivalentTo(3);
            list.Head.Next.Next.Next.Data.ShouldBeEquivalentTo(4);
            list.Head.Next.Next.Next.Next.Data.ShouldBeEquivalentTo(5);
        }

        [Fact]
        public void Should_Add_Before_Throw_If_Null()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();

            //act
            Action act = () => list.AddBefore(null, null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Add_After_Throw_If_Null()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();

            //act
            Action act = () => list.AddAfter(null, null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Add_Before_When_Length_One()
        {
            //arrange
            var node1 = new MySinglyLinkedListNode<int>(1);
            var node2 = new MySinglyLinkedListNode<int>(2);

            var list = new MySinglyLinkedList<int>(node1);

            //act
            list.AddBefore(node1, node2);

            //assert
            list.Count.ShouldBeEquivalentTo(2);
            list.Head.Should().NotBeNull();
            list.Head.Data.ShouldBeEquivalentTo(2);
            list.Head.Next.Data.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Should_Add_Before()
        {
            //arrange
            var node1 = new MySinglyLinkedListNode<int>(1);
            var node2 = new MySinglyLinkedListNode<int>(2);
            var node3 = new MySinglyLinkedListNode<int>(3);
            var node4 = new MySinglyLinkedListNode<int>(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            var node5 = new MySinglyLinkedListNode<int>(5);
            var list = new MySinglyLinkedList<int>(node1);

            //act
            list.AddBefore(node3, node5);

            //assert
            list.Count.ShouldBeEquivalentTo(5);
            list.Head.Should().NotBeNull();
            list.Head.Data.ShouldBeEquivalentTo(1);
            list.Head.Next.Data.ShouldBeEquivalentTo(2);
            list.Head.Next.Next.Data.ShouldBeEquivalentTo(5);
            list.Head.Next.Next.Next.Data.ShouldBeEquivalentTo(3);
            list.Head.Next.Next.Next.Next.Data.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void Should_Add_Before_Throw_When_Node_Is_Not_Found()
        {
            //arrange
            var node1 = new MySinglyLinkedListNode<int>(1);
            var node2 = new MySinglyLinkedListNode<int>(2);

            var list = new MySinglyLinkedList<int>(node1);

            //act
            Action act = () => list.AddBefore(new MySinglyLinkedListNode<int>(3), node2);

            //assert
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Should_Add_Clear()
        {
            //arrange
            var node1 = new MySinglyLinkedListNode<int>(1);
            var node2 = new MySinglyLinkedListNode<int>(2);
            var node3 = new MySinglyLinkedListNode<int>(3);
            var node4 = new MySinglyLinkedListNode<int>(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            var list = new MySinglyLinkedList<int>(node1);

            //act
            list.Clear();

            //assert
            list.Count.ShouldBeEquivalentTo(0);
            list.Head.Should().BeNull();
        }

        [Fact]
        public void Should_Find_Node()
        {
            //arrange
            var node1 = new MySinglyLinkedListNode<int>(1);
            var node2 = new MySinglyLinkedListNode<int>(2);
            var node3 = new MySinglyLinkedListNode<int>(3);
            var node4 = new MySinglyLinkedListNode<int>(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            var list = new MySinglyLinkedList<int>(node1);

            //act
            var result = list.Find(3);

            //assert
            result.ShouldBeEquivalentTo(node3);
        }
        [Fact]
        public void Should_Find_Node_Return_Null()
        {
            //arrange
            var node1 = new MySinglyLinkedListNode<int>(1);
            var node2 = new MySinglyLinkedListNode<int>(2);
            var node3 = new MySinglyLinkedListNode<int>(3);
            var node4 = new MySinglyLinkedListNode<int>(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            var list = new MySinglyLinkedList<int>(node1);

            //act
            var result = list.Find(5);

            //assert
            result.Should().BeNull();
        }

        [Fact]
        public void Should_Throw_Remove_When_Null()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();

            //act
            Action act = () => list.Remove(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Remove_True()
        {
            //arrange
            var node1 = new MySinglyLinkedListNode<int>(1);
            var node2 = new MySinglyLinkedListNode<int>(2);
            var node3 = new MySinglyLinkedListNode<int>(3);
            var node4 = new MySinglyLinkedListNode<int>(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            var list = new MySinglyLinkedList<int>(node1);

            //act
            var result = list.Remove(node3);

            //assert
            result.ShouldBeEquivalentTo(true);
            list.Count.ShouldBeEquivalentTo(3);
            list.Head.Data.ShouldBeEquivalentTo(1);
            list.Head.Next.Data.ShouldBeEquivalentTo(2);
            list.Head.Next.Next.Data.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void Should_Remove_False()
        {
            //arrange
            var node1 = new MySinglyLinkedListNode<int>(1);
            var node2 = new MySinglyLinkedListNode<int>(2);
            var node3 = new MySinglyLinkedListNode<int>(3);
            var node4 = new MySinglyLinkedListNode<int>(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            var list = new MySinglyLinkedList<int>(node1);

            //act
            var result = list.Remove(new MySinglyLinkedListNode<int>(5));

            //assert
            result.ShouldBeEquivalentTo(false);
            list.Count.ShouldBeEquivalentTo(4);
            list.Head.Data.ShouldBeEquivalentTo(1);
            list.Head.Next.Data.ShouldBeEquivalentTo(2);
            list.Head.Next.Next.Data.ShouldBeEquivalentTo(3);
            list.Head.Next.Next.Next.Data.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void Should_Remove_First()
        {
            //arrange
            var node1 = new MySinglyLinkedListNode<int>(1);
            var node2 = new MySinglyLinkedListNode<int>(2);
            var node3 = new MySinglyLinkedListNode<int>(3);
            var node4 = new MySinglyLinkedListNode<int>(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            var list = new MySinglyLinkedList<int>(node1);

            //act
            list.RemoveFirst();

            //assert
            list.Count.ShouldBeEquivalentTo(3);
            list.Head.Data.ShouldBeEquivalentTo(2);
            list.Head.Next.Data.ShouldBeEquivalentTo(3);
            list.Head.Next.Next.Data.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void Should_Throw_Remove_First_When_List_Is_Empty()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();

            //act
            Action act = () => list.RemoveFirst();

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Should_Throw_Remove_Last_When_List_Is_Empty()
        {
            //arrange
            var list = new MySinglyLinkedList<int>();

            //act
            Action act = () => list.RemoveLast();

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Should_Remove_Last()
        {
            //arrange
            var node1 = new MySinglyLinkedListNode<int>(1);
            var node2 = new MySinglyLinkedListNode<int>(2);
            var node3 = new MySinglyLinkedListNode<int>(3);
            var node4 = new MySinglyLinkedListNode<int>(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            var list = new MySinglyLinkedList<int>(node1);

            //act
            list.RemoveLast();

            //assert
            list.Count.ShouldBeEquivalentTo(3);
            list.Head.Data.ShouldBeEquivalentTo(1);
            list.Head.Next.Data.ShouldBeEquivalentTo(2);
            list.Head.Next.Next.Data.ShouldBeEquivalentTo(3);
        }

        [Fact]
        public void Should_Check_Contains_True()
        {
            //arrange
            var node1 = new MySinglyLinkedListNode<int>(1);
            var node2 = new MySinglyLinkedListNode<int>(2);
            var node3 = new MySinglyLinkedListNode<int>(3);
            var node4 = new MySinglyLinkedListNode<int>(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            var list = new MySinglyLinkedList<int>(node1);

            //act
            var result = list.Contains(node3);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_Check_Contains_False()
        {
            //arrange
            var node1 = new MySinglyLinkedListNode<int>(1);
            var node2 = new MySinglyLinkedListNode<int>(2);
            var node3 = new MySinglyLinkedListNode<int>(3);
            var node4 = new MySinglyLinkedListNode<int>(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            var list = new MySinglyLinkedList<int>(node1);

            //act
            var result = list.Contains(new MySinglyLinkedListNode<int>(5));

            //assert
            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Should_Check_Find_Last_True()
        {
            //arrange
            var node1 = new MySinglyLinkedListNode<int>(1);
            var node2 = new MySinglyLinkedListNode<int>(2);
            var node3 = new MySinglyLinkedListNode<int>(2);
            var node4 = new MySinglyLinkedListNode<int>(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            var list = new MySinglyLinkedList<int>(node1);

            //act
            var result = list.FindLast(2);

            //assert
            result.ShouldBeEquivalentTo(node3);
        }

        [Fact]
        public void Should_Check_Find_Last_False()
        {
            //arrange
            var node1 = new MySinglyLinkedListNode<int>(1);
            var node2 = new MySinglyLinkedListNode<int>(2);
            var node3 = new MySinglyLinkedListNode<int>(2);
            var node4 = new MySinglyLinkedListNode<int>(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            var list = new MySinglyLinkedList<int>(node1);

            //act
            var result = list.FindLast(5);

            //assert
            result.Should().BeNull();
        }

        [Fact]
        public void Should_Check_Copy_To_Throw_If_Null()
        {
            //arrange           
            var list = new MySinglyLinkedList<int>();

            //act
            Action act = ()=>list.CopyTo(null, 1);

            //assert
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Should_Check_Copy_To_Throw_Start_Index_Range()
        {
            //arrange  
            var node1 = new MySinglyLinkedListNode<int>(1);
            var node2 = new MySinglyLinkedListNode<int>(2);
            node1.Next = node2;

            var list = new MySinglyLinkedList<int>(node1);

            var array = new int[1];

            //act
            Action actLower = () => list.CopyTo(array, -1);
            Action actUpper = () => list.CopyTo(array, 0);

            //assert
            actLower.ShouldThrow<ArgumentException>();
            actUpper.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Should_Check_Copy_To()
        {
            //arrange  
            var node1 = new MySinglyLinkedListNode<int>(1);
            var node2 = new MySinglyLinkedListNode<int>(2);
            var node3 = new MySinglyLinkedListNode<int>(3);
            var node4 = new MySinglyLinkedListNode<int>(4);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            var list = new MySinglyLinkedList<int>(node1);

            var array = new int[6];

            //act
            list.CopyTo(array, 2);

            //assert
            array[0].ShouldBeEquivalentTo(0);
            array[1].ShouldBeEquivalentTo(0);
            array[2].ShouldBeEquivalentTo(1);
            array[3].ShouldBeEquivalentTo(2);
            array[4].ShouldBeEquivalentTo(3);
            array[5].ShouldBeEquivalentTo(4);
        }
    }
}
