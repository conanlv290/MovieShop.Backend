﻿using MovieShop.Core.Entities;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Infrastructure.Repository
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<User> GetUserByEmail(string email)
        {
            //throw new NotImplementedException();
            var entity = await _dbContext.Set<User>().FindAsync(email);
            return entity;
        }
    }
}