using System;
using System.Collections.Generic;

#nullable disable

namespace Dal
{
    public partial class User
    {
        public User()
        {
            FriendFriendNavigations = new HashSet<Friend>();
            FriendUsers = new HashSet<Friend>();
            Leaderboards = new HashSet<Leaderboard>();
            Races = new HashSet<Race>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Friend> FriendFriendNavigations { get; set; }
        public virtual ICollection<Friend> FriendUsers { get; set; }
        public virtual ICollection<Leaderboard> Leaderboards { get; set; }
        public virtual ICollection<Race> Races { get; set; }
    }
}
