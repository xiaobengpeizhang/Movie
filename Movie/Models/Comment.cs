using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movie.Models
{
    public class Comment
    {
        [Key]
        public int commentID { get; set; }

        public int userID { get; set; }
        public virtual User user { get; set; }

        public int filmID { get; set; }
        public virtual Film film { get; set; }

        public string commentTitle { get; set; }
        public string commentBody { get; set; }
        public DateTime create_at { get; set; }
    }
}