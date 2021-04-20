using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieApp.Models
{
    public class Search
    {
        [DisplayName("金額")]
        [RegularExpression(@"[0-9]+")]
        public string Price { get; set; }
    }
}