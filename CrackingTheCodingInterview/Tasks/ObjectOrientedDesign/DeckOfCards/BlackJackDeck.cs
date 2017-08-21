using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.ObjectOrientedDesign.DeckOfCards
{
    public class BlackJackDeck : Deck
    {
        private const int DeckSize = 52;
        private const int SuitCount = 4;
        public int Count { get; private set; } = DeckSize;
        public ICollection<Card> Cards { get; set; }

        private readonly Random _random = new Random();
        public BlackJackDeck()
        {
            Renew();
        }

        public override void ShuffleCards()
        {
            Cards = Cards.OrderBy(x => _random.Next()).ToList();
        }

        public override Card GetRandomCard()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            var index = _random.Next(0, Count);
            Count--;
            var card = Cards.ElementAt(index);
            Cards.Remove(card);

            return card;
        }

        public override void Renew()
        {
            Cards = new List<Card>(DeckSize);
            for (int i = 0; i < SuitCount; i++)
            for (int j = 0; j < DeckSize / SuitCount; j++)
                Cards.Add(new BlackJackCard((Rank)j, (Suit)i, GameType.BlackJack));
        }
    }
}
