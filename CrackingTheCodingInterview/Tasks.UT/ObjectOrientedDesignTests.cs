using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Tasks.ObjectOrientedDesign.DeckOfCards;
using Xunit;

namespace Tasks.UT
{
    public class ObjectOrientedDesignTests
    {
        [Fact]
        public void DeckOfCards_Should_Create_Default_BlackJack_Deck()
        {
            //arrange
            int cardCount = 52;
            int suitCount = 4;

            //act
            var deck = new BlackJackDeck();

            //assert
            deck.Cards.Count.ShouldBeEquivalentTo(cardCount);
            var grouped = deck.Cards.GroupBy(x => x.Suit).ToDictionary(x => x.Key);

            grouped.Keys.ElementAt(0).ShouldBeEquivalentTo(Suit.Clubs);
            grouped.Keys.ElementAt(1).ShouldBeEquivalentTo(Suit.Diamonds);
            grouped.Keys.ElementAt(2).ShouldBeEquivalentTo(Suit.Hearts);
            grouped.Keys.ElementAt(3).ShouldBeEquivalentTo(Suit.Spades);

            foreach (var item in grouped)
            {
                var values = grouped[item.Key].Select(x => x.Rank).ToList();
                values.Count.Should().Be(cardCount / suitCount);

                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                    values.Contains(rank).ShouldBeEquivalentTo(true);
            }
            deck.Cards.All(x => x.GameType == GameType.BlackJack).ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void DeckOfCards_Should_Shuffle()
        {
            //arrange
            int cardCount = 52;
            int suitCount = 4;
            var deck = new BlackJackDeck();

            var initialOrder = deck.Cards.ToList();

            //act
            deck.ShuffleCards();

            //assert
            deck.Cards.SequenceEqual(initialOrder).ShouldBeEquivalentTo(false);

            deck.Cards.Count.ShouldBeEquivalentTo(cardCount);
            var grouped = deck.Cards.GroupBy(x => x.Suit).OrderBy(x => x.Key).ToDictionary(x => x.Key);

            grouped.Keys.ElementAt(0).ShouldBeEquivalentTo(Suit.Clubs);
            grouped.Keys.ElementAt(1).ShouldBeEquivalentTo(Suit.Diamonds);
            grouped.Keys.ElementAt(2).ShouldBeEquivalentTo(Suit.Hearts);
            grouped.Keys.ElementAt(3).ShouldBeEquivalentTo(Suit.Spades);

            foreach (var item in grouped)
            {
                var values = grouped[item.Key].Select(x => x.Rank).ToList();
                values.Count.Should().Be(cardCount / suitCount);

                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                    values.Contains(rank).ShouldBeEquivalentTo(true);
            }
            deck.Cards.All(x => x.GameType == GameType.BlackJack).ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void DeckOfCards_Should_Get_Random_Card()
        {
            //arrange
            int cardCount = 52;
            var deck = new BlackJackDeck();

            //act
            var card = deck.GetRandomCard();

            //assert
            deck.Cards.Count.ShouldBeEquivalentTo(cardCount - 1);
            deck.Cards.Contains(card).ShouldBeEquivalentTo(false);
            deck.Cards.All(x => x.GameType == GameType.BlackJack).ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void DeckOfCards_Should_Get_Random_Card_Throw_If_Empty()
        {
            //arrange
            int cardCount = 52;
            var deck = new BlackJackDeck();
            for (int i = 0; i < cardCount; i++)
                deck.GetRandomCard();

            //act
            Action act = () => deck.GetRandomCard();

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void DeckOfCards_Should_Check_Card_Values()
        {
            //arrange
            int cardsCount = 13;
            var cards = new List<Card>();
            for (int i = 0; i < cardsCount; i++)
                cards.Add(new BlackJackCard((Rank)i, Suit.Clubs, GameType.BlackJack));

            var res = Enumerable.Range(1, 10).ToList();
            foreach (var item in Enumerable.Repeat(10, 3))
                res.Add(item);
          
            //act
            var result = cards.Select(x => x.GetValue()).OrderBy(x => x).ToList();

            //assert
            result.SequenceEqual(res).ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void DeckOfCards_Should_Check_Renew()
        {
            //arrange
            int cardCount = 52;
            int suitCount = 4;
            var deck = new BlackJackDeck();

            deck.GetRandomCard();
            deck.GetRandomCard();
            //act
            deck.Renew();

            //assert
            deck.Cards.Count.ShouldBeEquivalentTo(cardCount);
            var grouped = deck.Cards.GroupBy(x => x.Suit).ToDictionary(x => x.Key);

            grouped.Keys.ElementAt(0).ShouldBeEquivalentTo(Suit.Clubs);
            grouped.Keys.ElementAt(1).ShouldBeEquivalentTo(Suit.Diamonds);
            grouped.Keys.ElementAt(2).ShouldBeEquivalentTo(Suit.Hearts);
            grouped.Keys.ElementAt(3).ShouldBeEquivalentTo(Suit.Spades);

            foreach (var item in grouped)
            {
                var values = grouped[item.Key].Select(x => x.Rank).ToList();
                values.Count.Should().Be(cardCount / suitCount);

                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                    values.Contains(rank).ShouldBeEquivalentTo(true);
            }
            deck.Cards.All(x => x.GameType == GameType.BlackJack).ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void DeckOfCards_Should_Check_Hand_Overflow()
        {
            //arrange
            int cardCount = 52;
            var deck = new BlackJackDeck();
            var hand = new BlackJackHand(deck);

            //act
            for (int i = 0; i < cardCount; i++)
                hand.TakeCard();

            //assert
            deck.Cards.Count.ShouldBeEquivalentTo(0);
            hand.Points.ShouldBeEquivalentTo(340);
            hand.IsOverFlow.ShouldBeEquivalentTo(true);
        }
    }
}
