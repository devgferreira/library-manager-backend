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
        public async Task<ActionResult> InsertBook(BookDTO request)
        {
            if (_bookService == null)
                return BadRequest("Invalid Data");

            await _bookService.InsertAsync(request);

            return Ok("Livro criado com sucesso!!");
        }
        [HttpDelete(Name = "Deletar Livro")]
        public async Task<ActionResult> DeleteBook(int bookId)
        {
            if (_bookService == null)
                return BadRequest("Invalid Data");

            await _bookService.DeleteAsync(bookId);

            return Ok("Livro deletado com sucesso!!");
        }
    }
}
