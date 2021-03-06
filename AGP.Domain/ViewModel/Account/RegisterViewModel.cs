﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AGP.Utility.ValidationAttributes;

namespace AGP.Domain.ViewModel.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "نام و نام خانوادگی نمی تواند فاقد مقدار باشد")]
        public string FullName { get; set; }

        [Email(ErrorMessage = "ساختار ایمیل وارد شده صحیح نمی باشد")]
        [Required(ErrorMessage = "ایمیل نمی تواند فاقد مقدار باشد")]
        public string Email { get; set; }


        [Required(ErrorMessage = "رمزعبور نمی تواند فاقد مقدار باشد")]
        [MinLength(6,ErrorMessage ="حداقل طول کاراکتر برای رمزعبور باید شش کاراکتر باشد")]
        public string Password { get; set; }


        [Required(ErrorMessage = "تکرار رمزعبور نمی تواند فاقد مقدار است")]
        [Compare(nameof(Password), ErrorMessage = "رمزعبور با تکرارش مطابقت ندارد")]
        public string ConfirmPassword { get; set; }


        public string ReturnUrl { get; set; }
    }
}
