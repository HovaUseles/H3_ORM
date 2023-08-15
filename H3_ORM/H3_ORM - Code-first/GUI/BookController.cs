using H3_ORM___Code_first.Models;
using H3_ORM___Code_first.Repositories;

namespace H3_ORM___Code_first.Managers;

internal class BookController
{
    private IGenericRepository<Book> bookRepository { get; set; }
    private int columnSize { get; set; }

    public BookController(IGenericRepository<Book> bookRepository, int maxDisplayColumnSize = 25)
    {
        this.bookRepository = bookRepository;
        this.columnSize = maxDisplayColumnSize;
    }

    public void RemoveBook(int id)
    {
        Book book = null!;

        // Check if book exists
        try
        {
            book = bookRepository.GetById(id);
            bookRepository.Delete(book);
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine($"Cant find book with id {id}");
        }

        // Successs!
        Console.WriteLine(
            $"Book {id}, \"{book.Title}\" " +
            $"by {book.Author.Name} " +
            "has been deleted."
        );
    }

    public void AddBook(Book book)
    {
        bookRepository.Add(book);
        Console.WriteLine($"Added book {book.Title}");
    }

    public void RentOutBook(int bookId, Patron patron)
    {
        Book book = null!;

        // Does the book exist?
        try
        {
            book = bookRepository.GetById(bookId);
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine($"Book with id {bookId} could not be found.");
        }

        // Update book with patron
        book.Patron = patron;
        bookRepository.Update(book);

        // Success!
        Console.WriteLine($"Book {book.Title} has been rented out to {patron.Name}");
    }

}