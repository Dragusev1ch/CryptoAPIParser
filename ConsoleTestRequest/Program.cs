using APIParser;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

//var request = new GetRequest("https://cryptingup.com/api/exchanges");
//request.Run();

//var response = request.Response;

//var json = JObject.Parse(response);
//Console.WriteLine(json);

List<Currency> temp = HttpService.GetCryptocurrencies(out int next).ToList();
foreach (var item in temp)
{
    Console.WriteLine(item);
}


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
        if (start == 0)
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
}