using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Tasks.MathLogic;
using Xunit;

namespace Tasks.UT
{
    public class MathLogicTests
    {
        [Fact]
        public void Posion_Should_Throw_If_Null()
        {
            //arrange
            var mathLogic = new MathLogic.MathLogic();

            //act
            Action actFirst = ()=> mathLogic.Poison(null, new List<TestStrip>());
            Action actSecond = () => mathLogic.Poison(new List<Bottle>(), null);

            //assert
            actFirst.ShouldThrow<ArgumentNullException>();
            actSecond.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Posion_Should_Check_Example()
        {
            //arrange
            int poisonedIndex = 768;
            int day = 28;
            var mathLogic = new MathLogic.MathLogic();

            var bottles = new List<Bottle>();
            for(int i = 0 ; i < 1000; i++)
                bottles.Add(new Bottle(i,i == poisonedIndex));
            var testStrips = new List<TestStrip>();
            for(int i = 0 ; i< 10;i++)
                testStrips.Add(new TestStrip());

            //act
            var result = mathLogic.Poison(bottles, testStrips);

            //assert
            result[0].ShouldBeEquivalentTo(poisonedIndex);
            result[1].ShouldBeEquivalentTo(day);
        }

        [Fact]
        public void Posion_Should_Check_Zero()
        {
            //arrange
            int poisonedIndex = 0;
            int day = 21;
            var mathLogic = new MathLogic.MathLogic();

            var bottles = new List<Bottle>();
            for (int i = 0; i < 1000; i++)
                bottles.Add(new Bottle(i, i == poisonedIndex));
            var testStrips = new List<TestStrip>();
            for (int i = 0; i < 10; i++)
                testStrips.Add(new TestStrip());

            //act
            var result = mathLogic.Poison(bottles, testStrips);

            //assert
            result[0].ShouldBeEquivalentTo(poisonedIndex);
            result[1].ShouldBeEquivalentTo(day);
        }

        [Fact]
        public void Posion_Should_Check_Max()
        {
            //arrange
            int poisonedIndex = 999;
            int day = 28;
            var mathLogic = new MathLogic.MathLogic();

            var bottles = new List<Bottle>();
            for (int i = 0; i < 1000; i++)
                bottles.Add(new Bottle(i, i == poisonedIndex));
            var testStrips = new List<TestStrip>();
            for (int i = 0; i < 10; i++)
                testStrips.Add(new TestStrip());

            //act
            var result = mathLogic.Poison(bottles, testStrips);

            //assert
            result[0].ShouldBeEquivalentTo(poisonedIndex);
            result[1].ShouldBeEquivalentTo(day);
        }

        [Fact]
        public void Posion_Should_Throw_If_No_Poisoned()
        {
            //arrange
            var mathLogic = new MathLogic.MathLogic();

            var bottles = new List<Bottle>();
            for (int i = 0; i < 1000; i++)
                bottles.Add(new Bottle(i, false));
            var testStrips = new List<TestStrip>();
            for (int i = 0; i < 10; i++)
                testStrips.Add(new TestStrip());

            //act
            Action act = ()=> mathLogic.Poison(bottles, testStrips);

            //assert
            act.ShouldThrow<ArgumentException>();
        }
    }
}
