using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.ObjectOrientedDesign.DeckOfCards
{
   public abstract class Hand
    {
        public GameType GameType { get; private set; }
        public Hand(GameType gameType)
        {
            GameType = gameType;
        }

        public bool IsOverFlow => Points > 21;
        public int Points { get; protected set; }
        public abstract void TakeCard();
    }
}
