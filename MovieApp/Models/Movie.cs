using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [DisplayName("タイトル")]
        public string Title { get; set; }

        [DisplayName("公開日")]
        public DateTime Release { get; set; }

        [DisplayName("ジャンル")]
        public string Kind { get; set; }

        [DisplayName("金額")]
        public string Price { get; set; }
    }
}