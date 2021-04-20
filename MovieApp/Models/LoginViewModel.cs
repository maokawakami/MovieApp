using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieApp.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "ユーザー名は必須入力です")]
        [DisplayName("ユーザー名")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "パスワードは必須入力です")]
        [DisplayName("パスワード")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}