using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.Models.Request;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("favorite")]
        public async Task<IActionResult> AddFavorite(FavoriteRequestModel favoriteRequest)
        {
            if (await _userService.AddFavorite(favoriteRequest))
            {
                return Ok();
            }
            return Unauthorized(new { message="Unauthorized to do so"});
        }
        [HttpPost]
        [Route("unfavorite")]
        public async Task<IActionResult> RemoveFavorite(FavoriteRequestModel favoriteRequest)
        {
            if (await _userService.RemoveFavorite(favoriteRequest))
            {
                return Ok();
            }
            return Unauthorized(new { message = "Unauthorized to do so" });
        }
        [HttpGet]
        [Route("{id:int}/movie/{movieId}/favorite")]
        public async Task<IActionResult> IsFavoriteExists(int id, int movieId)
        {
            var favoriteExists = await _userService.FavoriteExists(id, movieId);
            return Ok(new { isFavorited = favoriteExists });
        }
        [HttpPost]
        [Route("review")]
        public async Task<IActionResult> AddReview(ReviewRequestModel reviewRequest)
        {
            await _userService.AddMovieReview(reviewRequest);
            return Ok();
        }
        [HttpPut]
        [Route("review")]
        public async Task<IActionResult> UpdateReview(ReviewRequestModel reviewRequest)
        {
            await _userService.UpdateMovieReview(reviewRequest);
            return Ok();
        }
        [HttpDelete]
        [Route("{userId:int}/movie/{movieId:int}")]
        public async Task<IActionResult> DeleteReview(int userId, int movieId)
        {
            await _userService.DeleteMovieReview(userId, movieId);
            return Ok();
        }

    }
}
