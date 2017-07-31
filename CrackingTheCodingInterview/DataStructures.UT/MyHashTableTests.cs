using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace DataStructures.UT
{
    public class MyHashTableTests
    {
        [Fact]
        public void Should_Create_With_Default_Length()
        {
            //arrange

            //act
            MyHashTable<int, int> map = new MyHashTable<int, int>();

            //assert
            map.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Should_Add_Item()
        {
            //arrange
            var key = "key";
            var value = "value";

            //act
            var map = new MyHashTable<string, string>();
            map.Add(key, value);

            //assert
            map.Count.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Should_Check_Contains_Key_True()
        {
            //arrange
            var key = "key";
            var value = "value";
            var map = new MyHashTable<string, string>();
            map.Add(key, value);

            //act
            var result = map.ContainsKey(key);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_Check_Contains_Key_False()
        {
            //arrange
            var key = "key";
            var value = "value";
            var keyFalse = "Key";
            var map = new MyHashTable<string, string>();
            map.Add(key, value);

            //act
            var result = map.ContainsKey(keyFalse);

            //assert
            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Should_Check_Contains_Value_True()
        {
            //arrange
            var key = "key";
            var value = "value";
            var map = new MyHashTable<string, string>();
            map.Add(key, value);

            //act
            var result = map.ContainsValue(value);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_Check_Contains_Value_False()
        {
            //arrange
            var key = "key";
            var value = "value";
            var valueFalse = "Value";
            var map = new MyHashTable<string, string>();
            map.Add(key, value);

            //act
            var result = map.ContainsValue(valueFalse);

            //assert
            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Should_Check_Contains_Value_For_Multiple_Entries()
        {
            //arrange
            var key = "key";
            var value = "value";
            var map = new MyHashTable<string, string>();
            map.Add(key, value);
            map.Add(key + "1", value + "1");

            //act
            var result = map.ContainsValue(value);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_Check_Contains_Key_For_Multiple_Entries()
        {
            //arrange
            var key = "key";
            var value = "value";
            var map = new MyHashTable<string, string>();
            map.Add(key, value);
            map.Add(key + "1", value + "1");

            //act
            var result = map.ContainsKey(key);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_Check_Clear()
        {
            //arrange
            var key = "key";
            var value = "value";
            var map = new MyHashTable<string, string>();
            map.Add(key, value);

            //act
            map.Clear();
            var keyResult = map.ContainsKey(key);
            var valueResult = map.ContainsValue(value);
            var count = map.Count;

            //assert
            keyResult.ShouldBeEquivalentTo(false);
            valueResult.ShouldBeEquivalentTo(false);
            count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Should_Check_Remove()
        {
            //arrange
            var key = "key";
            var value = "value";
            var map = new MyHashTable<string, string>();
            map.Add(key, value);
            map.Add(key + "1", value + "1");

            //act
            map.Remove(key);
            var keyResult = map.ContainsKey(key);
            var valueResult = map.ContainsValue(value);
            var count = map.Count;

            //assert
            keyResult.ShouldBeEquivalentTo(false);
            valueResult.ShouldBeEquivalentTo(false);
            count.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Should_Throw_When_Key_Is_Presented_For_Adding()
        {
            //arrange
            var key = "key";
            var value = "value";
            var map = new MyHashTable<string, string>();
            map.Add(key, value);


            //act
            Action act = () => map.Add(key, value);

            //assert
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Should_Check_Try_Get_Value_True()
        {
            //arrange
            var key = "key";
            var value = "value";
            var map = new MyHashTable<string, string>();
            map.Add(key, value);

            string valueResult;
            //act
            var result = map.TryGetValue(key, out valueResult);

            //assert
            result.ShouldBeEquivalentTo(true);
            valueResult.ShouldBeEquivalentTo(value);
        }

        [Fact]
        public void Should_Check_Try_Get_Value_False()
        {
            //arrange
            var key = "key";
            var value = "value";
            var map = new MyHashTable<string, string>();
            map.Add(key, value);

            string valueResult;
            //act
            var result = map.TryGetValue(key + "1", out valueResult);

            //assert
            result.ShouldBeEquivalentTo(false);
            valueResult.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void Should_Check_GetIndexer()
        {
            //arrange
            var key = "key";
            var value = "value";
            var map = new MyHashTable<string, string>();
            map.Add(key, value);


            //act
            var result = map[key];

            //assert
            result.ShouldBeEquivalentTo(value);
        }

        [Fact]
        public void Should_Check_SetIndex()
        {
            //arrange
            var key = "key";
            var value = "value";
            var newValue = "newValue";

            var map = new MyHashTable<string, string>();
            map.Add(key, value);

            //act
            map[key] = newValue;
            var result = map.ContainsValue(newValue);

            //assert
            result.ShouldBeEquivalentTo(true);
            map.Count.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Should_Check_Trow_GetIndex()
        {
            //arrange
            var key = "key";
            var value = "value";

            var map = new MyHashTable<string, string>();
            map.Add(key, value);

            string newValue = null;
            //act
            Action act = () => newValue = map[key + "1"];

            //assert
            act.ShouldThrow<KeyNotFoundException>();
        }


        [Fact]
        public void Should_Check_Add_For_SetIndexer()
        {
            //arrange
            var key = "key";
            var value = "value";

            //act
            var map = new MyHashTable<string, string>();
            map[key] = value;

            var containsKey =map.ContainsKey(key);
            var containsValue = map.ContainsValue(value);
            var count = map.Count;

            //assert
            containsKey.ShouldBeEquivalentTo(true);
            containsValue.ShouldBeEquivalentTo(true);
            count.ShouldBeEquivalentTo(1);
        }
    }
}
