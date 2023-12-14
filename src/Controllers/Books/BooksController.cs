using Microsoft.AspNetCore.Mvc;
using Workshop_POC.Controllers.Books.Models;

namespace Workshop_POC.Controllers.Books
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            return Ok(await _bookService.GetAllBooksAsync());
        }

        // Add endpoints for POST, PUT, and DELETE
        [HttpPost]
        public async Task<ActionResult<Book>> Post([FromBody] Book book)
        {
            var newBookId = await _bookService.CreateBookAsync(book);
            if (newBookId == 0) return BadRequest();
            return CreatedAtAction(nameof(Get), new { id = newBookId }, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Book book)
        {
            if (id != book.BookId) return BadRequest("Book ID mismatch");

            var result = await _bookService.UpdateBookAsync(book);
            if (result == 0) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _bookService.DeleteBookAsync(id);
            if (result == 0) return NotFound();
            return NoContent();
        }
    }
}
