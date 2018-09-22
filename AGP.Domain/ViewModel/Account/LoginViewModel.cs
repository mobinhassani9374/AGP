using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AGP.Utility.ValidationAttributes;

namespace AGP.Domain.ViewModel.Account
{
   public class LoginViewModel
    {
        [Email(ErrorMessage = "ساختار ایمیل وارد شده صحیح نمی باشد")]
        [Required(ErrorMessage = "ایمیل نمی تواند فاقد مقدار باشد")]
        public string Email { get; set; }

        [Required(ErrorMessage = "رمزعبور نمی تواند فاقد مقدار باشد")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
