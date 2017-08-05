using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace DataStructures.UT
{
    public class MyBinaryHeapTests
    {
        [Fact]
        public void Should_Create_Default()
        {
            //arrange

            //act
            var result = new MyBinaryHeap<int>(MyBinaryHeapType.MinHeap);

            //assert
            result.Root.ShouldBeEquivalentTo(null);
            result.HeapType.ShouldBeEquivalentTo(MyBinaryHeapType.MinHeap);
            result.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Should_Insert_MinHeap()
        {
            //arrange
            var result = new MyBinaryHeap<int>(MyBinaryHeapType.MinHeap);

            //act
            result.Insert(4);
            result.Insert(50);
            result.Insert(7);
            result.Insert(55);
            result.Insert(90);
            result.Insert(87);
            result.Insert(2);

            //assert
            result.Count.ShouldBeEquivalentTo(7);
            result.HeapType.ShouldBeEquivalentTo(MyBinaryHeapType.MinHeap);

            result.Root.Data.ShouldBeEquivalentTo(2);
            result.Root.Left.Data.ShouldBeEquivalentTo(50);
            result.Root.Right.Data.ShouldBeEquivalentTo(4);
            result.Root.Left.Left.Data.ShouldBeEquivalentTo(55);
            result.Root.Left.Right.Data.ShouldBeEquivalentTo(90);
            result.Root.Right.Left.Data.ShouldBeEquivalentTo(87);
            result.Root.Right.Right.Data.ShouldBeEquivalentTo(7);
        }

        [Fact]
        public void Should_Insert_MinHeap_Check_Next_Level()
        {
            //arrange
            var result = new MyBinaryHeap<int>(MyBinaryHeapType.MinHeap);

            //act
            result.Insert(1);
            result.Insert(2);
            result.Insert(3);
            result.Insert(17);
            result.Insert(19);
            result.Insert(36);
            result.Insert(7);
            result.Insert(25);
            result.Insert(100);

            //assert
            result.Count.ShouldBeEquivalentTo(9);
            result.HeapType.ShouldBeEquivalentTo(MyBinaryHeapType.MinHeap);

            result.Root.Data.ShouldBeEquivalentTo(1);
            result.Root.Left.Data.ShouldBeEquivalentTo(2);
            result.Root.Right.Data.ShouldBeEquivalentTo(3);
            result.Root.Left.Left.Data.ShouldBeEquivalentTo(17);
            result.Root.Left.Right.Data.ShouldBeEquivalentTo(19);
            result.Root.Right.Left.Data.ShouldBeEquivalentTo(36);
            result.Root.Right.Right.Data.ShouldBeEquivalentTo(7);
            result.Root.Left.Left.Left.Data.ShouldBeEquivalentTo(25);
            result.Root.Left.Left.Right.Data.ShouldBeEquivalentTo(100);
        }

        [Fact]
        public void Should_Insert_MaxHeap()
        {
            //arrange
            var result = new MyBinaryHeap<int>(MyBinaryHeapType.MaxHeap);

            //act
            result.Insert(100);
            result.Insert(19);
            result.Insert(36);
            result.Insert(17);
            result.Insert(3);
            result.Insert(25);
            result.Insert(1);
            result.Insert(2);
            result.Insert(7);

            //assert
            result.Count.ShouldBeEquivalentTo(9);
            result.HeapType.ShouldBeEquivalentTo(MyBinaryHeapType.MaxHeap);

            result.Root.Data.ShouldBeEquivalentTo(100);
            result.Root.Left.Data.ShouldBeEquivalentTo(19);
            result.Root.Right.Data.ShouldBeEquivalentTo(36);
            result.Root.Left.Left.Data.ShouldBeEquivalentTo(17);
            result.Root.Left.Right.Data.ShouldBeEquivalentTo(3);
            result.Root.Right.Left.Data.ShouldBeEquivalentTo(25);
            result.Root.Right.Right.Data.ShouldBeEquivalentTo(1);
            result.Root.Left.Left.Left.Data.ShouldBeEquivalentTo(2);
            result.Root.Left.Left.Right.Data.ShouldBeEquivalentTo(7);
        }

        [Fact]
        public void Should_Check_ExtractTop_MinHeap()
        {
            //arrange
            var heap = new MyBinaryHeap<int>(MyBinaryHeapType.MinHeap);
            heap.Insert(1);
            heap.Insert(50);
            heap.Insert(23);
            heap.Insert(88);
            heap.Insert(90);
            heap.Insert(32);
            heap.Insert(74);
            heap.Insert(96);

            //act
            var result = heap.ExtractTop();

            //assert
            result.ShouldBeEquivalentTo(1);
            heap.Count.ShouldBeEquivalentTo(7);
            heap.HeapType.ShouldBeEquivalentTo(MyBinaryHeapType.MinHeap);

            heap.Root.Data.ShouldBeEquivalentTo(23);
            heap.Root.Left.Data.ShouldBeEquivalentTo(50);
            heap.Root.Right.Data.ShouldBeEquivalentTo(32);
            heap.Root.Left.Left.Data.ShouldBeEquivalentTo(88);
            heap.Root.Left.Right.Data.ShouldBeEquivalentTo(90);
            heap.Root.Right.Left.Data.ShouldBeEquivalentTo(96);
            heap.Root.Right.Right.Data.ShouldBeEquivalentTo(74);
        }

        [Fact]
        public void Should_Check_ExtractTop_MaxHeap()
        {
            //arrange
            var heap = new MyBinaryHeap<int>(MyBinaryHeapType.MaxHeap);
            heap.Insert(100);
            heap.Insert(19);
            heap.Insert(36);
            heap.Insert(17);
            heap.Insert(3);
            heap.Insert(25);
            heap.Insert(1);
            heap.Insert(2);
            heap.Insert(7);

            //act
            var result = heap.ExtractTop();

            //assert
            result.ShouldBeEquivalentTo(100);
            heap.Count.ShouldBeEquivalentTo(8);
            heap.HeapType.ShouldBeEquivalentTo(MyBinaryHeapType.MaxHeap);

            heap.Root.Data.ShouldBeEquivalentTo(36);
            heap.Root.Left.Data.ShouldBeEquivalentTo(19);
            heap.Root.Right.Data.ShouldBeEquivalentTo(25);
            heap.Root.Left.Left.Data.ShouldBeEquivalentTo(17);
            heap.Root.Left.Right.Data.ShouldBeEquivalentTo(3);
            heap.Root.Right.Left.Data.ShouldBeEquivalentTo(7);
            heap.Root.Right.Right.Data.ShouldBeEquivalentTo(1);
            heap.Root.Left.Left.Left.Data.ShouldBeEquivalentTo(2);
            heap.Root.Left.Left.Right.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void Should_Check_ExtractTop_MaxHeap_Multiple()
        {
            //arrange
            var heap = new MyBinaryHeap<int>(MyBinaryHeapType.MaxHeap);
            heap.Insert(9);
            heap.Insert(7);
            heap.Insert(5);
            heap.Insert(4);
            heap.Insert(2);
            heap.Insert(1);

            //act

            //assert
            heap.ExtractTop().ShouldBeEquivalentTo(9);
            heap.ExtractTop().ShouldBeEquivalentTo(7);
            heap.ExtractTop().ShouldBeEquivalentTo(5);
            heap.ExtractTop().ShouldBeEquivalentTo(4);
            heap.ExtractTop().ShouldBeEquivalentTo(2);
            heap.ExtractTop().ShouldBeEquivalentTo(1);

            heap.Root.ShouldBeEquivalentTo(null);
            heap.Count.ShouldBeEquivalentTo(0);
            heap.HeapType.ShouldBeEquivalentTo(MyBinaryHeapType.MaxHeap);
        }

        [Fact]
        public void Should_Check_ExtractTop_MinHeap_Multiple()
        {
            //arrange
            var heap = new MyBinaryHeap<int>(MyBinaryHeapType.MinHeap);
            heap.Insert(1);
            heap.Insert(3);
            heap.Insert(6);
            heap.Insert(5);
            heap.Insert(9);
            heap.Insert(8);

            //act

            //assert
            heap.ExtractTop().ShouldBeEquivalentTo(1);
            heap.ExtractTop().ShouldBeEquivalentTo(3);
            heap.ExtractTop().ShouldBeEquivalentTo(5);
            heap.ExtractTop().ShouldBeEquivalentTo(6);
            heap.ExtractTop().ShouldBeEquivalentTo(8);
            heap.ExtractTop().ShouldBeEquivalentTo(9);

            heap.Root.ShouldBeEquivalentTo(null);
            heap.Count.ShouldBeEquivalentTo(0);
            heap.HeapType.ShouldBeEquivalentTo(MyBinaryHeapType.MinHeap);
        }

        [Fact]
        public void Should_Check_ExtractTop_MinHeap_Throw_If_Empty()
        {
            //arrange
            var heap = new MyBinaryHeap<int>(MyBinaryHeapType.MinHeap);

            //act
            Action act = () => heap.ExtractTop();

            //assert
            act.ShouldThrow<InvalidOperationException>();

            heap.Root.ShouldBeEquivalentTo(null);
            heap.Count.ShouldBeEquivalentTo(0);
            heap.HeapType.ShouldBeEquivalentTo(MyBinaryHeapType.MinHeap);
        }

        [Fact]
        public void Should_Check_ExtractTop_MaxHeap_Throw_If_Empty()
        {
            //arrange
            var heap = new MyBinaryHeap<int>(MyBinaryHeapType.MaxHeap);

            //act
            Action act = () => heap.ExtractTop();

            //assert
            act.ShouldThrow<InvalidOperationException>();

            heap.Root.ShouldBeEquivalentTo(null);
            heap.Count.ShouldBeEquivalentTo(0);
            heap.HeapType.ShouldBeEquivalentTo(MyBinaryHeapType.MaxHeap);
        }

        [Fact]
        public void Should_Check_ExtractTop_Insert_MinHeap_Multiple()
        {
            //arrange
            var heap = new MyBinaryHeap<int>(MyBinaryHeapType.MinHeap);
            heap.Insert(1);
            heap.Insert(3);
            heap.Insert(6);
            heap.Insert(5);
            heap.Insert(9);
            heap.Insert(8);

            heap.ExtractTop();
            heap.ExtractTop();
            heap.ExtractTop();

            //act
            heap.Insert(10);
            heap.Insert(11);
            heap.Insert(12);
            heap.Insert(7);
            heap.Insert(12);

            //assert
            heap.Root.Data.ShouldBeEquivalentTo(6);
            heap.Root.Left.Data.ShouldBeEquivalentTo(8);
            heap.Root.Right.Data.ShouldBeEquivalentTo(7);
            heap.Root.Left.Left.Data.ShouldBeEquivalentTo(10);
            heap.Root.Left.Right.Data.ShouldBeEquivalentTo(11);
            heap.Root.Right.Left.Data.ShouldBeEquivalentTo(12);
            heap.Root.Right.Right.Data.ShouldBeEquivalentTo(9);
            heap.Root.Left.Left.Left.Data.ShouldBeEquivalentTo(12);

            heap.Count.ShouldBeEquivalentTo(8);
            heap.HeapType.ShouldBeEquivalentTo(MyBinaryHeapType.MinHeap);
        }

        [Fact]
        public void Should_Check_ExtractTop_Insert_MaxHeap_Multiple()
        {
            //arrange
            var heap = new MyBinaryHeap<int>(MyBinaryHeapType.MaxHeap);
            heap.Insert(17);
            heap.Insert(15);
            heap.Insert(10);
            heap.Insert(6);
            heap.Insert(10);
            heap.Insert(7);

            heap.ExtractTop();
            heap.ExtractTop();
            heap.ExtractTop();

            //act
            heap.Insert(1);
            heap.Insert(2);
            heap.Insert(3);
            heap.Insert(11);
            heap.Insert(6);

            //assert
            heap.Root.Data.ShouldBeEquivalentTo(11);
            heap.Root.Left.Data.ShouldBeEquivalentTo(7);
            heap.Root.Right.Data.ShouldBeEquivalentTo(10);
            heap.Root.Left.Left.Data.ShouldBeEquivalentTo(6);
            heap.Root.Left.Right.Data.ShouldBeEquivalentTo(2);
            heap.Root.Right.Left.Data.ShouldBeEquivalentTo(3);
            heap.Root.Right.Right.Data.ShouldBeEquivalentTo(6);
            heap.Root.Left.Left.Left.Data.ShouldBeEquivalentTo(1);

            heap.Count.ShouldBeEquivalentTo(8);
            heap.HeapType.ShouldBeEquivalentTo(MyBinaryHeapType.MaxHeap);
        }

        [Fact]
        public void Should_Check_Contains_True()
        {
            //arrange
            var heap = new MyBinaryHeap<int>(MyBinaryHeapType.MaxHeap);
            heap.Insert(17);
            heap.Insert(15);
            heap.Insert(10);
            heap.Insert(6);
            heap.Insert(10);
            heap.Insert(7);

            //act
            var result = heap.Contains(10);

            //assert
            result.ShouldBeEquivalentTo(true);

            heap.Count.ShouldBeEquivalentTo(6);
            heap.HeapType.ShouldBeEquivalentTo(MyBinaryHeapType.MaxHeap);
        }

        [Fact]
        public void Should_Check_Contains_False()
        {
            //arrange
            var heap = new MyBinaryHeap<int>(MyBinaryHeapType.MaxHeap);
            heap.Insert(17);
            heap.Insert(15);
            heap.Insert(10);
            heap.Insert(6);
            heap.Insert(10);
            heap.Insert(7);

            heap.ExtractTop();
            //act
            var result = heap.Contains(17);

            //assert
            result.ShouldBeEquivalentTo(false);

            heap.Count.ShouldBeEquivalentTo(5);
            heap.HeapType.ShouldBeEquivalentTo(MyBinaryHeapType.MaxHeap);
        }

        [Fact]
        public void Should_Throw_Decrease_If_Not_Contains()
        {
            //arrange
            var heap = new MyBinaryHeap<int>(MyBinaryHeapType.MaxHeap);
            heap.Insert(17);
            heap.Insert(15);
            heap.Insert(10);
            heap.Insert(6);
            heap.Insert(10);
            heap.Insert(7);

            heap.ExtractTop();

            //act
            Action act = () => heap.Decrease(17, 11);

            //assert
            act.ShouldThrow<InvalidOperationException>();

            heap.Count.ShouldBeEquivalentTo(5);
            heap.HeapType.ShouldBeEquivalentTo(MyBinaryHeapType.MaxHeap);
        }

        [Fact]
        public void Should_Throw_Decrease_If_Higher_Value_MinHeap()
        {
            //arrange
            var heap = new MyBinaryHeap<int>(MyBinaryHeapType.MinHeap);
            heap.Insert(17);
            heap.Insert(15);
            heap.Insert(10);
            heap.Insert(6);
            heap.Insert(10);
            heap.Insert(7);

            heap.ExtractTop();

            //act
            Action act = () => heap.Decrease(17, 20);

            //assert
            act.ShouldThrow<ArgumentException>();

            heap.Count.ShouldBeEquivalentTo(5);
            heap.HeapType.ShouldBeEquivalentTo(MyBinaryHeapType.MinHeap);
        }

        [Fact]
        public void Should_Throw_Decrease_If_Lower_Value_MaxHeap()
        {
            //arrange
            var heap = new MyBinaryHeap<int>(MyBinaryHeapType.MaxHeap);
            heap.Insert(17);
            heap.Insert(15);
            heap.Insert(10);
            heap.Insert(6);
            heap.Insert(10);
            heap.Insert(7);

            //act
            Action act = () => heap.Decrease(17, 11);

            //assert
            act.ShouldThrow<ArgumentException>();

            heap.Count.ShouldBeEquivalentTo(6);
            heap.HeapType.ShouldBeEquivalentTo(MyBinaryHeapType.MaxHeap);
        }

        [Fact]
        public void Should_Decrease_Max_Heap()
        {
            //arrange
            var heap = new MyBinaryHeap<int>(MyBinaryHeapType.MaxHeap);
            heap.Insert(17);
            heap.Insert(15);
            heap.Insert(11);
            heap.Insert(6);
            heap.Insert(10);
            heap.Insert(7);

            //act
            heap.Decrease(10, 16);

            //assert
            heap.Root.Data.ShouldBeEquivalentTo(17);
            heap.Root.Left.Data.ShouldBeEquivalentTo(16);
            heap.Root.Right.Data.ShouldBeEquivalentTo(11);
            heap.Root.Left.Left.Data.ShouldBeEquivalentTo(6);
            heap.Root.Left.Right.Data.ShouldBeEquivalentTo(15);
            heap.Root.Right.Left.Data.ShouldBeEquivalentTo(7);

            heap.Count.ShouldBeEquivalentTo(6);
            heap.HeapType.ShouldBeEquivalentTo(MyBinaryHeapType.MaxHeap);
        }

        [Fact]
        public void Should_Decrease_Min_Heap()
        {
            //arrange
            var heap = new MyBinaryHeap<int>(MyBinaryHeapType.MinHeap);
            heap.Insert(6);
            heap.Insert(7);
            heap.Insert(12);
            heap.Insert(10);
            heap.Insert(15);
            heap.Insert(17);

            //act
            heap.Decrease(10, 2);

            //assert
            heap.Root.Data.ShouldBeEquivalentTo(2);
            heap.Root.Left.Data.ShouldBeEquivalentTo(6);
            heap.Root.Right.Data.ShouldBeEquivalentTo(12);
            heap.Root.Left.Left.Data.ShouldBeEquivalentTo(7);
            heap.Root.Left.Right.Data.ShouldBeEquivalentTo(15);
            heap.Root.Right.Left.Data.ShouldBeEquivalentTo(17);

            heap.Count.ShouldBeEquivalentTo(6);
            heap.HeapType.ShouldBeEquivalentTo(MyBinaryHeapType.MinHeap);
        }
    }
}
