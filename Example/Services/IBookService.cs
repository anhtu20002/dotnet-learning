
public interface IBookService
{
    IEnumerable<Book> GetAllBooks();
    Book GetBook(int id);
}

public class BookService : IBookService
{
    private static readonly List<Book> _books = new()
    {
        new Book { Id = 1, Title = "C# in Depth", Author = "Jon Skeet" },
        new Book { Id = 2, Title = "Pro ASP.NET Core", Author = "Adam Freeman" }
    };

    private readonly ILogger<IBookService> _logger;
    // constructor inject: log
    public BookService (ILogger<IBookService> logger)
    {
        _logger = logger;
    }
    public IEnumerable<Book> GetAllBooks()
    {
        // Xử lý nghiệp vụ ở đây
        _logger.LogInformation($"Bước vào bussiness xử lí");
        return _books;
    }

    public Book GetBook(int id)
    {

        return _books.FirstOrDefault(b => b.Id == id);
    }
}
