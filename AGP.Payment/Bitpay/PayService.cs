﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using AGP.Domain.DTO;

namespace AGP.Payment.Bitpay
{
    public class PayService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly BitPayConfig _bitPayConfig;
        public PayService(IHttpClientFactory httpClientFactory, IOptions<BitPayConfig> options)
        {
            _httpClientFactory = httpClientFactory;
            _bitPayConfig = options.Value;
        }
        public async Task<PayResult> Pay(decimal price)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_bitPayConfig.BaseAddress);
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("api", _bitPayConfig.Api),
                new KeyValuePair<string, string>("amount",$"{price}0"),
                new KeyValuePair<string,string>("redirect",_bitPayConfig.RedirectUrl),
                new KeyValuePair<string, string>("name",_bitPayConfig.DisplayName),
                new KeyValuePair<string, string>("email",_bitPayConfig.Email),
            });
            HttpResponseMessage result = client.PostAsync(_bitPayConfig.GatewayUrl, content).Result;
            if (result.IsSuccessStatusCode)
            {
                int id_get = Convert.ToInt32(await result.Content.ReadAsStringAsync());
                if (id_get > 0) return PayResult.Okay(id_get);
                else return PayResult.Error(id_get);
            }
            else
                return PayResult.Error(0);
        }

        public PayResult Checkout()
        {
            return PayResult.Okay(12654);
        }
    }
}
