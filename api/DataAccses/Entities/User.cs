using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HD.DataAccses.Entities
{
    public class User : IdentityUser
    {
        public string PhotoPath { get; set; }
        public string Bio { get; set; }

        public List<Like> Likes { get; set; }
        public List<Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Subscriber> Subscribers { get; set; }
        public List<Subscriber> Subscribed { get; set; }
    }
}
