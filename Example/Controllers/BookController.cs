using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/Book")]
[ServiceFilter(typeof(MyAuthFilter))]
[ServiceFilter(typeof(MyResourceFilter))]
[ServiceFilter(typeof(MyActionFilter))]
[ServiceFilter(typeof(MyExceptionFilter))]
[ServiceFilter(typeof(MyResultFilter))]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly ILogger<BooksController> _logger;

    public BooksController(IBookService bookService, ILogger<BooksController> logger)
    {
        _bookService = bookService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetBooks()
    {
        // Gọi business layer
        _logger.LogInformation($"Đi vào controller");
        var books = _bookService.GetAllBooks();
        return Ok(new
        {
            data = books,
            msg = "Lấy danh sách sách thành công"
        }); // trả về client
    }

    [HttpGet("{id}")]
    public IActionResult GetBook(int id)
    {
        // Gọi business layer
        _logger.LogInformation($"Đi vào controller");
        var book = _bookService.GetBook(id);
        return Ok(new { book, msg = "đã qua controller" }); // trả về client
    }
}
