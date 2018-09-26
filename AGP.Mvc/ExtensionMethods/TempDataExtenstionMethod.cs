using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGP.Mvc.ExtensionMethods
{
    public static class TempDataExtenstionMethod
    {
        public static void AddResult(this ITempDataDictionary tempData,Utility.ServiceResult result)
        {
            tempData.Add("ServiceResult.Success",result.Success);
            tempData.Add("ServiceResult.Message", result.Message);
        }
    }
}
