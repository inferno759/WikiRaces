using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;

namespace Library.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByID(int id);
        Task<User> GetUserByUsername(string username);
        Task<List<User>> GetAllUsers();
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task<bool> CheckUserInfoExists(string userName, string passwordInput);
        //Task DeleteUser(User user);
    }
}
