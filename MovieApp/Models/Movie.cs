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

        [Required(ErrorMessage = "タイトルを入力してください")]
        [DisplayName("タイトル")]
        public string Title { get; set; }

        [Required(ErrorMessage = "公開日を入力してください")]
        [DisplayName("公開日")]
        [DataType(DataType.Date)]
        public DateTime Release { get; set; }

        [Required(ErrorMessage = "ジャンルを選択してください")]
        [DisplayName("ジャンル")]
        public string Kind { get; set; }

        [Required(ErrorMessage = "金額を入力してください")]
        [DisplayName("金額")]
        public string Price { get; set; }
    }
}