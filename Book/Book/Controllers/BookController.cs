using Book.Application.DTOs.Book;
using Book.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Book.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        
        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpPost(Name = "Adicionar Livro")]
        public async Task<ActionResult> InsertBook(BookCreateDTO request)
        {
            if (_bookService == null)
                return BadRequest("Invalid Data");

            await _bookService.InsertAsync(request);

            return Ok("Livro criado com sucesso!!");
        }
    }
}
