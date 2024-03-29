﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.DTO;
using MovieApp.Helpers;
using MovieApp.Models;
using MovieApp.Models.Enums;

namespace MovieApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            try
            {
                if(Id <= 0)
                {
                    return BadRequest("The Id cannot be negative");
                }
                var movieFromDb = StaticDb.Movies.FirstOrDefault(movie => movie.Id == Id);
                if(movieFromDb == null)
                {
                    return NotFound($"The movie from {Id} is not found");
                }
                return Ok(movieFromDb);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!, please contact the admin");
            }
        }
        [HttpGet("GetById")]
        public IActionResult GetByIdFromQuery([FromQuery] int Id)
        {
            try
            {
                if (Id <= 0)
                {
                    return BadRequest("The Id cannot be negative");
                }
                var movieFromDb = StaticDb.Movies.FirstOrDefault(movie => movie.Id == Id);
                if (movieFromDb == null)
                {
                    return NotFound($"The movie from {Id} is not found");
                }
                return Ok(movieFromDb);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!, please contact the admin");
            }
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            try
            {
                var getAllMovies = StaticDb.Movies;
                return Ok(getAllMovies);

            }
            
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!, please contact the admin");
            }
        }

        [HttpGet("filterMovies")]
        public IActionResult FilterMovies ([FromQuery] int? genre,
                                           [FromQuery] int? year)
        {

            try
            {
                var moviesFromDb = StaticDb.Movies.AsEnumerable();

                if (genre is not null || genre < 1) 
                {
                    moviesFromDb = moviesFromDb.Where(movie => movie.Genre == (Genre)genre);
                }

                if (year is not null) 
                {
                    moviesFromDb = moviesFromDb.Where(movie => movie.Year == year);
                }

                return Ok(moviesFromDb.ToList());
            }
            catch (Exception)
            {
                //test
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!, please contact the admin");

            }


        }
        [HttpPost]
        public IActionResult CreateMovie([FromBody] AddNewMovieDto addNewMovie)
        {
            try
            {
                //if(addNewMovie.Description.Length >= 250)
                // {
                //     return BadRequest("");
                // }
                var isValidDescription = ValidationHelper.CheckLength(addNewMovie.Description);
                if (!isValidDescription)
                {
                   return BadRequest("Not Found");
                }

                var movieDb = StaticDb.Movies.FirstOrDefault(movie => movie.Id == addNewMovie.Id);
                if (movieDb == null)
                {
                    return NotFound($"Movie with {addNewMovie.Id} was not found");
                }
                var newMoviesDb = new Movie
                {
                    Id = addNewMovie.Id,
                    Title = addNewMovie.Title,
                    Year = addNewMovie.Year,
                    Genre = addNewMovie.Genre,



                };
                StaticDb.Movies.Add(newMoviesDb);
                return StatusCode(StatusCodes.Status201Created, "Movie is created!");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!, please contact the admin");

            }

        }





    }
}
