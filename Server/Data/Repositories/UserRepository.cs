using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Interfaces;
using Library.Model;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Entities.Project2Context _context;

        public UserRepository(Entities.Project2Context context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            Entities.User newUser = new Entities.User
            {
                Username = user.Username,
                Password = user.Password,
                FriendUsers = user.Friends.Select(f => new Entities.Friend
                {
                    UserId = user.Id,
                    FriendId = f.Id
                }).ToList()
            };
            await _context.AddAsync(newUser);
            await _context.SaveChangesAsync();
        }

        public Task DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
