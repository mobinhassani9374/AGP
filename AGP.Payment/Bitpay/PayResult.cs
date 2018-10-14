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
        public int trans_id { get; set; } = 0;
        public static PayResult Okay(int id_get)
        {
            return new PayResult
            {
                id_get = id_get,
                IsSuccess = true,
                Message = "عملیات موفقیت آمیز بود"
            };
        }
        public static PayResult Okay(int id_get, int trans_id)
        {
            return new PayResult
            {
                id_get = id_get,
                IsSuccess = true,
                Message = "عملیات موفقیت آمیز بود",
                trans_id = trans_id
            };
        }
        public static PayResult Error(int id_get)
        {
            return new PayResult
            {
                id_get = id_get,
                IsSuccess = false,
                Message = "عملیات موفقیت آمیز نبود"
            };
        }
    }
}
