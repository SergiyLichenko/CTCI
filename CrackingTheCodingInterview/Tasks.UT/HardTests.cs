using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Tasks.UT
{
    public class HardTests
    {
        private readonly Hard _subject;
        public HardTests()
        {
            _subject = new Hard();
        }

        [Fact]
        public void AddWithPlus_Should_Add_Positive_Numbers()
        {
            //Arrange
            int a = 5;
            int b = 7;

            //Act
            var result = _subject.AddWithoutPlus(a, b);

            //Assert
            result.ShouldBeEquivalentTo(a + b);
        }

        [Fact]
        public void AddWithPlus_Should_Add_Zero()
        {
            //Arrange
            int a = 0;
            int b = 7;

            //Act
            var result = _subject.AddWithoutPlus(a, b);

            //Assert
            result.ShouldBeEquivalentTo(a + b);
        }

        [Fact]
        public void AddWithPlus_Should_Add_Negative_Number()
        {
            //Arrange
            int a = -2;
            int b = 7;

            //Act
            var result = _subject.AddWithoutPlus(a, b);

            //Assert
            result.ShouldBeEquivalentTo(a + b);
        }

        [Fact]
        public void AddWithPlus_Should_Add_Two_Negative_Numbers()
        {
            //Arrange
            int a = -2;
            int b = -7;

            //Act
            var result = _subject.AddWithoutPlus(a, b);

            //Assert
            result.ShouldBeEquivalentTo(a + b);
        }

        [Fact]
        public void AddWithPlus_Should_Check_Load_With_Random_Numbers()
        {
            //Arrange
            int count = 10000;
            var random = new Random();

            //Assert
            while (count-- >= 0)
            {
                var first = random.Next();
                var second = random.Next();

                var result = _subject.AddWithoutPlus(first, second);
                result.ShouldBeEquivalentTo(first + second);
            }
        }

        [Fact]
        public void SubstractWithoutMinus_Should_Substact_Positive_Numbers()
        {
            //Arrange
            int a = 5;
            int b = 7;

            //Act
            var result = _subject.SubstractWithoutMinus(a, b);

            //Assert
            result.ShouldBeEquivalentTo(a - b);
        }

        [Fact]
        public void SubstractWithoutMinus_Should_Substract_Zero()
        {
            //Arrange
            int a = 7;
            int b = 0;

            //Act
            var result = _subject.SubstractWithoutMinus(a, b);

            //Assert
            result.ShouldBeEquivalentTo(a - b);
        }

        [Fact]
        public void SubstractWithoutMinus_Should_Substract_Negative_Number()
        {
            //Arrange
            int a = 2;
            int b = -7;

            //Act
            var result = _subject.SubstractWithoutMinus(a, b);

            //Assert
            result.ShouldBeEquivalentTo(a - b);
        }

        [Fact]
        public void SubstractWithoutMinus_Should_Substract_Two_Negative_Numbers()
        {
            //Arrange
            int a = -2;
            int b = -7;

            //Act
            var result = _subject.SubstractWithoutMinus(a, b);

            //Assert
            result.ShouldBeEquivalentTo(a - b);
        }

        [Fact]
        public void SubstractWithoutMinus_Should_Check_Load_With_Random_Numbers()
        {
            //Arrange
            int count = 10000;
            var random = new Random();

            //Assert
            while (count-- >= 0)
            {
                var first = random.Next();
                var second = random.Next();

                var result = _subject.SubstractWithoutMinus(first, second);
                result.ShouldBeEquivalentTo(first - second);
            }
        }

        [Fact]
        public void Shuffle_Should_Throw_If_Null()
        {
            //Act
            Action act = () => _subject.Shuffle(null).ToArray();

            //Assert
            act.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void Shuffle_Should_Shuffle()
        {
            //Arrange
            var cards = Enumerable.Range(1, 52).ToArray();

            //Act
            var result = _subject.Shuffle(cards).ToArray();

            //Assert
            result.SequenceEqual(cards).ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Shuffle_Should_Not_Be_Immutable()
        {
            //Arrange
            var cards = Enumerable.Range(1, 52).ToArray();
            var copyCards = new int[cards.Length];
            Array.Copy(cards, copyCards, cards.Length);

            //Act
            var result = _subject.Shuffle(cards).ToArray();

            //Assert
            result.SequenceEqual(cards).ShouldBeEquivalentTo(false);
            cards.SequenceEqual(copyCards).ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void RandomSet_Should_Throw_If_Null()
        {
            //Act
            Action act = () => _subject.RandomSet(null, 1).ToArray();

            //Assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void RandomSet_Should_Throw_If_Negative()
        {
            //Arrange
            var array = Enumerable.Range(0, 5);

            //Act
            Action act = () => _subject.RandomSet(array, -1).ToArray();

            //Assert
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void RandomSet_Should_Throw_If_Subset_Length_IsBigger()
        {
            //Arrange
            var array = Enumerable.Range(0, 5);

            //Act
            Action act = () => _subject.RandomSet(array, 6).ToArray();

            //Assert
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void RandomSet_Should_Generate()
        {
            //Arrange
            var array = Enumerable.Range(1, 52).ToArray();

            //Act
            var result = _subject.RandomSet(array, 5).ToArray();

            //Assert
            result.Distinct().Count().ShouldBeEquivalentTo(result.Length);
            foreach (var item in result)
                array.Contains(item).ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void RandomSet_Should_Not_Be_Immutable()
        {
            //Arrange
            var array = Enumerable.Range(1, 52).ToArray();
            var arrayCopy = new int[array.Length];
            Array.Copy(array, arrayCopy, array.Length);

            //Act
            _subject.RandomSet(arrayCopy, 5).ToArray();

            //Assert
            arrayCopy.SequenceEqual(array).ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void MissingNumber_Should_Throw_If_Null()
        {
            //Act
            Action act = () => _subject.MissingNumber(null, 0);

            //Assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void MissingNumber_Should_Throw_If_Negative()
        {
            //Arrange
            int count = 5;
            var list = Enumerable.Range(0, count).ToList();
            var removedIndex = new Random().Next(count);
            list.RemoveAt(removedIndex);

            //Act
            Action act = () => _subject.MissingNumber(list.ToArray(), -1);

            //Assert
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void MissingNumber_Should_Throw_If_N_Not_Equals_Length_Plus_One()
        {
            //Arrange
            int count = 5;
            var list = Enumerable.Range(0, count).ToList();
            var removedIndex = new Random().Next(count);
            list.RemoveAt(removedIndex);

            //Act
            Action act = () => _subject.MissingNumber(list.ToArray(), count + 1);

            //Assert
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void MissingNumber_Should_Find_Removed_Item()
        {
            //Arrange
            int count = 5;
            var list = Enumerable.Range(0, count).ToList();
            var removedIndex = new Random().Next(count);
            var removedItem = list[removedIndex];
            list.RemoveAt(removedIndex);

            //Act
            var result = _subject.MissingNumber(list.ToArray(), count);

            //Assert
            result.ShouldBeEquivalentTo(removedItem);
        }

        [Fact]
        public void MissingNumber_Should_Find_Removed_Item_Load_Test()
        {
            int testCount = 1000;

            while (testCount-- >= 0)
            {
                int count = 1000;
                var list = Enumerable.Range(0, count).ToList();
                var removedIndex = new Random().Next(count);
                var removedItem = list[removedIndex];
                list.RemoveAt(removedIndex);

                var result = _subject.MissingNumber(list.ToArray(), count);

                result.ShouldBeEquivalentTo(removedItem);
            }
        }


        [Fact]
        public void LettersAndNumbers_Should_Throw_If_Null()
        {
            //Act
            Action act = () => _subject.LettersAndNumbers(null).ToArray();

            //Assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void LettersAndNumbers_Should_Check_Empty()
        {
            //Arrange
            var array = new char[0];

            //Act
            var result = _subject.LettersAndNumbers(array).ToArray();

            //Assert
            result.Length.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void LettersAndNumbers_Should_Check_Max_Length()
        {
            //Arrange
            var array = new char[] { 'a', 'b', 'c', '1', '2', 'c', '4', '5' };

            //Act
            var result = _subject.LettersAndNumbers(array).ToArray();

            //Assert
            result.SequenceEqual(array).ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void LettersAndNumbers_Should_Check_Min_Length()
        {
            //Arrange
            var array = new char[] { 'a', 'b', 'c', 'd', '2', 'c', 'f', 't' };

            //Act
            var result = _subject.LettersAndNumbers(array).ToArray();

            //Assert
            result.Length.ShouldBeEquivalentTo(2);
            result[0].ShouldBeEquivalentTo('d');
            result[1].ShouldBeEquivalentTo('2');
        }

        [Fact]
        public void LettersAndNumbers_Should_Check_All_Numbers()
        {
            //Arrange
            var array = new char[] { '1', '2', '3', '3', '4', '5', '6', '7' };

            //Act
            var result = _subject.LettersAndNumbers(array).ToArray();

            //Assert
            result.Length.ShouldBeEquivalentTo(1);
            array.Contains(result[0]).ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void LettersAndNumbers_Should_Check_All_Letters()
        {
            //Arrange
            var array = new char[] { 'a', 'b', 'c', 'f', 'r', 'e', 'w', 'q' };

            //Act
            var result = _subject.LettersAndNumbers(array).ToArray();

            //Assert
            result.Length.ShouldBeEquivalentTo(1);
            array.Contains(result[0]).ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void CountOf2s_Should_Example()
        {
            //Arrange
            int n = 25;

            //Act
            var result = _subject.CountOf2s(n);

            //Assert
            result.ShouldBeEquivalentTo(9);
        }

        [Fact]
        public void CountOf2s_Should_Throw_If_Negative_Number()
        {
            //Arrange
            int n = -25;

            //Act
            Action act  =()=> _subject.CountOf2s(n);

            //Assert
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void CountOf2s_Should_Check_Zero()
        {
            //Arrange
            int n = 0;

            //Act
            var result = _subject.CountOf2s(n);

            //Assert
            result.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void CountOf2s_Should_Check_Hundrets()
        {
            //Arrange
            int n = 122;

            //Act
            var result = _subject.CountOf2s(n);

            //Assert
            result.ShouldBeEquivalentTo(26);
        }

        [Fact]
        public void CountOf2s_Should_Check_Thousands()
        {
            //Arrange
            int n = 991;

            //Act
            var result = _subject.CountOf2s(n);

            //Assert
            result.ShouldBeEquivalentTo(299);
        }

        [Fact]
        public void housands()
        {
            //Arrange
            int n = 991;

            int count = 0;

            for (int i = 0; i <= n; i++)
                count += i.ToString().Count(x => x == '2');

        }
    }
}
