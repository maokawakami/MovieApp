using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MovieApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [DisplayName("Title")]
        public string Title { get; set; }

        [DisplayName("Release Date")]
        public DateTime Release { get; set; }

        [DisplayName("Genre")]
        public string Kind { get; set; }

        [DisplayName("Price")]
        public string Price { get; set; }
    }
}