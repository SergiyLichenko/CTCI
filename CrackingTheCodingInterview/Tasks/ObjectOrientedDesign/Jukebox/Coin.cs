using System;

namespace Tasks.ObjectOrientedDesign.Jukebox
{
    public class Coin
    {
        public Coin(int cost)
        {
            if(cost <0)
                throw new ArgumentOutOfRangeException();
            Cost = cost;
        }

        public int Cost { get; private set; }
    }
}