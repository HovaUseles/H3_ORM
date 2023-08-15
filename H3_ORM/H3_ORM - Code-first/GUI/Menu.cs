using H3_ORM___Code_first.Managers;
using H3_ORM___Code_first.Repositories;
using H3_ORM___Code_first.Models;


namespace H3_ORM___Code_first.GUI;

class Menu
{
    private BookController bookController;

    public Menu(IGenericRepository<Book> bookRepository)
    {
        this.bookController = new BookController(bookRepository);
    }

    public void Run()
    {
        string menuText =
            "Welcome to the library, \n" +
            "please choose one of the following options:\n" +
            "1. Add book\n" +
            "2. Rent out book";

        int userChoice = Input.ValidNumberSelection(menuText, 1, 2);

        switch (userChoice)
        {
            case 1:
                Book book = GetBookInformation();
                bookController.AddBook(book);
                break;

            case 2:
                // Add code for renting out boo
                break;
        }
    }

    private Book GetBookInformation()
    {
        Book book = new Book();
        Author author = new Author();

        // Author
        Console.WriteLine("== Author ==========");
        author.Name = Input.ValidText("Name: ");
        author.Age = Input.ValidNumberSelection("Age: ", 16, 123);
        author.Biography = Input.ValidText("Biography: ");
        author.Genre = Input.ValidText("Genre: ");

        // Book
        Console.WriteLine("\n\n== Book ============");
        book.Title = Input.ValidText("Book title:");
        book.Genre = Input.ValidText("Book genre:");

        // Get user input, validate
        if (DateTime.TryParse(Input.ValidText("Book release date:"), out DateTime time))
            // If broken, set it to the current time (i am lazy)
            book.ReleaseDate = time == null ? DateTime.Now : time;

        book.Author = author;

        return book;
    }
}