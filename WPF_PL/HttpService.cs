using APIParser;
using APIParser.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace WPF_PL
{
    public static class HttpService
    {
        static HttpClient httpClient;
        static HttpService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://cryptingup.com/api/");
        }
        public static List<Currency> GetCryptocurrencies(out int next, int start = 0, int size = 10)
        {
            string requestPath = string.Empty;
            if(start == 0)
            {
                requestPath = $"assets?size={size}";
            }
            else
            {
                requestPath = $"assets?start={start}&size={size}";
            }
            HttpResponseMessage responce = httpClient.GetAsync(requestPath).Result;
            string response = responce.Content.ReadAsStringAsync().Result;
            JObject jsonResponse = JObject.Parse(response);

            string nextText = jsonResponse.SelectToken("next").ToString();
            if (Int32.TryParse(nextText, out next) == false)
            {
                next = -1;
            }
            string currenciesList = jsonResponse.SelectToken("assets").ToString();
            List<Currency> currencyList = JsonConvert.DeserializeObject<List<Currency>>(currenciesList);
            return currencyList;
        }
        public static List<Market> GetExchangeMarkets(string asset_id, out int next, int start = 0, int size = 10)
        {
            string requestPath = string.Empty;
            if (start == 0)
            {
                requestPath = $"assets/{asset_id}/markets?size={size}";
            }
            else
            {
                requestPath = $"assets/{asset_id}/markets?start={start}&size={size}";
            }
            HttpResponseMessage response = httpClient.GetAsync(requestPath).Result;
            string responseBody = response.Content.ReadAsStringAsync().Result;
            JObject jsonResponse = JObject.Parse(responseBody);

            string nextText = jsonResponse.SelectToken("next").ToString();
            if (Int32.TryParse(nextText, out next) == false)
            {
                next = -1;
            }
            string marketsList = jsonResponse.SelectToken("markets").ToString();
            List<Market> markets = JsonConvert.DeserializeObject<List<Market>>(marketsList);
            return markets;
        }
        public static Currency GetCurrency(string asset_id)
        {
            string requestPath = $"assets/{asset_id}";
            HttpResponseMessage response = httpClient.GetAsync(requestPath).Result;
            if (response.IsSuccessStatusCode == false)
            {
                return null;
            }
            string responseBody = response.Content.ReadAsStringAsync().Result;
            JObject jsonResponse = JObject.Parse(responseBody);
            string asset = jsonResponse.SelectToken("asset").ToString();

            Currency currency = JsonConvert.DeserializeObject<Currency>(asset);
            return currency;
        }
        public static List<CurrencyPreview> GetCurrenciesPreview()
        {
            string requestPath = "assetsoverview";
            HttpResponseMessage response = httpClient.GetAsync(requestPath).Result;
            string responseBody = response.Content.ReadAsStringAsync().Result;
            JObject jsonResponse = JObject.Parse(responseBody);
            string assets = jsonResponse.SelectToken("assets").ToString();
            List<CurrencyPreview> currencyPreviews = JsonConvert.DeserializeObject<List<CurrencyPreview>>(assets);
            return currencyPreviews;
        }
    }
}
