using Application.Blooging;
using Domain.Bloogging.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Blogging
{
    public class UserService : IUserService
       
    {
        private readonly BlooggingDBContext _dbContext;
       
        public UserService(BlooggingDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> AddUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(string id)
        {
            var user = await _dbContext.Users.FindAsync(new Guid(id));
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(string id)
        {
            return await _dbContext.Users.FindAsync(new Guid(id));
        }


        public async Task<User> UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetUserByRole(string role)
        {
            return await _dbContext.Users.ToListAsync();
        }
    }
}
    


