using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks.MathLogic
{
    public class TestStrip
    {
        private const int DayDelay = 7;
        public static int CurrentDay;
        private readonly List<bool> _drops = new List<bool>();
        private static readonly HashSet<CheckOrder> _checkOrders = new HashSet<CheckOrder>();

        public void DropBottle(Bottle bottle)
        {
            if (bottle == null)
                throw new ArgumentNullException();
            _drops.Add(bottle.IsPoisoned);
        }

        public bool GetResults(CheckOrder order)
        {
            if (!_checkOrders.Contains(order))
            {
                _checkOrders.Add(order);
                CurrentDay += DayDelay;
            }
            return _drops.Any(x => x);
        }

        public static void Clear()
        {
            CurrentDay = 0;
            _checkOrders.Clear();
        }
    }
}