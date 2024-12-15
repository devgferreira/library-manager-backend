using Book.Application.DTOs.Book;
using Book.Application.Interfaces;
using Book.Domain.Entities.Book.Request;
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
        public async Task<ActionResult> InsertBook([FromBody] BookDTO request)
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

        [HttpGet(Name = "Buscar Livros")]
        public async Task<ActionResult<List<BookGetDTO>>> SelectBook([FromQuery]BookRequest request)
        {
            if (_bookService == null)
                return BadRequest("Invalid Data");

            var result =  await _bookService.SelectBook(request);

            return Ok(result);
        }
        [HttpGet(Name = "Buscar Livros")]
        [Route("/{bookId}")]
        public async Task<ActionResult<List<BookGetDTO>>> UpdateBook([FromBody] BookDTO request,[FromRoute] int bookId)
        {
            if (_bookService == null)
                return BadRequest("Invalid Data");

            await _bookService.UpdateAsync(bookId, request);

            return Ok("Livro atualizado com sucesso!!");
        }
    }
}
