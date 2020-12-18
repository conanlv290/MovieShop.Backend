using MovieShop.Core.Entities;
using MovieShop.Core.Models;
using MovieShop.Core.Models.Request;
using MovieShop.Core.Models.Response;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptoService _encryptionService;
        //private readonly IAsyncRepository<Favorite> _favoriteRepo;
        //private readonly IAsyncRepository<Review> _reviewRepo;

        // constructor and dependency injection
        public UserService(IUserRepository userRepository, ICryptoService cryptoService)
        {
            _userRepository = userRepository;
            _encryptionService = cryptoService;
            //_favoriteRepo = favoriteRepo;
            //_reviewRepo = reviewRepo;
        }
        public async Task<bool> AddFavorite(FavoriteRequestModel favoriteRequest)
        {
            if (await FavoriteExists(favoriteRequest.UserId, favoriteRequest.MovieId))
            {
                //throw new Exception("You are not Authorized");
                return false;
            }
            //await _favoriteRepo.AddAsync(FavRequestToFav(favoriteRequest));
            return true;
        }
        public async Task<bool> FavoriteExists(int id, int movieId)
        {
            throw new NotImplementedException();
            //return await _favoriteRepo.GetExistsAsync(f => f.Id == id && f.MovieId == movieId);
        }
        public async Task<bool> RemoveFavorite(FavoriteRequestModel favoriteRequest)
        {
            //var dbFavorite =
            //    await _favoriteRepo.ListAsync(r => r.UserId == favoriteRequest.UserId &&
            //                                             r.MovieId == favoriteRequest.MovieId);
            //await _favoriteRepo.DeleteAsync(dbFavorite.First());
            return true;
        }
        
        public async Task AddMovieReview(ReviewRequestModel reviewRequest)
        {
            //await _reviewRepo.AddAsync(ReviewRequestToRev(reviewRequest));
        }
        public async Task UpdateMovieReview(ReviewRequestModel reviewRequest)
        {
            //await _reviewRepo.UpdateAsync(ReviewRequestToRev(reviewRequest));
        }
        public async Task DeleteMovieReview(int userId, int movieId)
        {
            //var review = await _reviewRepo.ListAsync(r => r.UserId == userId && r.MovieId == movieId);
            //await _reviewRepo.DeleteAsync(review.First());
            throw new NotImplementedException();
        }

        public async Task<UserRegisterResponseModel> CreateUser(UserRegisterRequestModel requestModel)
        {
            var dbUser = await _userRepository.GetUserByEmail(requestModel.Email);
            if (dbUser != null && string.Equals(dbUser.Email, requestModel.Email, StringComparison.CurrentCultureIgnoreCase))
                throw new Exception("Email Already Exits");
            var salt = _encryptionService.CreateSalt();
            var hashedPassword = _encryptionService.HashPassword(requestModel.Password, salt);
            var user = new User
            {
                Email = requestModel.Email,
                Salt = salt,
                HashedPassword = hashedPassword,
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName
            };
            var createdUser = await _userRepository.AddAsync(user);
            var response = new UserRegisterResponseModel
            {
                Id = createdUser.Id,
                Email = createdUser.Email,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName
            };
            return response;
        }

        public Task<FavoriteResponseModel> GetAllFavoritesForUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PurchaseResponseModel> GetAllPurchasesForUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ReviewResponseModel> GetAllReviewsByUser(int id)
        {
            throw new NotImplementedException();
            //var userReviews = await _reviewRepo.ListAllAsync(r => r.UserId == id, r => r.Movie);
        }

        public Task<PagedResultSet<User>> GetAllUsersByPagination(int pageSize = 20, int page = 0, string lastName = "")
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUser(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }

        public async Task<UserRegisterResponseModel> GetUserDetails(int id)
        {
            
            return UserToUserRegResponse(await _userRepository.GetByIdAsync(id));
        }

        public Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest)
        {
            throw new NotImplementedException();
        }

        public Task PurchaseMovie(PurchaseRequestModel purchaseRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<UserLoginResponseModel> ValidateUser(string email, string password)
        {
            // we are gonna check if the email exists in the database
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null) return null;
            var hashedPassword = _encryptionService.HashPassword(password, user.Salt);
            var isSuccess = user.HashedPassword == hashedPassword;
            var response = new UserLoginResponseModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth
            };
            //var response = _mapper.Map<UserLoginResponseModel>(user);
            //var userRoles = roles.ToList();
            //if (userRoles.Any())
            //{
            //    response.Roles = userRoles.Select(r => r.Role.Name).ToList();
            //}
            return isSuccess ? response : null;
        }

        private UserRegisterResponseModel UserToUserRegResponse(User user)
        {
            if (user == null) return null;
            var userRegiResponseModel = new UserRegisterResponseModel();
            userRegiResponseModel.Id = user.Id;
            userRegiResponseModel.Email = user.Email;
            userRegiResponseModel.FirstName = user.FirstName;
            userRegiResponseModel.LastName= user.LastName;
            return userRegiResponseModel;
        }

        private Favorite FavRequestToFav(FavoriteRequestModel favoriteRequest)
        {
            if (favoriteRequest == null) return null;
            Favorite ret = new Favorite
            {
                Id = favoriteRequest.UserId,
                MovieId = favoriteRequest.MovieId
            };
            return ret;
        }
        private Review ReviewRequestToRev(ReviewRequestModel reviewRequest)
        {
            if (reviewRequest == null) return null;
            Review ret = new Review
            {
                MovieId = reviewRequest.MovieId,
                UserId = reviewRequest.UserId,
                Rating = reviewRequest.Rating,
                ReviewText = reviewRequest.ReviewText
            };
            return ret;
        }
    }
}
