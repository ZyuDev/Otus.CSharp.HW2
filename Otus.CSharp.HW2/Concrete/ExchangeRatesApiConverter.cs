using Microsoft.Extensions.Caching.Memory;
using Otus.CSharp.HW2.Abstract;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Otus.CSharp.HW2.Concrete
{
    public class ExchangeRatesApiConverter : ICurrencyConverter
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;
        private readonly string _key;

        public ExchangeRatesApiConverter(HttpClient httpClient, IMemoryCache memoryCache, string key)
        {
            _httpClient = httpClient;
            _memoryCache = memoryCache;
            _key = key;

        }
        public async Task<ICurrencyAmount> ConvertCurrencyAsync(ICurrencyAmount amountInfo, string currencyCode)
        {
            var ratesInfo = await _memoryCache.GetOrCreateAsync<RatesInfo>("rates_info", entry => GetRatesAsync());

            if (ratesInfo.Rates.TryGetValue(currencyCode, out var rate))
            {
                return ToNewCurrency(amountInfo, currencyCode, rate);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(currencyCode), $"Cannot get rate for currency {currencyCode}");
            }

        }

        public async Task<RatesInfo> GetRatesAsync()
        {
            var url = $"http://api.exchangeratesapi.io/v1/latest?access_key={_key}";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Cannot get rates. Status: {response.StatusCode}");
            }

            var contentStr = await response.Content.ReadAsStringAsync();

            var ratesInfo = RatesInfo.FromJson(contentStr);

            return ratesInfo;
        }

        public ICurrencyAmount ConvertCurrency(ICurrencyAmount amount, string currencyCode)
        {
            return ConvertCurrencyAsync(amount, currencyCode).Result;
        }

        public static ICurrencyAmount ToNewCurrency(ICurrencyAmount amountInfo, string currencyCode, double rate)
        {
            var newAmount = amountInfo.Amount * (decimal)rate;
            var convertedAmountInfo = new CurrencyAmount(currencyCode, newAmount);

            return convertedAmountInfo;
        }


    }
}
