using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BookApplication
{
    public class BookManager
    {
        private List<Book> books;

        public BookManager()
        {
            books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void DisplayAllBooks()
        {
            if (books.Count == 0)
                Console.WriteLine("Nothig found");
            else
                books.ForEach(book => Console.WriteLine(book));
        }

        public List<Book> SearchBookByTitle(string title)
        {
            return books.FindAll(book => book.Title.Contains(title));
        }

        public List<Book> SearchBookByAuthor(string author)
        {
            return books.FindAll(book => book.Author.Contains(author));
        }

        public List<Book> SearchBookByYear(string year)
        {
            return books.FindAll(book => book.PublicationYear.ToString().StartsWith(year));
        }
    }
}
