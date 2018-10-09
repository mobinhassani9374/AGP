using System;
using System.Collections.Generic;
using System.Text;

namespace AGP.Payment.Bitpay
{
    public class PayResult
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public int id_get { get; set; }
        public static PayResult Okay(int id_get)
        {
            return new PayResult
            {
                id_get = id_get,
                IsSuccess = true,
                Message = "عملیات موفقیت آمیز بود"
            };
        }
        public static PayResult Error()
        {
            return new PayResult
            {
                id_get = 0,
                IsSuccess = false,
                Message = "عملیات موفقیت آمیز نبود"
            };
        }
    }
}
