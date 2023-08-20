using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookDbContext _dbContext;

        public BooksController(BookDbContext bookDbContext) 
        {
            _dbContext = bookDbContext;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks() 
        {
            return _dbContext.Books;
        }

        [HttpGet("{bookId:int}")]
        public async Task<ActionResult<Book>> GetById(int bookId)
        {
            var book = await _dbContext.Books.FindAsync(bookId);
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Book book)
        {
            await _dbContext.AddAsync(book);
            await _dbContext.SaveChangesAsync();
            return Ok();
            
        }
        [HttpPut]
        public async Task<ActionResult> Update(int bookId, Book book)
        {
            _dbContext.Books.Update(book);
            await _dbContext.SaveChangesAsync();
            return Ok();    
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int bookId)
        {
            var book = await _dbContext.Books.FindAsync(bookId);
            _dbContext.Books.Remove(book);
            return Ok();
        }

    }
}
