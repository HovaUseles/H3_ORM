using H3_ORM___Database_first.GUI.Utilities;
using H3_ORM___Database_first.Models;
using H3_ORM___Database_first.Repositories;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace H3_ORM___Database_first.Managers
{
    internal class BookController
    {
        private IGenericRepository<Patron> _patronRepository;
        private IGenericRepository<Book> _bookRepository { get; set; }

        private ConsoleHelper _consoleHelper { get; set; }
        public BookController(
            IGenericRepository<Book> bookRepository,
            IGenericRepository<Patron> patronRepository
            ) 
        {
            this._bookRepository = bookRepository;
            this._patronRepository = patronRepository;
            _consoleHelper = new ConsoleHelper();
        }

        public void StartMenu()
        {
            bool looper = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Choose an option");
                Console.WriteLine();

                Console.WriteLine("1. Display Books");
                Console.WriteLine("2. Display Patrons");
                Console.WriteLine("3. Rent a book to a patron");
                Console.WriteLine("4. Quit");
                Console.WriteLine();
                int choice = Input.ValidNumberSelection("", 0, 3) - 1;
                switch (choice)
                {
                    case 0:
                        Console.Clear();
                        DisplayBooks();
                        break;
                    case 1:
                        Console.Clear();
                        DisplayPatrons();
                        break;
                    case 2:
                        Console.Clear();
                        RentOutBook();
                        break;
                    case 3:
                        looper = false;
                        break;
                }

                Console.ReadKey();
            } while (looper);
        }

        public Book[] DisplayBooks() 
        {
            Book[] books = _bookRepository.GetAll(); // Access Data layer
            Console.WriteLine();
            string[] tableHeaders = new string[]
            {
                "",
                "Book type",
                nameof(Book.Title),
                nameof(Book.Genre),
                nameof(Book.Author),
                nameof(Book.ReleaseDate)
            };
            _consoleHelper.WriteAsTableHeaders(tableHeaders);

            foreach (Book book in books) 
            {
                int index = Array.IndexOf(books, book) + 1;
                string[] bookCellValues = new string[]
                {
                    index + ".",
                    book.Ebook != null ? "EBook" : "Physical Book",
                    book.Title,
                    book.Genre,
                    book.Author.Person.Name,
                    ((DateTime)book.ReleaseDate).ToString("dd-MM-yyyy")
                };
                _consoleHelper.WriteAsTableCell(bookCellValues);
                Console.Write("\n");
            }
            return books;
        }

        public Patron[] DisplayPatrons()
        {
            Patron[] patrons = _patronRepository.GetAll(); // Access Data layer
            Console.WriteLine();
            string[] tableHeaders = new string[]
            {
                "",
                nameof(Patron.Person.Name),
                nameof(Patron.PhoneNumber),
                "Rented Books"
            };
            _consoleHelper.WriteAsTableHeaders(tableHeaders);

            foreach (Patron patron in patrons)
            {
                int index = Array.IndexOf(patrons, patron) + 1;
                string[] patronCellValues = new string[]
                {
                    index + ".",
                    patron.Person.Name,
                    patron.PhoneNumber.ToString(),
                    string.Join(", ", patron.Books.ToList().ConvertAll<string>(book => book.Title))
                };
                _consoleHelper.WriteAsTableCell(patronCellValues);
                Console.Write("\n");
            }
            return patrons;
        }

        public void RentOutBook()
        {
            // Propmt for Patron choice
            Console.Clear();
            Patron[] patrons = DisplayPatrons();
            Console.WriteLine();

            int inputPatron = Input.ValidNumberSelection("Choose a Patron", 0, patrons.Length - 1, 100)-1;
            Patron chosenPatron = patrons[inputPatron];

            // Prompt for books choice
            Console.Clear();
            Book[] books = DisplayBooks();

            Console.WriteLine();
            
            int inputBook = Input.ValidNumberSelection("Choose a book", 0, books.Length-1, 100)-1;
            Book chosenBook = books[inputBook];

            chosenPatron.Books.Add(chosenBook);

            _patronRepository.Update(chosenPatron);
            Console.WriteLine();
            Console.WriteLine("Book rented.");
        }
    }
}
