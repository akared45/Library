using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class BookRepository : IBook
    {
        private List<Book> listBooks = new List<Book>();
        public void AddBook(Book book)
        {
            listBooks.Add(book);
        }
        public IEnumerable<Book> GetAllBooks()
        {
            return listBooks;
        }
        public IEnumerable<Book> SearchByTitle(string title)
        {
            return listBooks.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
        }
        public IEnumerable<Book> FilterByAuthor(string author)
        {
            return listBooks.Where(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase));
        }
    }
}
