using System;
using System.Collections.Generic;
using System.Text;

namespace AGP.Domain.ViewModel.LogService
{
    public class LogServiceViewModel
    {
        public string Method { get; set; }
        public string RelativePath { get; set; }
        public TimeSpan Elapsed { get; set; }
        public int StatusCode { get; set; }
        public long? RequestContentLength { get; set; }
        public long? ResponseContentLength { get; set; }
        public string QueryString { get; set; }
        public string RequestIp { get; set; }
        public int? UserId { get; set; }
    }
}
