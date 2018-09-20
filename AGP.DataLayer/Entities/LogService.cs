using System;
using System.Collections.Generic;
using System.Text;

namespace AGP.DataLayer.Entities
{
    public class LogService
    {
        public long Id { get; set; }
        public string Method { get; set; }
        public string RelativePath { get; set; }
        public TimeSpan Elapsed { get; set; }
        public int StatusCode { get; set; }
        public long? RequestContentLength { get; set; }
        public long? ResponseContentLength { get; set; }
        public string QueryString { get; set; }
        public string RequestIp { get; set; }
    }
}
