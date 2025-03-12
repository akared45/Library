using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class LibraryService
    {
        private readonly IBook _bookRepository;
        public LibraryService(IBook bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public void AddBook(Book book)
        {
            var existingBook = _bookRepository.GetAllBooks().FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                Console.WriteLine("Error: Book ID already exists.");
                return;
            }
            if (string.IsNullOrWhiteSpace(book.Title) || string.IsNullOrWhiteSpace(book.Author))
            {
                Console.WriteLine("Error: Title and author cannot be empty.");
                return;
            }
            _bookRepository.AddBook(book);
            Console.WriteLine("Book added successfully!");
        }
        public void DisplayAllBooks()
        {
            var books = _bookRepository.GetAllBooks();
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}");
            }
        }
        public void SearchBooksByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Error: Title cannot be empty.");
                return;
            }
            var books = _bookRepository.SearchByTitle(title);
            if (!books.Any())
            {
                Console.WriteLine("No matching books found.");
                return;
            }

            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}");
            }
        }
        public void FilterBooksByAuthor(string author)
        {
            if (string.IsNullOrWhiteSpace(author))
            {
                Console.WriteLine("Error: Author cannot be blank.");
                return;
            }

            var books = _bookRepository.FilterByAuthor(author);
            if (!books.Any())
            {
                Console.WriteLine("No matching books found.");
                return;
            }
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}");
            }
        }
    }
}
