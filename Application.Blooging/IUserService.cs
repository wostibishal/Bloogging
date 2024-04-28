using Domain.Bloogging.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Blooging
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
        Task<IEnumerable<User>> GetAllUser();
        Task<User> UpdateUser(User user);
        Task DeleteUser(string id);
        Task<User> GetUserById(string id);
        Task<IEnumerable<User>> GetUserByRole(string role);
    }
}
