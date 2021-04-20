using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieApp.Models
{
    public class SearchView
    {
        [DisplayName("ジャンル名")]
        public string Kind { get; set; }

        [DisplayName("タイトル名")]
        public string Title { get; set; }

        public List<Movie> Movies { get; set; }
    }
}