using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.ObjectOrientedDesign.Minesweeper
{
    public class Player
    {
        public Player(string name)
        {
            Name = name ?? throw new ArgumentNullException();
        }

        public string Name { get; set; }
    }
}
