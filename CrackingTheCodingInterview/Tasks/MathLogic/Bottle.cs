namespace Tasks.MathLogic
{
    public class Bottle
    {
        public int Number { get; private set; }
        public bool IsPoisoned { get; private set; }
        public Bottle(int number, bool isPoisoned)
        {
            Number = number;
            IsPoisoned = isPoisoned;
        }
    }
}