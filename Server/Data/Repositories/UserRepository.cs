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

        /*public async Task DeleteUser(User user)
        {
            throw new NotImplementedException();
        }*/

        public async Task<User> GetUserByID(int id)
        {
            Entities.User query;
            try
            {
                query = await _context.Users
                .Include(f => f.FriendUsers)
                .FirstAsync(x => x.Id == id);
            }
            catch
            {
                throw new ArgumentException("Could not find user with that ID");
            }
            User user = new User
            {
                Id = query.Id,
                Username = query.Username,
                Password = query.Password,
                Friends = query.FriendUsers.Select(x => x.FriendId).ToList()
            };
            return user;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            Entities.User query;
            try
            {
                query = await _context.Users
                .Include(f => f.FriendUsers)
                .FirstAsync(x => x.Username == username);
            }
            catch
            {
                throw new ArgumentException("Could not find user with that username");
            }
            User user = new User
            {
                Id = query.Id,
                Username = query.Username,
                Password = query.Password,
                Friends = query.FriendUsers.Select(x => x.FriendId).ToList()
            };
            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
            List<User> users = new List<User>();
            var query = await _context.Users
                .Include(f => f.FriendUsers)
                .ToListAsync();
            foreach(var user in query)
            {
                users.Add(new User
                {
                    Id = user.Id,
                    Username = user.Username,
                    Password = user.Password,
                    Friends = user.FriendUsers.Select(x => x.FriendId).ToList()
                });
            }
            return users;
        }
        public async Task<bool> CheckUserInfoExists(string userName, string passwordInput)
        {
            bool exists = false;
            var allUsers = await _context.Users
                .Where(u => u.Username == userName && u.Password == passwordInput).ToListAsync();

            foreach (var c in allUsers)
            {
                exists = true;
            }
            return exists;
        }

        /// <summary>
        /// Update a users Friends list/password/username
        /// </summary>
        /// <param name="user">User to update</param>
        /// <returns></returns>
        public async Task UpdateUser(User user)
        {
            var query = await _context.Users
                .Include(f => f.FriendUsers)
                .FirstAsync(x => x.Id == user.Id);
            if (query != null)
            {
                query.Username = user.Username;
                query.Password = user.Password;
                query.FriendUsers = user.Friends.Select(x => new Entities.Friend
                {
                    UserId = user.Id,
                    FriendId = x
                }).ToList();
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Couldn't find user to update");
            }
        }
    }
}
