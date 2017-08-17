using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movie.Models
{
    public class Film
    {
        [Key]
        public int filmID { get; set; }
        public string title { get; set; }
        public string director { get; set; }
        public string description { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime show_at { get; set; }

        public virtual ICollection<Comment> comments { get; set; }
    }
}