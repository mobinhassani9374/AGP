using System;
using System.Collections.Generic;
using System.Text;

namespace AGP.Utility
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public static ServiceResult Okay()
        {
            return new ServiceResult() { Success = true, Message = "عملیات با موفقیت انجام شد" };
        }
        public static ServiceResult Error()
        {
            return new ServiceResult() { Success=false, Message="در انجام عملیات خطایی صورت گرفت مجددا تلاش کنید" };
        }
        public static ServiceResult Error(string message)
        {
            return new ServiceResult() { Success = false, Message = message };
        }
    }
}
