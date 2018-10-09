using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace AGP.Payment.Bitpay
{
    public class PayService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public PayService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<PayResult> Pay(decimal price)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://bitpay.ir/");
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("api", "1b7dc-d2265-b5890-0854e-7afab405c244151ccd008db2c746"),
                new KeyValuePair<string, string>("amount",$"{price}0"),
                new KeyValuePair<string,string>("redirect","http://seratvector.ir/Payment/PayResponse"),
                new KeyValuePair<string, string>("name","صراط وکتور"),
                new KeyValuePair<string, string>("email","seratvector.ir"),
            });
            HttpResponseMessage result = client.PostAsync("payment/gateway-send", content).Result;
            if (result.IsSuccessStatusCode)
            {
                int id_get = Convert.ToInt32(await result.Content.ReadAsStringAsync());
                if (id_get > 0) return PayResult.Okay(id_get);
                else return PayResult.Error();
            }
            else
                return PayResult.Error();
        }
    }
}
