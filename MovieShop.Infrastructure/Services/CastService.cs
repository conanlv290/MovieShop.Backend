using MovieShop.Core.Entities;
using MovieShop.Core.Models.Response;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly IAsyncRepository<Cast> _castRepository;
        public CastService(IAsyncRepository<Cast> castRepository)
        {
            _castRepository = castRepository;
        }

        public async Task<CastDetailsResponseModel> GetCastDetailsWithMovies(int id)
        {
            var cast = await _castRepository.GetByIdAsync(id);
            CastDetailsResponseModel ret = new CastDetailsResponseModel
            {
                Id = cast.Id,
                Name = cast.Name,
                Gender = cast.Gender,
                TmdbUrl = cast.TmdbUrl,
                ProfilePath = cast.ProfilePath,
            };
            return ret;
        }
    }
}
