namespace Tasks.ObjectOrientedDesign.DeckOfCards
{
    public class BlackJackCard : Card
    {
        public override int GetValue()
        {
            switch (GameType)
            {
                case GameType.BlackJack:
                    var value = (int)Rank + 1;
                    if (value >= 11 && value <= 13)
                        return 10;
                    return value;
            }
            return -1;
        }

        public BlackJackCard(Rank rank, Suit suit, GameType gameType) : base(rank, suit, gameType)
        {
        }
    }
}