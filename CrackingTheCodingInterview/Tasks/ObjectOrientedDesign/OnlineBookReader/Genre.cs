﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.ObjectOrientedDesign.OnlineBookReader
{
   public class Genre
    {
        public Genre(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
