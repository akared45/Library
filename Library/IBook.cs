using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    interface IBook
    {
        void AddBook(Book book);
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> SearchByTitle(string title);
        IEnumerable<Book> FilterByAuthor(string author);

    }
}
