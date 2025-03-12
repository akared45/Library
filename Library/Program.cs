using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Program
    {
        public static void Main(string[] args)
        {
            IBook bookRepository = new BookRepository();
            LibraryService libraryService = new LibraryService(bookRepository);
            while (true)
            {
                Console.WriteLine("1. Add new book");
                Console.WriteLine("2. Display book list");
                Console.WriteLine("3. Search book by title");
                Console.WriteLine("4. Filter book by author");
                Console.WriteLine("5. Exit");
                Console.Write("Select function: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter author: ");
                        string author = Console.ReadLine();
                        libraryService.AddBook(new Book(id, title, author));
                        break;
                    case "2":
                        libraryService.DisplayAllBooks();
                        break;
                    case "3":
                        Console.Write("Enter the title to search: ");
                        string searchTitle = Console.ReadLine();
                        libraryService.SearchBooksByTitle(searchTitle);
                        break;
                    case "4":
                        Console.Write("Enter the author to filter: ");
                        string filterAuthor = Console.ReadLine();
                        libraryService.FilterBooksByAuthor(filterAuthor);
                        break;
                    case "5":
                        Console.Write("EXIT.... ");
                        return;

                    default:
                        Console.WriteLine("Invalid selection.");
                        break;
                }
            }
        }
    }
}
