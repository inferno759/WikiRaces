using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Interfaces;
using Library.Model;
using Microsoft.EntityFrameworkCore;

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
            };
            await _context.AddAsync(newUser);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByID(int id)
        {
            var query = await _context.Users
                .Include(f => f.FriendFriendNavigations)
                .FirstAsync(x => x.Id == id);
            if(query != null)
            {
                User user = new User
                {
                    Id = query.Id,
                    Username = query.Username,
                    Password = query.Password,
                    Friends = query.FriendFriendNavigations.Select(x => x.FriendId).ToList()
                };
                return user;
            }
            else
            {
                throw new ArgumentException("Could not find user with that ID");
            }
        }

        public async Task<User> GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update a users Friends list/password/username
        /// </summary>
        /// <param name="user">User to update</param>
        /// <returns></returns>
        public async Task UpdateUser(User user)
        {
            
        }
    }
}
