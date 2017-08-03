using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace DataStructures.UT
{
    public class MyArrayStackTests
    {
        [Fact]
        public void Should_Create_Default()
        {
            //arrange

            //act
            var stack = new MyArrayStack<int>();

            //assert
            stack.Capacity.ShouldBeEquivalentTo(4);
            stack.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Should_Create_With_Capacity()
        {
            //arrange

            //act
            var stack = new MyArrayStack<int>(5);

            //assert
            stack.Capacity.ShouldBeEquivalentTo(5);
            stack.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Should_Create_Not_Create_With_Negative_Capacity()
        {
            //arrange

            //act
            Action act = () => new MyArrayStack<int>(-5);

            //assert
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Should_Create_With_Collection()
        {
            //arrange
            var array = new int[] { 1, 2, 3 };
            //act
            var stack = new MyArrayStack<int>(array);

            //assert
            stack.Capacity.ShouldBeEquivalentTo(array.Length);
            stack.Count.ShouldBeEquivalentTo(array.Length);
        }

        [Fact]
        public void Should_Create_Throw_With_Collection_Null()
        {
            //arrange

            //act
            Action act = () => new MyArrayStack<int>(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Push_Element()
        {
            //arrange
            var stack = new MyArrayStack<int>();
            var data = 1;

            //act
            stack.Push(data);
            var result = stack.Peek();

            //assert
            stack.Count.ShouldBeEquivalentTo(1);
            stack.Capacity.ShouldBeEquivalentTo(4);
            result.ShouldBeEquivalentTo(data);
        }

        [Fact]
        public void Should_Push_Element_Change_Capacity()
        {
            //arrange
            var stack = new MyArrayStack<int>(new[] { 1, 2, 3, 4 });
            var data = 1;

            //act
            stack.Push(data);
            var result = stack.Peek();

            //assert
            stack.Count.ShouldBeEquivalentTo(5);
            stack.Capacity.ShouldBeEquivalentTo(8);
            result.ShouldBeEquivalentTo(data);
        }

        [Fact]
        public void Should_Peek()
        {
            //arrange
            var stack = new MyArrayStack<int>(new[] { 1 });

            //act
            var result = stack.Peek();

            //assert
            stack.Count.ShouldBeEquivalentTo(1);
            stack.Capacity.ShouldBeEquivalentTo(1);
            result.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Should_Peek_Throw_If_Stack_Is_Empty()
        {
            //arrange
            var stack = new MyArrayStack<int>();

            //act
            Action act = () => stack.Peek();

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Should_Pop_Throw_If_Stack_Is_Empty()
        {
            //arrange
            var stack = new MyArrayStack<int>();

            //act
            Action act = () => stack.Pop();

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }


        [Fact]
        public void Should_Pop()
        {
            //arrange
            var stack = new MyArrayStack<int>(new[] { 1 });

            //act
            var result = stack.Pop();
            Action act = () => stack.Pop();

            //assert
            result.ShouldBeEquivalentTo(1);
            stack.Count.ShouldBeEquivalentTo(0);
            stack.Capacity.ShouldBeEquivalentTo(1);
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Should_Pop_Multiple()
        {
            //arrange
            var array = new[] { 1, 2, 3 };
            var stack = new MyArrayStack<int>(array);

            //act
            var first = stack.Pop();
            var second = stack.Pop();
            var third = stack.Pop();
            Action act = () => stack.Pop();

            //assert
            first.ShouldBeEquivalentTo(array[2]);
            second.ShouldBeEquivalentTo(array[1]);
            third.ShouldBeEquivalentTo(array[0]);
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Should_Check_Is_Empty_True()
        {
            //arrange
            var stack = new MyArrayStack<int>();

            //act
            var result = stack.IsEmpty();

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_Check_Is_Empty_False()
        {
            //arrange
            var stack = new MyArrayStack<int>(new[] { 1 });
            
            //act
            var result = stack.IsEmpty();

            //assert
            result.ShouldBeEquivalentTo(false);
        }
    }
}
