using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks.ObjectOrientedDesign.OnlineBookReader
{
    public class Reader
    {
        public ICollection<Book> Books { get; private set; }

        public Reader(ICollection<Book> books)
        {
            Books = books ?? throw new ArgumentNullException();
        }

        public IEnumerable<Book> GetBooksByName(string name)
        {
            if(name == null)
                throw new ArgumentNullException();

            return Books.Where(x => x?.Name != null && x.Name.Equals(name));
        }

        public IEnumerable<Book> GetBooksByAuthor(Author author)
        {
            if (author == null)
                throw new ArgumentNullException();

            return Books.Where(x => x?.Author != null && x.Author.Equals(author));
        }

        public IEnumerable<Book> GetBooksByGenre(Genre genre)
        {
            if (genre == null)
                throw new ArgumentNullException();

            return Books.Where(x => x?.Genre != null && x.Genre.Equals(genre));
        }

        public void ReadBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException();

            Thread.Sleep(100);
            book.IsRead = true;
        }
    }
}
