using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.ObjectOrientedDesign.DeckOfCards
{
    public abstract class Card
    {
        public Card(Rank rank, Suit suit, GameType gameType)
        {
            Rank = rank;
            Suit = suit;
            GameType = gameType;
        }

        public Rank Rank { get; }
        public Suit Suit { get; }
        public GameType GameType { get; }

        public abstract int GetValue();
       
    }
}
