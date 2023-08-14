using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.HomeworkClass03WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SEDC.HomeworkClass03WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        [HttpGet("GetAllBooks")] //https://localhost:7072/api/book/getallbooks
        public IActionResult GetAllBooks()
        {
            return Ok(StaticDb.Books);
        }

        [HttpGet("GetOneBook")]
        public IActionResult GetOneBook([FromQuery]int? index)
        {
            try
            {
                if(index is null)
                {
                    return BadRequest();
                }
                if (index < 0)
                {
                    return BadRequest("The index cannot be negative!");
                }
                if (index >= StaticDb.Books.Count)
                {
                    return BadRequest($"There are no resourse on {index} ");
                }
                return Ok(StaticDb.Books[index.Value]);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error accurred! Contact the admin.");
            }
        }

        [HttpGet("GetOneAuthorAndTitle")]
        public IActionResult GetOneAuthorAndTitle([FromQuery] string? author,
                                                  [FromQuery] string? title)
        {
            try
            {
                if (string.IsNullOrEmpty(author))
                {
                    return BadRequest("Author parametars are requared!");
                }
                if (string.IsNullOrEmpty(title))
                {
                    return BadRequest("Title parametars are requared!");
                }
                var bookFromDb = StaticDb.Books.Where(book => book.Author.ToLower().Contains(author.ToLower()) && book.Title==title).ToList();


                return Ok(bookFromDb);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error accurred! Contact the admin.");
            }

            
        }

        [HttpPost]
        public IActionResult AddNewBookOfList([FromBody] Book book)
        {
            try
            {
                if (string.IsNullOrEmpty(book.Author))
                {
                    return BadRequest("Every book must have great Author!");
                }
                if (string.IsNullOrEmpty(book.Title))
                {
                    return BadRequest("Book must have Title.");
                }
                StaticDb.Books.Add(book);
                return StatusCode(StatusCodes.Status201Created, "The Book are created!");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error accurred! Contact the admin.");
            }
        }

        [HttpPost("AcceptLstOfBooks")]
        public IActionResult AcceptLstOfBooks([FromBody] Book book)
        {
            try
            {
                if (string.IsNullOrEmpty(book.Title))
                {
                    return BadRequest("Book title must not be empty.");
                }
                StaticDb.Books.Add(book);
                return StatusCode(StatusCodes.Status201Created, "Book is created");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error accurred! Contact the admin.");
            }

        }
    }
}

