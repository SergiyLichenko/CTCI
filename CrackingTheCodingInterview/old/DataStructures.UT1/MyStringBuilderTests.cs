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
    }
}
