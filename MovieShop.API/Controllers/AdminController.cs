using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.Models;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public AdminController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpPost]
        [Route("movie")]
        public async Task<IActionResult> CreateNewMovie(MovieCreateRequest movieCreateRequest)
        {
            var res = await _movieService.CreateMovie(movieCreateRequest);
            if (res == null)
            {
                return BadRequest(new { message = "please check input" });
            }
            return Ok(res);
        }
        [HttpPut]
        [Route("movie")]
        public async Task<IActionResult> UpdateMovie(MovieCreateRequest movieCreateRequest)
        {
            var res = await _movieService.UpdateMovie(movieCreateRequest);
            if (res == null)
            {
                return BadRequest(new { message = "please check input" });
            }
            return Ok(res);
        }
        [HttpGet]
        [Route("purchases")]
        public async Task<IActionResult> GetPurchaseByMovieId(int movieId)
        {
            var purchases = await _movieService.GetAllPurchasesByMovieId(movieId);
            if (purchases == null)
            {
                return NotFound(new { message = "No Movies Found" });
            }
            return Ok(purchases);
        }

        [HttpGet]
        [Route("top")]
        public async Task<IActionResult> GetTopPurchasedMovieId()
        {
            var top = await _movieService.GetHighestGrossingMovies();
            if (top == null)
            {
                return NotFound(new { message = "No Movies Found" });
            }
            return Ok(top);
        }

    }

}
