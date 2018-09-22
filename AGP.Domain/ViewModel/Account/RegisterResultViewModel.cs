using System;
using System.Collections.Generic;
using System.Text;

namespace AGP.Domain.ViewModel.Account
{
    public class RegisterResultViewModel
    {
        public int UserId { get; set; }
        public string SerialNumber { get; set; }
        public bool IsSuccess { get; set; }
    }
}
