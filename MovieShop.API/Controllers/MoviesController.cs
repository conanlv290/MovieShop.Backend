using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    // Attribute based Routing
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movies = await _movieService.GetMovieAsync(id);
            if (movies == null)
            {
                return NotFound("no Movies Found");
            }
            return Ok(movies);
        }
        [HttpGet]
        [Route("toprated")]
        public async Task<IActionResult> GetTopRatedMovies()
        {
            var movies = await _movieService.GetTopRatedMovies();
            if (!movies.Any())
            {
                return NotFound("no Movies Found");
            }
            return Ok(movies);
        }
        //api/movies/toprevenue
        [HttpGet]
        [Route("toprevenue")]
        public async Task<IActionResult> GetTopRevenueMovies()
        {
            // call our service and call the method
            // var movies = _movieService.GetTopMovies();
            // http status code
            var movies = await _movieService.GetTopRevenueMovies();
            if (!movies.Any())
            {
                return NotFound("no Movies Found");
            }
            return Ok(movies);
        }
        [HttpGet]
        [Route("genre/{id}")]
        public async Task<IActionResult> GetMoviesByGenreId(int id)
        {
            var movies = await _movieService.GetMoviesByGenre(id);
            if (!movies.Any())
            {
                return NotFound("no Movies Found");
            }
            return Ok(movies);
        }
        [HttpGet]
        [Route("{id}/Reviews")]
        public async Task<IActionResult> GetMovieReviewsById(int id)
        {
            var reviews = await _movieService.GetReviewsForMovie(id);
            if (!reviews.Any())
            {
                return NotFound("no Movies Found");
            }
            return Ok(reviews);
        }

    }
}
