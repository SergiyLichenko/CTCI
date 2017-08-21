using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.ObjectOrientedDesign.DeckOfCards
{
    public abstract class Deck
    {
        public  ICollection<Card> Cards { get; set; }
        public abstract void Renew();
        public abstract void ShuffleCards();
        public  abstract  Card GetRandomCard();
    }
}
