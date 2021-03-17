using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class User
    {
        private string _username;

        private string _password;
        public int Id { get; set; }

        public string Username 
        { 
            get { return _username; } 
            set
            {
                if(value.Length < 3)
                {
                    throw new ArgumentException("Username must be at least 3 characters long");
                }
                else if(value.Length > 25)
                {
                    throw new ArgumentException("Username cannot be longer than 25 characters");
                }
                foreach(Char c in value)
                {
                    if (!Char.IsLetterOrDigit(c))
                    {
                        throw new ArgumentException("Username can only contain letters and/or numbers");
                    }
                }
                _username = value;
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                if (value.Length < 8)
                {
                    throw new ArgumentException("Password must be at least 8 characters long");
                }
                else if (value.Length > 25)
                {
                    throw new ArgumentException("Password cannot be longer than 25 characters");
                }
                foreach (Char c in value)
                {
                    if (Char.IsWhiteSpace(c))
                    {
                        throw new ArgumentException("Password cannot contain spaces");
                    }
                }
                _password = value;
            }
        }
        public List<User> Friends { get; set; }

        public User()
        {

        }

        public User(int id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
            Friends = new List<User>();
        }

        public void AddFriend(User friend)
        {
            if (Friends.Contains(friend))
            {
                throw new ArgumentException("Friend to add already exists");
            }
            Friends.Add(friend);
        }

        public void DeleteFriend(User friend)
        {
            if (!Friends.Contains(friend))
            {
                throw new ArgumentException("Friend to delete doesn't exist");
            }
            Friends.Remove(friend);
        }
    }
}