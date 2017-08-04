using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace DataStructures.UT
{
    public class MyArrayListTests
    {
        [Fact]
        public void Should_Create_Default()
        {
            //arrange

            //act
            var result = new MyArrayList();

            //assert
            result.Capacity.ShouldBeEquivalentTo(4);
            result.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Should_Add()
        {
            //arrange
            var list = new MyArrayList();

            //act
            list.Add(1);
            list.Add(2);
            list.Add(3);

            //assert
            list.Capacity.ShouldBeEquivalentTo(4);
            list.Count.ShouldBeEquivalentTo(3);

            list[0].ShouldBeEquivalentTo(1);
            list[1].ShouldBeEquivalentTo(2);
            list[2].ShouldBeEquivalentTo(3);
        }

        [Fact]
        public void Should_Insert()
        {
            //arrange
            var list = new MyArrayList();

            //act
            list.Insert(0, 1);
            list.Insert(0, 2);
            list.Insert(0, 3);

            //assert
            list.Capacity.ShouldBeEquivalentTo(4);
            list.Count.ShouldBeEquivalentTo(3);

            list[0].ShouldBeEquivalentTo(3);
            list[1].ShouldBeEquivalentTo(2);
            list[2].ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Should_Insert_With_Overflow()
        {
            //arrange
            var list = new MyArrayList();

            //act
            list.Insert(0, 1);
            list.Insert(0, 2);
            list.Insert(0, 3);
            list.Insert(0, 4);
            list.Insert(0, 5);

            //assert
            list.Capacity.ShouldBeEquivalentTo(8);
            list.Count.ShouldBeEquivalentTo(5);

            list[0].ShouldBeEquivalentTo(5);
            list[1].ShouldBeEquivalentTo(4);
            list[2].ShouldBeEquivalentTo(3);
            list[3].ShouldBeEquivalentTo(2);
            list[4].ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Should_Insert_Throw_If_Index_Out_Of_Range()
        {
            //arrange
            var list = new MyArrayList();
            list.Add(1);
            list.Add(2);

            //act
            Action actHigher = () => list.Insert(3, 3);
            Action actLower = () => list.Insert(-3, 3);

            //assert
            actHigher.ShouldThrow<ArgumentOutOfRangeException>();
            actLower.ShouldThrow<ArgumentOutOfRangeException>();

            list.Count.ShouldBeEquivalentTo(2);
            list.Capacity.ShouldBeEquivalentTo(4);

            list[0].ShouldBeEquivalentTo(1);
            list[1].ShouldBeEquivalentTo(2);
        }

        [Fact]
        public void Should_Check_GetIndexer()
        {
            //arrange
            var list = new MyArrayList();
            list.Add(1);
            list.Add(2);

            //act

            //assert
            list.Count.ShouldBeEquivalentTo(2);
            list.Capacity.ShouldBeEquivalentTo(4);

            list[0].ShouldBeEquivalentTo(1);
            list[1].ShouldBeEquivalentTo(2);
        }

        [Fact]
        public void Should_Check_GetIndexer_Throw_If_Out_Of_Range()
        {
            //arrange
            var list = new MyArrayList();
            list.Add(1);
            list.Add(2);

            int first, second;

            //act
            Action actLower = () => first = (int)list[-1];
            Action actHigher = () => first = (int)list[2];

            //assert
            actLower.ShouldThrow<ArgumentOutOfRangeException>();
            actHigher.ShouldThrow<ArgumentOutOfRangeException>();

            list.Count.ShouldBeEquivalentTo(2);
            list.Capacity.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void Should_Check_SetIndexer_Throw_If_Out_Of_Range()
        {
            //arrange
            var list = new MyArrayList();
            list.Add(1);
            list.Add(2);

            //act
            Action actLower = () => list[-1] = 4;
            Action actHigher = () => list[3] = 5;

            //assert
            actLower.ShouldThrow<ArgumentOutOfRangeException>();
            actHigher.ShouldThrow<ArgumentOutOfRangeException>();

            list.Count.ShouldBeEquivalentTo(2);
            list.Capacity.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void Should_Check_SetIndexer_Update()
        {
            //arrange
            var list = new MyArrayList();
            list.Add(1);
            list.Add(2);

            //act
            list[0] = 4;
            list[1] = 5;

            //assert
            list.Count.ShouldBeEquivalentTo(2);
            list.Capacity.ShouldBeEquivalentTo(4);

            list[0].ShouldBeEquivalentTo(4);
            list[1].ShouldBeEquivalentTo(5);
        }

        [Fact]
        public void Should_Check_InsertRange_Index_Boundaries()
        {
            //arrange
            var range = new object[] { 1, 2, 3, 4 };
            var list = new MyArrayList();
            list.Add(1);
            list.Add(2);

            //act
            Action actLower = () => list.InsertRange(-1, range);
            Action actHigher = () => list.InsertRange(4, range);

            //assert
            actLower.ShouldThrow<ArgumentOutOfRangeException>();
            actHigher.ShouldThrow<ArgumentOutOfRangeException>();

            list.Count.ShouldBeEquivalentTo(2);
            list.Capacity.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void Should_Check_InsertRange_If_Null()
        {
            //arrange
            var list = new MyArrayList();
            list.Add(1);
            list.Add(2);

            //act
            Action act = () => list.InsertRange(1, null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
            list.Count.ShouldBeEquivalentTo(2);
            list.Capacity.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void Should_Check_InsertRange()
        {
            //arrange
            var data = new object[] { 3, 4, 5, 6 };
            var list = new MyArrayList();
            list.Add(1);
            list.Add(2);

            //act
            list.InsertRange(1, data);

            //assert
            list.Count.ShouldBeEquivalentTo(6);
            list.Capacity.ShouldBeEquivalentTo(8);

            list[0].ShouldBeEquivalentTo(1);
            list[1].ShouldBeEquivalentTo(3);
            list[2].ShouldBeEquivalentTo(4);
            list[3].ShouldBeEquivalentTo(5);
            list[4].ShouldBeEquivalentTo(6);
            list[5].ShouldBeEquivalentTo(2);
        }

        [Fact]
        public void Should_Check_AddRange()
        {
            //arrange
            var data = new object[] { 3, 4, 5, 6 };
            var list = new MyArrayList();
            list.Add(1);
            list.Add(2);

            //act
            list.AddRange(data);

            //assert
            list.Count.ShouldBeEquivalentTo(6);
            list.Capacity.ShouldBeEquivalentTo(8);

            list[0].ShouldBeEquivalentTo(1);
            list[1].ShouldBeEquivalentTo(2);
            list[2].ShouldBeEquivalentTo(3);
            list[3].ShouldBeEquivalentTo(4);
            list[4].ShouldBeEquivalentTo(5);
            list[5].ShouldBeEquivalentTo(6);
        }

        [Fact]
        public void Should_Check_InsertRange_Throw_If_Null()
        {
            //arrange
            var list = new MyArrayList();
            list.Add(1);
            list.Add(2);

            //act
            Action act = () => list.AddRange(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
            list.Capacity.ShouldBeEquivalentTo(4);
            list.Count.ShouldBeEquivalentTo(2);
        }

        [Fact]
        public void Should_Check_BinarySearch_Throw_If_Null()
        {
            //arrange
            var list = new MyArrayList();
            list.Add(1);
            list.Add(2);

            //act
            Action act = () => list.BinarySearch(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
            list.Capacity.ShouldBeEquivalentTo(4);
            list.Count.ShouldBeEquivalentTo(2);
        }

        [Fact]
        public void Should_Check_BinarySearch_Ranges()
        {
            //arrange
            var list = new MyArrayList();
            list.Add(1);
            list.Add(2);

            //act
            Action actLower = () => list.BinarySearch(1, -1, 1);
            Action actHigher = () => list.BinarySearch(1, 1, 3);
            Action actLowerIsHigher = () => list.BinarySearch(1, 1, 0);

            //assert
            actLower.ShouldThrow<ArgumentOutOfRangeException>();
            actHigher.ShouldThrow<ArgumentOutOfRangeException>();
            actLowerIsHigher.ShouldThrow<ArgumentOutOfRangeException>();

            list.Capacity.ShouldBeEquivalentTo(4);
            list.Count.ShouldBeEquivalentTo(2);
        }


        [Fact]
        public void Should_Check_BinarySearch_Even_Length()
        {
            //arrange
            var list = new MyArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            //act
            var result = list.BinarySearch(3);

            //assert
            result.ShouldBeEquivalentTo(2);
            list.Capacity.ShouldBeEquivalentTo(4);
            list.Count.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void Should_Check_BinarySearch_Odd_Length()
        {
            //arrange
            var list = new MyArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            //act
            var result = list.BinarySearch(2);

            //assert
            result.ShouldBeEquivalentTo(1);
            list.Capacity.ShouldBeEquivalentTo(8);
            list.Count.ShouldBeEquivalentTo(5);
        }

        [Fact]
        public void Should_Check_BinarySearch_Not_Find_Lower()
        {
            //arrange
            var list = new MyArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            //act
            var result = list.BinarySearch(-1);

            //assert
            result.ShouldBeEquivalentTo(-1);
            list.Capacity.ShouldBeEquivalentTo(8);
            list.Count.ShouldBeEquivalentTo(5);
        }

        [Fact]
        public void Should_Check_BinarySearch_Not_Find_Higher()
        {
            //arrange
            var list = new MyArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            //act
            var result = list.BinarySearch(6);

            //assert
            result.ShouldBeEquivalentTo(-1);
            list.Capacity.ShouldBeEquivalentTo(8);
            list.Count.ShouldBeEquivalentTo(5);
        }

        [Fact]
        public void Should_Check_BinarySearch_Not_Find_Middle()
        {
            //arrange
            var list = new MyArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(4);
            list.Add(6);
            list.Add(7);

            //act
            var result = list.BinarySearch(3);

            //assert
            result.ShouldBeEquivalentTo(-1);
            list.Capacity.ShouldBeEquivalentTo(8);
            list.Count.ShouldBeEquivalentTo(5);
        }

        [Fact]
        public void Should_Check_BinarySearch_With_Range()
        {
            //arrange
            var list = new MyArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(7);
            list.Add(8);

            //act
            var result = list.BinarySearch(1, 0, 3);

            //assert
            result.ShouldBeEquivalentTo(0);
            list.Capacity.ShouldBeEquivalentTo(8);
            list.Count.ShouldBeEquivalentTo(7);
        }

        [Fact]
        public void Should_Check_BinarySearch_With_Range_False()
        {
            //arrange
            var list = new MyArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);

            //act
            var result = list.BinarySearch(1, 1, 6);

            //assert
            result.ShouldBeEquivalentTo(-1);
            list.Capacity.ShouldBeEquivalentTo(8);
            list.Count.ShouldBeEquivalentTo(7);
        }

        [Fact]
        public void Should_Check_BinarySearch_Unsorted()
        {
            //arrange
            var list = new MyArrayList();
            list.Add(1);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(-6);
            list.Add(7);
            list.Add(2);

            //act
            var result = list.BinarySearch(2);

            //assert
            result.ShouldBeEquivalentTo(-1);
            list.Capacity.ShouldBeEquivalentTo(8);
            list.Count.ShouldBeEquivalentTo(7);
        }

        [Fact]
        public void Should_Clear()
        {
            //arrange
            var list = new MyArrayList();
            list.Add(1);
            list.Add(3);
            list.Add(4);
            list.Add(4);
            list.Add(4);

            object item;
            //act
            list.Clear();
            Action act = () => item = list[0];

            //assert
            list.Capacity.ShouldBeEquivalentTo(8);
            list.Count.ShouldBeEquivalentTo(0);
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Should_Create_With_Collection()
        {
            //arrange
            var data = new object[] { 1, 2, 3, 4, 5 };


            //act
            var list = new MyArrayList(data);

            //assert
            list.Capacity.ShouldBeEquivalentTo(5);
            list.Count.ShouldBeEquivalentTo(5);

            list[0].ShouldBeEquivalentTo(1);
            list[1].ShouldBeEquivalentTo(2);
            list[2].ShouldBeEquivalentTo(3);
            list[3].ShouldBeEquivalentTo(4);
            list[4].ShouldBeEquivalentTo(5);
        }

        [Fact]
        public void Should_Create_With_Collection_Throw_If_Null()
        {
            //arrange

            //act
            Action act = () => new MyArrayList(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Create_With_Capacity()
        {
            //arrange

            //act

            var list = new MyArrayList(3);
            list.Add(4);
            list.Add(4);
            list.Add(4);
            list.Add(4);

            //assert
            list.Count.ShouldBeEquivalentTo(4);
            list.Capacity.ShouldBeEquivalentTo(6);
        }

        [Fact]
        public void Should_Create_With_Capacity_Throw_If_Out_Of_Range()
        {
            //arrange

            //act
            Action act = () => new MyArrayList(-1);

            //assert
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Should_Add_With_IList_Interface()
        {
            //arrange
            var list = new MyArrayList();

            //act
            ((IList)list).Add(1);

            //assert
            list.Count.ShouldBeEquivalentTo(1);
            list.Capacity.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void Should_Clone()
        {
            //arrange
            var list = new MyArrayList(5);
            list.Add(1);
            list.Add(2);
            list.Add(3);

            //act
            var clone = list.Clone();

            //assert
            clone.GetType().ShouldBeEquivalentTo(typeof(MyArrayList));
            ((MyArrayList)clone).Capacity.ShouldBeEquivalentTo(5);
            ((MyArrayList)clone).Count.ShouldBeEquivalentTo(3);

            ((MyArrayList)clone)[0].ShouldBeEquivalentTo(1);
            ((MyArrayList)clone)[1].ShouldBeEquivalentTo(2);
            ((MyArrayList)clone)[2].ShouldBeEquivalentTo(3);
        }

        [Fact]
        public void Should_Contains()
        {
            //arrange
            var list = new MyArrayList(5);
            list.Add(1);
            list.Add(2);
            list.Add(3);

            //act
            var result = list.Contains(2);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_Contains_False()
        {
            //arrange
            var list = new MyArrayList(5);
            list.Add(1);
            list.Add(2);
            list.Add(3);

            //act
            var result = list.Contains(5);

            //assert
            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Should_Contains_True_With_Null_Items()
        {
            //arrange
            var list = new MyArrayList(5);
            list.Add(null);
            list.Add(2);
            list.Add(3);

            //act
            var result = list.Contains(2);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_IndexOf()
        {
            //arrange
            var list = new MyArrayList(5);
            list.Add(1);
            list.Add(2);
            list.Add(3);

            //act
            var result = list.IndexOf(2);

            //assert
            result.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Should_IndexOf_Not_Found()
        {
            //arrange
            var list = new MyArrayList(5);
            list.Add(1);
            list.Add(2);
            list.Add(3);

            //act
            var result = list.IndexOf(5);

            //assert
            result.ShouldBeEquivalentTo(-1);
        }

        [Fact]
        public void Should_IndexOf_Null_True()
        {
            //arrange
            var list = new MyArrayList(5);
            list.Add(1);
            list.Add(2);
            list.Add(null);

            //act
            var result = list.IndexOf(null);

            //assert
            result.ShouldBeEquivalentTo(2);
        }


        [Fact]
        public void Should_IndexOf_When_Contains_Null()
        {
            //arrange
            var list = new MyArrayList(5);
            list.Add(null);
            list.Add(2);
            list.Add(3);

            //act
            var result = list.IndexOf(3);

            //assert
            result.ShouldBeEquivalentTo(2);
        }

        [Fact]
        public void Should_Check_Foreach()
        {
            //arrange
            var data = Enumerable.Range(0, 100).ToArray();
            var list = new MyArrayList(data.Select(x => (object)x));
            int index = 0;
            
            //act

            //assert
            foreach (var item in list)
                item.ShouldBeEquivalentTo(data[index++]);
        }

        [Fact]
        public void Should_CopyTo()
        {
            //arrange
            var result = new int[5];
            var list = new MyArrayList(new object[]{1,2,3,4,5});
            
            //act
            list.CopyTo(result, 0);

            //assert
            for(int i = 0 ; i < result.Length;i++)
                result[i].ShouldBeEquivalentTo(list[i]);
        }

        [Fact]
        public void Should_CopyTo_Check_Null()
        {
            //arrange
            var list = new MyArrayList(new object[] { 1, 2, 3, 4, 5 });

            //act
            Action act = () => list.CopyTo(null, 0);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_CopyTo_Check_Array_Index()
        {
            //arrange
            var list = new MyArrayList(new object[] { 1, 2, 3, 4, 5 });
            var result = new int[5];

            //act
            Action actLower = () => list.CopyTo(result, -1);
            Action actHigher = () => list.CopyTo(result, 7);
            Action actOverflow = () => list.CopyTo(result, 3);

            //assert
            actLower.ShouldThrow<ArgumentOutOfRangeException>();
            actHigher.ShouldThrow<ArgumentOutOfRangeException>();
            actOverflow.ShouldThrow<ArgumentOutOfRangeException>();
        }


        [Fact]
        public void Should_Remove()
        {
            //arrange
            var list = new MyArrayList(new object[] { 1, 2, 3, 4, 5 });

            //act
            list.Remove(3);

            //assert
            list.Count.ShouldBeEquivalentTo(4);
            list.Capacity.ShouldBeEquivalentTo(5);

            list[0].ShouldBeEquivalentTo(1);
            list[1].ShouldBeEquivalentTo(2);
            list[2].ShouldBeEquivalentTo(4);
            list[3].ShouldBeEquivalentTo(5);
        }

        [Fact]
        public void Should_Remove_Not_Throw_When_Not_Found()
        {
            //arrange
            var list = new MyArrayList(new object[] { 1, 2, 3, 4, 5 });

            //act
            Action act = () => list.Remove(66);

            //assert
            act.ShouldNotThrow();

            list.Count.ShouldBeEquivalentTo(5);
            list.Capacity.ShouldBeEquivalentTo(5);

            list[0].ShouldBeEquivalentTo(1);
            list[1].ShouldBeEquivalentTo(2);
            list[2].ShouldBeEquivalentTo(3);
            list[3].ShouldBeEquivalentTo(4);
            list[4].ShouldBeEquivalentTo(5);
        }

        [Fact]
        public void Should_RemoveAt_Check_Index()
        {
            //arrange
            var list = new MyArrayList(new object[] { 1, 2, 3, 4, 5 });

            //act
            Action actLower = () => list.RemoveAt(-1);
            Action actHigher = () => list.RemoveAt(66);

            //assert
            actLower.ShouldThrow<ArgumentOutOfRangeException>();
            actHigher.ShouldThrow<ArgumentOutOfRangeException>();

            list.Count.ShouldBeEquivalentTo(5);
            list.Capacity.ShouldBeEquivalentTo(5);

            list[0].ShouldBeEquivalentTo(1);
            list[1].ShouldBeEquivalentTo(2);
            list[2].ShouldBeEquivalentTo(3);
            list[3].ShouldBeEquivalentTo(4);
            list[4].ShouldBeEquivalentTo(5);
        }

        [Fact]
        public void Should_RemoveAt()
        {
            //arrange
            var list = new MyArrayList(new object[] { 1, 2, 3, 4, 5 });

            //act
            list.RemoveAt(3);
            list.RemoveAt(1);

            //assert
            list.Count.ShouldBeEquivalentTo(3);
            list.Capacity.ShouldBeEquivalentTo(5);

            list[0].ShouldBeEquivalentTo(1);
            list[1].ShouldBeEquivalentTo(3);
            list[2].ShouldBeEquivalentTo(5);
        }
    }
}
