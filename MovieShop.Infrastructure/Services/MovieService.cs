using MovieShop.Core.Models.Response;
using MovieShop.Core.Models;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using MovieShop.Core.Entities;

namespace MovieShop.Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;
        //private readonly IAsyncRepository<MovieGenre> _movieGenreRepo;
        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
            //_movieGenreRepo = movieGenreRepo;
        }
        public async Task<MovieDetailsResponseModel> CreateMovie(MovieCreateRequest movieCreateRequest)
        {
            var movie = MovieRequestToMovie(movieCreateRequest);
            foreach (var genre in movieCreateRequest.Genres)
            {
                var movieGenre = new MovieGenre { MovieId = movieCreateRequest.Id, GenreId = genre.Id };
                //await _movieGenreRepo.AddAsync(movieGenre);
            }
            return movieToDetialResponse(await _repository.AddAsync(movie));
        }
        public async Task<MovieDetailsResponseModel> UpdateMovie(MovieCreateRequest movieCreateRequest)
        {
            var movie = MovieRequestToMovie(movieCreateRequest);
            foreach (var genre in movieCreateRequest.Genres)
            {
                var movieGenre = new MovieGenre { MovieId = movieCreateRequest.Id, GenreId = genre.Id };
                //await _movieGenreRepo.UpdateAsync(movieGenre);
            }
            return movieToDetialResponse(await _repository.UpdateAsync(movie));
        }
        public Task<PagedResultSet<MovieResponseModel>> GetAllMoviePurchasesByPagination(int pageSize = 20, int page = 0)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedList<MovieResponseModel>> GetAllPurchasesByMovieId(int movieId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MovieResponseModel>> GetHighestGrossingMovies()
        {
            throw new NotImplementedException();
        }

        public async Task<MovieDetailsResponseModel> GetMovieAsync(int id)
        {
            return movieToDetialResponse(await _repository.GetByIdAsync(id));
            // if (movie == null) throw new NotFoundException("Movie", id);
            // var favoriteCount = await _repository.GetCountAsync(f => f.MovieId == id);
            // return movie;
        }

        public async Task<IEnumerable<MovieResponseModel>> GetMoviesByGenre(int genreId)
        {
            return movieToResponseModelList(await _repository.GetMoviesByGenre(genreId));
        }

        public Task<PagedResultSet<MovieResponseModel>> GetMoviesByPagination(int pageSize = 20, int page = 0, string title = "")
        {
            throw new NotImplementedException();
        }

        public Task<int> GetMoviesCount(string title = "")
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ReviewMovieResponseModel>> GetReviewsForMovie(int id)
        {
            return movieToReviewResponseList(await _repository.GetMovieReviewById(id));
        }

        public async Task<IEnumerable<MovieResponseModel>> GetTopRatedMovies()
        {
            return movieToResponseModelList(await _repository.GetTopRatedMovies());
        }

        public async Task<IEnumerable<MovieResponseModel>> GetTopRevenueMovies()
        {
            return movieToResponseModelList(await _repository.GetHighestRevenueMovies());
        }


        private List<MovieResponseModel> movieToResponseModelList(IEnumerable<Movie> movies)
        {
            var movieResponseModel = new List<MovieResponseModel>();
            foreach (var movie in movies)
            {
                movieResponseModel.Add(new MovieResponseModel
                {
                    Id = movie.Id,
                    PosterUrl = movie.PosterUrl,
                    ReleaseDate = movie.ReleaseDate.Value,
                    Title = movie.Title,
                    Overview = movie.Overview,
                    Budget = movie.Budget,
                    Tagline = movie.Tagline,
                    Revenue = movie.Revenue,
                });
            }
            return movieResponseModel;
        }
        private List<ReviewMovieResponseModel> movieToReviewResponseList(IEnumerable<Review> reviews)
        {
            var reviewResponseModel = new List<ReviewMovieResponseModel>();
            foreach (var review in reviews)
            {
                reviewResponseModel.Add(new ReviewMovieResponseModel
                {
                    MovieId = review.MovieId,
                    UserId = review.UserId,
                    Rating = review.Rating,
                    ReviewText = review.ReviewText
                });
            }
            return reviewResponseModel;
        }
        private MovieDetailsResponseModel movieToDetialResponse(Movie movie)
        {
            var movieResponseModel = new MovieDetailsResponseModel
            {
                Id = movie.Id,
                PosterUrl = movie.PosterUrl,
                ReleaseDate = movie.ReleaseDate.Value,
                Title = movie.Title,
                Overview = movie.Overview,
                Budget = movie.Budget,
                Tagline = movie.Tagline,
                Revenue = movie.Revenue,
            };
            return movieResponseModel;
        }
        private Movie MovieRequestToMovie(MovieCreateRequest movieCreateRequest)
        {
            var movie = new Movie
            {
                Title = movieCreateRequest.Title,
                Overview = movieCreateRequest.Overview,
                Tagline = movieCreateRequest.Tagline,
                Revenue = movieCreateRequest.Revenue,
                Budget = movieCreateRequest.Budget,
                ImdbUrl = movieCreateRequest.ImdbUrl,
                TmdbUrl = movieCreateRequest.TmdbUrl,
                PosterUrl = movieCreateRequest.PosterUrl,
                BackdropUrl = movieCreateRequest.BackDropUrl,
                OriginalLanguage = movieCreateRequest.OriginalLanguage,
                ReleaseDate = movieCreateRequest.RealaseDate,
                RunTime = movieCreateRequest.RunTime,
                Price = movieCreateRequest.price,
            };
            return movie;
        }
    }
}
