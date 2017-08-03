using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace DataStructures.UT
{
    public class MyLinkedListStackTests
    {
        [Fact]
        public void Should_Create_Default_Stack()
        {
            //arrange

            //act
            var stack = new MyLinkedListStack<int>();

            //assert
            stack.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Should_Create_Stack_With_Collection()
        {
            //arrange
            var array = new int[] { 1, 2, 3, 4, 5 };
            //act
            var stack = new MyLinkedListStack<int>(array);

            //assert
            stack.Count.ShouldBeEquivalentTo(5);
        }

        [Fact]
        public void Should_Push()
        {
            //arrange
            var stack = new MyLinkedListStack<int>();

            //act
            stack.Push(1);

            //assert
            stack.Count.ShouldBeEquivalentTo(1);
        }


        [Fact]
        public void Should_Peek()
        {
            //arrange
            var stack = new MyLinkedListStack<int>();
            stack.Push(1);

            //act
            var result = stack.Peek();

            //assert
            stack.Count.ShouldBeEquivalentTo(1);
            result.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Should_Peek_Throw_If_Stack_Is_Empty()
        {
            //arrange
            var stack = new MyLinkedListStack<int>();

            //act
            Action act = () => stack.Peek();

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Should_Pop_Throw_If_Stack_Is_Empty()
        {
            //arrange
            var stack = new MyLinkedListStack<int>();

            //act
            Action act = () => stack.Pop();

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Should_Push_And_Pop_Correct_Order()
        {
            //arrange
            var data = new int[] { 1, 2, 3 };
            var stack = new MyLinkedListStack<int>();

            //act
            stack.Push(data[0]);
            stack.Push(data[1]);
            stack.Push(data[2]);

            var first = stack.Pop();
            var second = stack.Pop();
            var third = stack.Pop();

            //assert
            first.ShouldBeEquivalentTo(data[2]);
            second.ShouldBeEquivalentTo(data[1]);
            third.ShouldBeEquivalentTo(data[0]);
        }

        [Fact]
        public void Should_Check_Is_Empty_False()
        {
            //arrange
            var stack = new MyLinkedListStack<int>();
            stack.Push(1);
            //act
            var result = stack.IsEmpty();
            
            //assert
            result.ShouldBeEquivalentTo(false);
        }


        [Fact]
        public void Should_Check_Is_Empty_True()
        {
            //arrange
            var stack = new MyLinkedListStack<int>();
            
            //act
            var result = stack.IsEmpty();

            //assert
            result.ShouldBeEquivalentTo(true);
        }
    }
}
