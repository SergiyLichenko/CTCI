using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Tasks.ObjectOrientedDesign.OnlineBookReader;
using Xunit;

namespace Tasks.UT.ObjectOrientedDesignTests
{
    public class OnlineBookReaderTests
    {
        [Fact]
        public void OnlineBookReader_Should_Throw_Reader_If_Null()
        {
            //arrange

            //act
            Action act = () => new Reader(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void OnlineBookReader_Should_CreateBook()
        {
            //arrange
            string name = string.Empty;
            var author = new Author(string.Empty);
            var genre = new Genre(string.Empty);

            //act
            var book = new Book(name, author, genre);

            //assert
            book.Name.ShouldBeEquivalentTo(name);
            book.Author.ShouldBeEquivalentTo(author);
            book.Genre.ShouldBeEquivalentTo(genre);
        }

        [Fact]
        public void OnlineBookReader_Should_CreateAuthor()
        {
            //arrange
            var name = string.Empty;

            //act
            var author = new Author(name);

            //assert
            author.Name.ShouldBeEquivalentTo(name);
        }

        [Fact]
        public void OnlineBookReader_Should_Create_Genre()
        {
            //arrange
            var name = string.Empty;

            //act
            var genre = new Genre(name);

            //assert
            genre.Name.ShouldBeEquivalentTo(name);
        }

        [Fact]
        public void OnlineBookReader_Should_Throw_GetBooksByName_If_Null()
        {
            //arrange
            var reader = new Reader(new List<Book>());

            //act
            Action act = () => reader.GetBooksByGenre(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void OnlineBookReader_Should_Throw_GetBooksByAuthor_If_Null()
        {
            //arrange
            var reader = new Reader(new List<Book>());

            //act
            Action act = () => reader.GetBooksByAuthor(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void OnlineBookReader_Should_Throw_GetBooksByGenreIfNull()
        {
            //arrange
            var reader = new Reader(new List<Book>());

            //act
            Action act = () => reader.GetBooksByGenre(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void OnlineBookReader_Should_Throw_ReadBook_If_Null()
        {
            //arrange
            var reader = new Reader(new List<Book>());

            //act
            Action act = () => reader.ReadBook(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void OnlineBookReader_Should_ReadBook()
        {
            //arrange
            var books = new List<Book>()
            {
                new Book(String.Empty, new Author(string.Empty), new Genre(string.Empty))
            };
            var reader = new Reader(books);

            //act
            reader.ReadBook(books.First());

            //assert
            books.First().IsRead.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void OnlineBookReader_Should_GetBooksByGenre()
        {
            //arrange
            var genre = new Genre(string.Empty);
            var books = new List<Book>()
            {
                new Book(String.Empty, new Author(string.Empty), genre),
                new Book(String.Empty, new Author(string.Empty), null),
                new Book(String.Empty, new Author(string.Empty), genre)
            };
            var reader = new Reader(books);

            //act
            var result = reader.GetBooksByGenre(genre).ToList();

            //assert
            result.Count.ShouldBeEquivalentTo(books.Count - 1);
            result[0].ShouldBeEquivalentTo(books[0]);
            result[1].ShouldBeEquivalentTo(books[2]);
        }

        [Fact]
        public void OnlineBookReader_Should_GetBooksByAuthor()
        {
            //arrange
            var author = new Author(string.Empty);
            var books = new List<Book>()
            {
                new Book(String.Empty, author, null),
                new Book(String.Empty, null, null),
                new Book(String.Empty, author, null)
            };
            var reader = new Reader(books);

            //act
            var result = reader.GetBooksByAuthor(author).ToList();

            //assert
            result.Count.ShouldBeEquivalentTo(books.Count - 1);
            result[0].ShouldBeEquivalentTo(books[0]);
            result[1].ShouldBeEquivalentTo(books[2]);
        }

        [Fact]
        public void OnlineBookReader_Should_GetBooksByName()
        {
            //arrange
            var books = new List<Book>()
            {
                new Book(String.Empty, null, null),
                new Book(String.Empty, null, null),
                new Book(String.Empty, null, null)
            };
            var reader = new Reader(books);

            //act
            var result = reader.GetBooksByName(string.Empty).ToList();

            //assert
            result.Count.ShouldBeEquivalentTo(books.Count);
            result[0].ShouldBeEquivalentTo(books[0]);
            result[1].ShouldBeEquivalentTo(books[1]);
            result[2].ShouldBeEquivalentTo(books[2]);
        }
    }
}
