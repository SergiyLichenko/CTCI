namespace Tasks.ObjectOrientedDesign.DeckOfCards
{
    public class BlackJackHand : Hand
    {
        public BlackJackDeck Deck { get; private set; }
       
        public override void TakeCard()
        {
            Points += Deck.GetRandomCard().GetValue();
        }

        public BlackJackHand(BlackJackDeck deck) : base(GameType.BlackJack)
        {
            Deck = deck;
        }
    }
}