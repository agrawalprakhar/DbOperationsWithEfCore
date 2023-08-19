using DbOperationsWithEFCoreApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbOperationsWithEFCoreApp.Controllers
{
    [Route("api/Books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        

        public BookController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("")]
        public IActionResult GetAllBooks()
        {
            var result = _appDbContext.Books.ToList();
          

            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _appDbContext.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound($"Book with ID {id} not found.");
            }
            return Ok(book);
        }
       
        
        
      

        [HttpPost]
        public IActionResult AddBook(Books book)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //book.Id = _appDbContext.Books.Count() + 1;
            _appDbContext.Books.Add(book);
            _appDbContext.SaveChanges();
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Books updatedBook)
        {
            var existingBook = _appDbContext.Books.FirstOrDefault(b => b.Id == id);
            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Title = updatedBook.Title;
            existingBook.Author = updatedBook.Author;
            existingBook.Price = updatedBook.Price;


            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _appDbContext.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            _appDbContext.Books.Remove(book);
            _appDbContext.SaveChanges();
            return NoContent();
        }
    }
}
