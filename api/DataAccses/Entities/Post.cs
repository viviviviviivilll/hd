using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.DataAccses.Entities
{
    public class Post
    {
        public string Id { get; set; }

        [ForeignKey("Hd")]
        public string HdId { get; set; }
        public User Hd { get; set; }
      
        public string Tittle { get; set; }
        public DateTime Date { get; set; }

        public List<Like> Likes { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Photo> Photos { get; set; }
    }
}
