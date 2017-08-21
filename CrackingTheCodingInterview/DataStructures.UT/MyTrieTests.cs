using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace DataStructures.UT
{
    public class MyTrieTests
    {
        [Fact]
        public void Should_Create_Default()
        {
            //arrange

            //act
            var trie = new MyTrie.MyTrie();

            //assert
            trie.Root.Should().NotBeNull();
            trie.Root.EndOfWord.ShouldBeEquivalentTo(false);
            trie.Root.Children.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Should_Insert_Throw_If_Null()
        {
            //arrange
            var trie = new MyTrie.MyTrie();

            //act
            Action act = () => trie.Insert(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Insert()
        {
            //arrange
            var trie = new MyTrie.MyTrie();

            //act
            trie.Insert("abc");

            //assert
            trie.Root.Children.ContainsKey('a').ShouldBeEquivalentTo(true);
            trie.Root.EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['a'].Children.ContainsKey('b').ShouldBeEquivalentTo(true);
            trie.Root.Children['a'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['a'].Children['b'].Children.ContainsKey('c').ShouldBeEquivalentTo(true);
            trie.Root.Children['a'].Children['b'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['a'].Children['b'].Children['c'].EndOfWord.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_Insert_Multiple()
        {
            //arrange
            var trie = new MyTrie.MyTrie();

            //act
            trie.Insert("abc");
            trie.Insert("abgl");
            trie.Insert("cdf");
            trie.Insert("abcd");
            trie.Insert("lmn");

            //assert
            trie.Root.Children.ContainsKey('a').ShouldBeEquivalentTo(true);
            trie.Root.Children.ContainsKey('c').ShouldBeEquivalentTo(true);
            trie.Root.Children.ContainsKey('l').ShouldBeEquivalentTo(true);
            trie.Root.EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['a'].Children.ContainsKey('b').ShouldBeEquivalentTo(true);
            trie.Root.Children['a'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['a'].Children['b'].Children.ContainsKey('c').ShouldBeEquivalentTo(true);
            trie.Root.Children['a'].Children['b'].Children.ContainsKey('g').ShouldBeEquivalentTo(true);
            trie.Root.Children['a'].Children['b'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['a'].Children['b'].Children['c'].Children.ContainsKey('d').ShouldBeEquivalentTo(true);
            trie.Root.Children['a'].Children['b'].Children['c'].EndOfWord.ShouldBeEquivalentTo(true);

            trie.Root.Children['a'].Children['b'].Children['c'].Children['d'].Children.Count.ShouldBeEquivalentTo(0);
            trie.Root.Children['a'].Children['b'].Children['c'].Children['d'].EndOfWord.ShouldBeEquivalentTo(true);

            trie.Root.Children['a'].Children['b'].Children['g'].Children.ContainsKey('l').ShouldBeEquivalentTo(true);
            trie.Root.Children['a'].Children['b'].Children['g'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['a'].Children['b'].Children['g'].Children['l'].Children.Count.ShouldBeEquivalentTo(0);
            trie.Root.Children['a'].Children['b'].Children['g'].Children['l'].EndOfWord.ShouldBeEquivalentTo(true);

            trie.Root.Children['c'].Children.ContainsKey('d').ShouldBeEquivalentTo(true);
            trie.Root.Children['c'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['c'].Children['d'].Children.ContainsKey('f').ShouldBeEquivalentTo(true);
            trie.Root.Children['c'].Children['d'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['c'].Children['d'].Children['f'].Children.Count.ShouldBeEquivalentTo(0);
            trie.Root.Children['c'].Children['d'].Children['f'].EndOfWord.ShouldBeEquivalentTo(true);

            trie.Root.Children['l'].Children.ContainsKey('m').ShouldBeEquivalentTo(true);
            trie.Root.Children['l'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['l'].Children['m'].Children.ContainsKey('n').ShouldBeEquivalentTo(true);
            trie.Root.Children['l'].Children['m'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['l'].Children['m'].Children['n'].Children.Count.ShouldBeEquivalentTo(0);
            trie.Root.Children['l'].Children['m'].Children['n'].EndOfWord.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_Check_Contains_Word()
        {
            //arrange
            var trie = new MyTrie.MyTrie();
            trie.Insert("abc");
            trie.Insert("abgl");
            trie.Insert("cdf");
            trie.Insert("abcd");
            trie.Insert("lmn");

            //act

            //assert
            trie.ContainsWord("abc").ShouldBeEquivalentTo(true);
            trie.ContainsWord("ab").ShouldBeEquivalentTo(false);
            trie.ContainsWord("").ShouldBeEquivalentTo(false);
            trie.ContainsWord("abcd").ShouldBeEquivalentTo(true);
            trie.ContainsWord("abcc").ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Should_Check_Contains_Word_Throw_If_Null()
        {
            //arrange
            var trie = new MyTrie.MyTrie();
            trie.Insert("abc");
            trie.Insert("abgl");
            trie.Insert("cdf");
            trie.Insert("abcd");
            trie.Insert("lmn");

            //act
            Action act = () => trie.ContainsWord(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Check_Contains_Prefix_Throw_If_Null()
        {
            //arrange
            var trie = new MyTrie.MyTrie();
            trie.Insert("abc");
            trie.Insert("abgl");
            trie.Insert("cdf");
            trie.Insert("abcd");
            trie.Insert("lmn");

            //act
            Action act = () => trie.ContainsPrefix(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Check_Contains_Prefix_Empty()
        {
            //arrange
            var trie = new MyTrie.MyTrie();
            trie.Insert("abc");
            trie.Insert("abgl");
            trie.Insert("cdf");
            trie.Insert("abcd");
            trie.Insert("lmn");

            //act


            //assert
            trie.ContainsPrefix("").ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_Check_Contains_Prefix()
        {
            //arrange
            var trie = new MyTrie.MyTrie();
            trie.Insert("abc");
            trie.Insert("abgl");
            trie.Insert("cdf");
            trie.Insert("abcd");
            trie.Insert("lmn");

            //act

            //assert
            trie.ContainsPrefix("lmn").ShouldBeEquivalentTo(true);
            trie.ContainsPrefix("ab").ShouldBeEquivalentTo(true);
            trie.ContainsPrefix("lo").ShouldBeEquivalentTo(false);
            trie.ContainsPrefix("abc").ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_DeleteWord_Flag_Changes()
        {
            //arrange
            var trie = new MyTrie.MyTrie();
            trie.Insert("abc");
            trie.Insert("abgl");
            trie.Insert("cdf");
            trie.Insert("abcd");
            trie.Insert("lmn");

            //act
            trie.DeleteWord("abc");

            //assert
            trie.Root.Children.ContainsKey('a').ShouldBeEquivalentTo(true);
            trie.Root.Children.ContainsKey('c').ShouldBeEquivalentTo(true);
            trie.Root.Children.ContainsKey('l').ShouldBeEquivalentTo(true);
            trie.Root.EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['a'].Children.ContainsKey('b').ShouldBeEquivalentTo(true);
            trie.Root.Children['a'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['a'].Children['b'].Children.ContainsKey('c').ShouldBeEquivalentTo(true);
            trie.Root.Children['a'].Children['b'].Children.ContainsKey('g').ShouldBeEquivalentTo(true);
            trie.Root.Children['a'].Children['b'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['a'].Children['b'].Children['c'].Children.ContainsKey('d').ShouldBeEquivalentTo(true);
            trie.Root.Children['a'].Children['b'].Children['c'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['a'].Children['b'].Children['c'].Children['d'].Children.Count.ShouldBeEquivalentTo(0);
            trie.Root.Children['a'].Children['b'].Children['c'].Children['d'].EndOfWord.ShouldBeEquivalentTo(true);

            trie.Root.Children['a'].Children['b'].Children['g'].Children.ContainsKey('l').ShouldBeEquivalentTo(true);
            trie.Root.Children['a'].Children['b'].Children['g'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['a'].Children['b'].Children['g'].Children['l'].Children.Count.ShouldBeEquivalentTo(0);
            trie.Root.Children['a'].Children['b'].Children['g'].Children['l'].EndOfWord.ShouldBeEquivalentTo(true);

            trie.Root.Children['c'].Children.ContainsKey('d').ShouldBeEquivalentTo(true);
            trie.Root.Children['c'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['c'].Children['d'].Children.ContainsKey('f').ShouldBeEquivalentTo(true);
            trie.Root.Children['c'].Children['d'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['c'].Children['d'].Children['f'].Children.Count.ShouldBeEquivalentTo(0);
            trie.Root.Children['c'].Children['d'].Children['f'].EndOfWord.ShouldBeEquivalentTo(true);

            trie.Root.Children['l'].Children.ContainsKey('m').ShouldBeEquivalentTo(true);
            trie.Root.Children['l'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['l'].Children['m'].Children.ContainsKey('n').ShouldBeEquivalentTo(true);
            trie.Root.Children['l'].Children['m'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['l'].Children['m'].Children['n'].Children.Count.ShouldBeEquivalentTo(0);
            trie.Root.Children['l'].Children['m'].Children['n'].EndOfWord.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_DeleteWord_NodesDelete()
        {
            //arrange
            var trie = new MyTrie.MyTrie();
            trie.Insert("abc");
            trie.Insert("abgl");
            trie.Insert("cdf");
            trie.Insert("abcd");
            trie.Insert("lmn");

            //act
            trie.DeleteWord("abgl");

            //assert
            trie.Root.Children.ContainsKey('a').ShouldBeEquivalentTo(true);
            trie.Root.Children.ContainsKey('c').ShouldBeEquivalentTo(true);
            trie.Root.Children.ContainsKey('l').ShouldBeEquivalentTo(true);
            trie.Root.EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['a'].Children.ContainsKey('b').ShouldBeEquivalentTo(true);
            trie.Root.Children['a'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['a'].Children['b'].Children.ContainsKey('c').ShouldBeEquivalentTo(true);
            trie.Root.Children['a'].Children['b'].Children.ContainsKey('g').ShouldBeEquivalentTo(false);
            trie.Root.Children['a'].Children['b'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['a'].Children['b'].Children['c'].Children.ContainsKey('d').ShouldBeEquivalentTo(true);
            trie.Root.Children['a'].Children['b'].Children['c'].EndOfWord.ShouldBeEquivalentTo(true);

            trie.Root.Children['a'].Children['b'].Children['c'].Children['d'].Children.Count.ShouldBeEquivalentTo(0);
            trie.Root.Children['a'].Children['b'].Children['c'].Children['d'].EndOfWord.ShouldBeEquivalentTo(true);

            trie.Root.Children['c'].Children.ContainsKey('d').ShouldBeEquivalentTo(true);
            trie.Root.Children['c'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['c'].Children['d'].Children.ContainsKey('f').ShouldBeEquivalentTo(true);
            trie.Root.Children['c'].Children['d'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['c'].Children['d'].Children['f'].Children.Count.ShouldBeEquivalentTo(0);
            trie.Root.Children['c'].Children['d'].Children['f'].EndOfWord.ShouldBeEquivalentTo(true);

            trie.Root.Children['l'].Children.ContainsKey('m').ShouldBeEquivalentTo(true);
            trie.Root.Children['l'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['l'].Children['m'].Children.ContainsKey('n').ShouldBeEquivalentTo(true);
            trie.Root.Children['l'].Children['m'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['l'].Children['m'].Children['n'].Children.Count.ShouldBeEquivalentTo(0);
            trie.Root.Children['l'].Children['m'].Children['n'].EndOfWord.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_DeleteWord_Multiple()
        {
            //arrange
            var trie = new MyTrie.MyTrie();
            trie.Insert("abc");
            trie.Insert("abgl");
            trie.Insert("cdf");
            trie.Insert("abcd");
            trie.Insert("lmn");

            //act
            trie.DeleteWord("abc");
            trie.DeleteWord("abgl");
            trie.DeleteWord("abcd");

            //assert
            trie.Root.Children.ContainsKey('a').ShouldBeEquivalentTo(false);
            trie.Root.Children.ContainsKey('c').ShouldBeEquivalentTo(true);
            trie.Root.Children.ContainsKey('l').ShouldBeEquivalentTo(true);
            trie.Root.EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['c'].Children.ContainsKey('d').ShouldBeEquivalentTo(true);
            trie.Root.Children['c'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['c'].Children['d'].Children.ContainsKey('f').ShouldBeEquivalentTo(true);
            trie.Root.Children['c'].Children['d'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['c'].Children['d'].Children['f'].Children.Count.ShouldBeEquivalentTo(0);
            trie.Root.Children['c'].Children['d'].Children['f'].EndOfWord.ShouldBeEquivalentTo(true);

            trie.Root.Children['l'].Children.ContainsKey('m').ShouldBeEquivalentTo(true);
            trie.Root.Children['l'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['l'].Children['m'].Children.ContainsKey('n').ShouldBeEquivalentTo(true);
            trie.Root.Children['l'].Children['m'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['l'].Children['m'].Children['n'].Children.Count.ShouldBeEquivalentTo(0);
            trie.Root.Children['l'].Children['m'].Children['n'].EndOfWord.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_DeleteWord_NotExisted()
        {
            //arrange
            var trie = new MyTrie.MyTrie();
            trie.Insert("abc");
            trie.Insert("abgl");
            trie.Insert("cdf");
            trie.Insert("abcd");
            trie.Insert("lmn");

            //act
            trie.DeleteWord("abb");

            //assert
            trie.Root.Children.ContainsKey('a').ShouldBeEquivalentTo(true);
            trie.Root.Children.ContainsKey('c').ShouldBeEquivalentTo(true);
            trie.Root.Children.ContainsKey('l').ShouldBeEquivalentTo(true);
            trie.Root.EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['a'].Children.ContainsKey('b').ShouldBeEquivalentTo(true);
            trie.Root.Children['a'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['a'].Children['b'].Children.ContainsKey('c').ShouldBeEquivalentTo(true);
            trie.Root.Children['a'].Children['b'].Children.ContainsKey('g').ShouldBeEquivalentTo(true);
            trie.Root.Children['a'].Children['b'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['a'].Children['b'].Children['c'].Children.ContainsKey('d').ShouldBeEquivalentTo(true);
            trie.Root.Children['a'].Children['b'].Children['c'].EndOfWord.ShouldBeEquivalentTo(true);

            trie.Root.Children['a'].Children['b'].Children['c'].Children['d'].Children.Count.ShouldBeEquivalentTo(0);
            trie.Root.Children['a'].Children['b'].Children['c'].Children['d'].EndOfWord.ShouldBeEquivalentTo(true);

            trie.Root.Children['a'].Children['b'].Children['g'].Children.ContainsKey('l').ShouldBeEquivalentTo(true);
            trie.Root.Children['a'].Children['b'].Children['g'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['a'].Children['b'].Children['g'].Children['l'].Children.Count.ShouldBeEquivalentTo(0);
            trie.Root.Children['a'].Children['b'].Children['g'].Children['l'].EndOfWord.ShouldBeEquivalentTo(true);

            trie.Root.Children['c'].Children.ContainsKey('d').ShouldBeEquivalentTo(true);
            trie.Root.Children['c'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['c'].Children['d'].Children.ContainsKey('f').ShouldBeEquivalentTo(true);
            trie.Root.Children['c'].Children['d'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['c'].Children['d'].Children['f'].Children.Count.ShouldBeEquivalentTo(0);
            trie.Root.Children['c'].Children['d'].Children['f'].EndOfWord.ShouldBeEquivalentTo(true);

            trie.Root.Children['l'].Children.ContainsKey('m').ShouldBeEquivalentTo(true);
            trie.Root.Children['l'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['l'].Children['m'].Children.ContainsKey('n').ShouldBeEquivalentTo(true);
            trie.Root.Children['l'].Children['m'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['l'].Children['m'].Children['n'].Children.Count.ShouldBeEquivalentTo(0);
            trie.Root.Children['l'].Children['m'].Children['n'].EndOfWord.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_DeleteWord_Throw_If_Null()
        {
            //arrange
            var trie = new MyTrie.MyTrie();
            trie.Insert("abc");
            trie.Insert("abgl");
            trie.Insert("cdf");
            trie.Insert("abcd");
            trie.Insert("lmn");

            //act
            Action act = () => trie.DeleteWord(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();

            trie.Root.Children.ContainsKey('a').ShouldBeEquivalentTo(true);
            trie.Root.Children.ContainsKey('c').ShouldBeEquivalentTo(true);
            trie.Root.Children.ContainsKey('l').ShouldBeEquivalentTo(true);
            trie.Root.EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['a'].Children.ContainsKey('b').ShouldBeEquivalentTo(true);
            trie.Root.Children['a'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['a'].Children['b'].Children.ContainsKey('c').ShouldBeEquivalentTo(true);
            trie.Root.Children['a'].Children['b'].Children.ContainsKey('g').ShouldBeEquivalentTo(true);
            trie.Root.Children['a'].Children['b'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['a'].Children['b'].Children['c'].Children.ContainsKey('d').ShouldBeEquivalentTo(true);
            trie.Root.Children['a'].Children['b'].Children['c'].EndOfWord.ShouldBeEquivalentTo(true);

            trie.Root.Children['a'].Children['b'].Children['c'].Children['d'].Children.Count.ShouldBeEquivalentTo(0);
            trie.Root.Children['a'].Children['b'].Children['c'].Children['d'].EndOfWord.ShouldBeEquivalentTo(true);

            trie.Root.Children['a'].Children['b'].Children['g'].Children.ContainsKey('l').ShouldBeEquivalentTo(true);
            trie.Root.Children['a'].Children['b'].Children['g'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['a'].Children['b'].Children['g'].Children['l'].Children.Count.ShouldBeEquivalentTo(0);
            trie.Root.Children['a'].Children['b'].Children['g'].Children['l'].EndOfWord.ShouldBeEquivalentTo(true);

            trie.Root.Children['c'].Children.ContainsKey('d').ShouldBeEquivalentTo(true);
            trie.Root.Children['c'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['c'].Children['d'].Children.ContainsKey('f').ShouldBeEquivalentTo(true);
            trie.Root.Children['c'].Children['d'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['c'].Children['d'].Children['f'].Children.Count.ShouldBeEquivalentTo(0);
            trie.Root.Children['c'].Children['d'].Children['f'].EndOfWord.ShouldBeEquivalentTo(true);

            trie.Root.Children['l'].Children.ContainsKey('m').ShouldBeEquivalentTo(true);
            trie.Root.Children['l'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['l'].Children['m'].Children.ContainsKey('n').ShouldBeEquivalentTo(true);
            trie.Root.Children['l'].Children['m'].EndOfWord.ShouldBeEquivalentTo(false);

            trie.Root.Children['l'].Children['m'].Children['n'].Children.Count.ShouldBeEquivalentTo(0);
            trie.Root.Children['l'].Children['m'].Children['n'].EndOfWord.ShouldBeEquivalentTo(true);
        }
    }
}
