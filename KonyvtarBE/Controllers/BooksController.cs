using Konyvtar.Data;
using Konyvtar.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Konyvtar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryDbContext _context;


        public BooksController(LibraryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll()
        {
            var books = await _context.Books.ToListAsync();
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Book>> GetById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpGet("search/{author}")]
        public async Task<ActionResult<IEnumerable<Book>>> SearchByAuthor(string author)
        {
            var books = await _context.Books
            .Where(b => EF.Functions.Like(b.Author.ToLower(), $"%{author.ToLower()}%"))
            .ToListAsync();


            return Ok(books);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            book.CreatedAt = DateTime.UtcNow;
            _context.Books.Add(book);
            await _context.SaveChangesAsync();


            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest("ID mismatch.");
            }


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var exists = await _context.Books.AnyAsync(b => b.Id == id);
            if (!exists) return NotFound();


            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();


            return NoContent();
        }

        [HttpPatch("{id:int}/price")]
        public async Task<ActionResult<Book>> UpdatePrice(int id, [FromBody] PriceUpdateDto dto)
        {
            if (dto.Price < 0)
            {
                return BadRequest("Price cannot be negative.");
            }


            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();


            book.Price = dto.Price;
            await _context.SaveChangesAsync();


            return Ok(book);
        }


        // DELETE /api/books/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();


            _context.Books.Remove(book);
            await _context.SaveChangesAsync();


            return NoContent();
        }
    }

    public class PriceUpdateDto
    {
        public decimal Price { get; set; }
    }
}
