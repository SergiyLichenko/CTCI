using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Algorithms.UT
{
    public class RabinKarpTests
    {
        private RabinKarp _rabinKarp;
        public RabinKarpTests()
        {
            _rabinKarp = new RabinKarp();
        }

        [Fact]
        public void Should_Throw_If_Input_Is_Null()
        {
            //arrange

            //act
            Action action = () => RabinKarp.Compute(null, null);

            //assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Check_Example()
        {
            //arrange
            string text = "abedabc";
            string pattern = "abc";

            //act
            var result = RabinKarp.Compute(text, pattern);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_Check_Empty_String()
        {
            //arrange
            string text = "";
            string pattern = "";

            //act
            var result = RabinKarp.Compute(text, pattern);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_Check_Wrong_Length()
        {
            //arrange
            string text = "";
            string pattern = "1";

            //act
            var result = RabinKarp.Compute(text, pattern);

            //assert
            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Should_Check_False()
        {
            //arrange
            string text = "abedabc";
            string pattern = "dbc";

            //act
            var result = RabinKarp.Compute(text, pattern);

            //assert
            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Should_Check_Same_Length()
        {
            //arrange
            string text = "abedabc";
            string pattern = "abedabc";

            //act
            var result = RabinKarp.Compute(text, pattern);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_Check_End()
        {
            //arrange
            string text = "abcc";
            string pattern = "bcc";

            //act
            var result = RabinKarp.Compute(text, pattern);

            //assert
            result.ShouldBeEquivalentTo(true);
        }
    }
}
