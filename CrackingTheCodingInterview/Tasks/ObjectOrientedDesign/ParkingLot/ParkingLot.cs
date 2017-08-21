using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.ObjectOrientedDesign.ParkingLot
{
    public class ParkingLot
    {
        private List<Floor> _floors;
        public ParkingLot(int floorsCount, int width, int height)
        {
            if(floorsCount<0 || width<0 || height<0)
                throw new ArgumentOutOfRangeException();
            _floors = new List<Floor>();
            for (int i = 0; i < floorsCount; i++)
                _floors.Add(new Floor(width, height));
        }

        public Floor GetFloor(int n)
        {
            if(n<0||n>=FloorsCount)
                throw new ArgumentOutOfRangeException();
            return _floors[n];
        }

        public int FloorsCount => _floors.Count;
        public int Count => _floors.Sum(x => x.Count);
    }
}
