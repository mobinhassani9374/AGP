using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AGP.Utility.ValidationAttributes
{
    public class EmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var emailString = (string)value;

            var reqularExpression = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

            bool isEmail = Regex.IsMatch(emailString, reqularExpression, RegexOptions.IgnoreCase);

            return isEmail;
        }
    }
}
