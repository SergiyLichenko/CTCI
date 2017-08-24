using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Tasks.UT
{
    public class RecursionNDynamicProgrammingTests
    {
        public RecursionNDynamicProgrammingTests()
        {
            _recursionNDynamicProgramming = new RecursionNDynamicProgramming();
        }
        private readonly RecursionNDynamicProgramming _recursionNDynamicProgramming;

        [Fact]
        public void Triple_Step_Should_Check_First_Three()
        {
            //arrange

            //act
            var first = _recursionNDynamicProgramming.TripleStep(1);
            var second = _recursionNDynamicProgramming.TripleStep(2);
            var third = _recursionNDynamicProgramming.TripleStep(3);

            //assert
            first.ShouldBeEquivalentTo(1);
            second.ShouldBeEquivalentTo(2);
            third.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void Triple_Step_Should_Throw_If_Not_In_Range()
        {
            //arrange

            //act
            Action actZero = () => _recursionNDynamicProgramming.TripleStep(0);
            Action actNegative = () => _recursionNDynamicProgramming.TripleStep(-1);

            //assert
            actZero.ShouldThrow<ArgumentOutOfRangeException>();
            actNegative.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Triple_Step_Should_Check_Example()
        {
            //arrange

            //act
            var first = _recursionNDynamicProgramming.TripleStep(4);

            //assert
            first.ShouldBeEquivalentTo(7);
        }

        [Fact]
        public void Triple_Step_Should_Check_Example_Higher()
        {
            //arrange

            //act
            var first = _recursionNDynamicProgramming.TripleStep(6);

            //assert
            first.ShouldBeEquivalentTo(24);
        }
    }
}
