using System;
using Xunit;
using FluentAssertions;
using Xunit.Sdk;

namespace DataStructures.UT
{
    public class MyStringBuilderTests
    {
        [Fact]
        public void Should_Create_Default_My_String_Builder()
        {
            //act 
            var builder = new MyStringBuilder();

            //assert
            builder.Length.ShouldBeEquivalentTo(0);
            builder.Capacity.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void Should_Create_My_String_Builder_With_Capacity()
        {
            //arrange
            int capacity = 8;

            //act 
            var builder = new MyStringBuilder(capacity);

            //assert
            builder.Length.ShouldBeEquivalentTo(0);
            builder.Capacity.ShouldBeEquivalentTo(8);
        }


        [Fact]
        public void Should_Not_Create_My_String_Builder_With_Negative_Capacity()
        {
            //arrange
            int capacity = -1;
            MyStringBuilder builder;

            //act 
            Action act = () => builder = new MyStringBuilder(capacity);

            //assert
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Should_Create_My_String_Builder_With_String()
        {
            //arrange
            string str = "hello";

            //act 
            MyStringBuilder builder = new MyStringBuilder(str);

            //assert
            builder.Length.ShouldBeEquivalentTo(str.Length);
            builder.Capacity.ShouldBeEquivalentTo(str.Length);
            builder.ToString().ShouldBeEquivalentTo(str);
        }

        [Fact]
        public void Should_Get_GetIndexer()
        {
            //arrange
            string str = "hello";

            //act 
            MyStringBuilder builder = new MyStringBuilder(str);

            //assert
            for (int i = 0; i < str.Length; i++)
                str[i].ShouldBeEquivalentTo(builder[i]);
        }

        [Fact]
        public void Should_Get_SetIndexer()
        {
            //arrange
            string str = "hello";
            MyStringBuilder builder = new MyStringBuilder(str);

            //act 
            builder[0] = 'H';


            //assert
            builder.ToString()[0].ShouldBeEquivalentTo('H');
        }

        [Fact]
        public void Should_Throw_If_GetIndexer_Index_OutRange()
        {
            //arrange
            string str = "hello";
            var ch = '\0';

            //act 
            MyStringBuilder builder = new MyStringBuilder(str);
            Action act = () => ch = builder[-1];

            //assert
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Should_Throw_If_SetIndexer_Index_OutRange()
        {
            //arrange
            string str = "hello";

            //act 
            MyStringBuilder builder = new MyStringBuilder(str);
            Action act = () => builder[str.Length] = 's';

            //assert
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Should_Check_Append()
        {
            //arrange
            string str = "Hello";
            string str2 = "World!";
            string resultStr = "HelloWorld!";

            //act 
            MyStringBuilder builder = new MyStringBuilder(str);
            builder.Append(str2);
            var result = builder.ToString();
            
            //assert
            result.ShouldBeEquivalentTo(resultStr);
        }

        [Fact]
        public void Should_Check_Clear()
        {
            //arrange
            string str = "Hello";
            string resultStr = "";

            //act 
            MyStringBuilder builder = new MyStringBuilder(str);
            builder.Clear();
            var result = builder.ToString();

            //assert
            result.ShouldBeEquivalentTo(resultStr);
        }

        [Fact]
        public void Should_Check_Copy_To()
        {
            //arrange
            string str = "Hello";
            char [] array = new char[str.Length];

            //act 
            MyStringBuilder builder = new MyStringBuilder(str);
            builder.CopyTo(0,array,0, builder.Length);

            //assert
            String.Join("", array).ShouldBeEquivalentTo(str);
        }

        [Fact]
        public void Should_Check_Equals_True()
        {
            //arrange
            string str = "Hello";
            MyStringBuilder builder1 = new MyStringBuilder(str);
            MyStringBuilder builder2 = new MyStringBuilder(str);
           

            //act 
            var result = builder1.Equals(builder2);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_Check_Equals_False()
        {
            //arrange
            string str1 = "Hello";
            string str2 = "hello";
            MyStringBuilder builder1 = new MyStringBuilder(str1);
            MyStringBuilder builder2 = new MyStringBuilder(str2);


            //act 
            var result = builder1.Equals(builder2);

            //assert
            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Should_Check_Insert()
        {
            //arrange
            string str1 = "Hello";
            string str2 = "hello";
            string resultStr = "Hehellollo";
            MyStringBuilder builder = new MyStringBuilder(str1);

            //act 
            var result = builder.Insert(2, str2);

            //assert
            result.ToString().ShouldBeEquivalentTo(resultStr);
        }

        [Fact]
        public void Should_Check_Replace()
        {
            //arrange
            string str = "hellohe";
            string oldVal = "he";
            string newVal = "Het";
            string resultStr = "HetlloHet";

            MyStringBuilder builder = new MyStringBuilder(str);

            //act 
            var result = builder.Replace(oldVal, newVal);

            //assert
            result.ToString().ShouldBeEquivalentTo(resultStr);
        }

        [Fact]
        public void Should_Check_Remove()
        {
            //arrange
            string str = "Hello";
            string resultStr = "Heo";
            MyStringBuilder builder = new MyStringBuilder(str);

            //act 
            var result = builder.Remove(2, 2);

            //assert
            result.ToString().ShouldBeEquivalentTo(resultStr);
        }
    }
}
