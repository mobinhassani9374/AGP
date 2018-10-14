using System;
using System.Collections.Generic;
using System.Text;

namespace AGP.Domain.DTO
{
    public class BitPayConfig
    {
        public string Api { get; set; }
        public string BaseAddress { get; set; }
        public string RedirectUrl { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string GatewayUrl { get; set; }
        public string CheckoutUrl { get; set; }
    }
}
