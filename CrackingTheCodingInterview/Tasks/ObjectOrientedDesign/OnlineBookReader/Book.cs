using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.ObjectOrientedDesign.OnlineBookReader
{
   public class Book
    {
        public Book(string name, Author author, Genre genre)
        {
            Name = name;
            Author = author;
            Genre = genre;
        }

        public Genre Genre { get; private set; }
        public Author Author { get; private set; }
        public string Name { get; private set; }
        public bool IsRead { get; set; }
    }
}
