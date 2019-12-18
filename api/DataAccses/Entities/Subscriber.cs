using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.DataAccses.Entities
{
    public class Subscriber
    {
        public User User { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }

        public User Sub { get; set; }
        [ForeignKey("Sub")]
        public string SubId { get; set; }
    }
}
