using H3_ORM___Database_first.Models;
using H3_ORM___Database_first.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_ORM___Database_first.Managers
{
    internal class BookController
    {
        private IGenericRepository<Book> _bookRepository { get; set; }
        private int _columnSize = 25;
        public BookController(IGenericRepository<Book> bookRepository) 
        {
            this._bookRepository = bookRepository;
        }

        public void DisplayBooks() 
        {
            Book[] books = _bookRepository.GetAll();

            foreach (Book book in books) 
            {
                int index = Array.IndexOf(books, book) + 1;
                Console.WriteLine($"{index}. {GetTruncatedSubstring(book.Title)}, {GetTruncatedSubstring(book.Genre)}, {GetTruncatedSubstring(book.ReleaseDate.ToString())}");
            }
        }

        private string GetTruncatedSubstring(string text)
        {
            if(text.Length > _columnSize) 
            {
                return text.Substring(0, _columnSize - 3) + "...";
            }
            else
            {
                return text;
            }
        }
    }
}
