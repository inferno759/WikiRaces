using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Entities
{
    public partial class Friend
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? FriendId { get; set; }

        public virtual User FriendNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
