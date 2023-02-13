using APIParser;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

//var request = new GetRequest("https://cryptingup.com/api/exchanges");
//request.Run();

//var response = request.Response;

//var json = JObject.Parse(response);
//Console.WriteLine(json);

Currency currencyToSet = new Currency();
int marketNextPageStartId = 0;
List<MarketViewModel> marketsList = HttpService.GetExchangeMarkets("BTC", out marketNextPageStartId).Select(m => new MarketViewModel(m)).ToList();
foreach (var item in marketsList)
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
}
public class MarketViewModel
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public Market Market { get; set; }

    public MarketViewModel(Market marketToSet)
    {
        Market = marketToSet;
    }

    //Prop
    #region
    public string? Exchange_Id
    {
        get
        {
            return Market.Exchange_Id;
        }
        set
        {
            Market.Symbol = value;
            OnPropertyChanged("Exchange_Id");
        }
    }
    public string? Symbol
    {
        get
        {
            return Market.Symbol;
        }
        set
        {
            Market.Symbol = value;
            OnPropertyChanged("Symbol");
        }
    }
    public string? Base_Asset
    {
        get
        {
            return Market.Base_Asset;
        }
        set
        {
            Market.Base_Asset = value;
            OnPropertyChanged("Base_Asset");
        }
    }
    public string? Quote_Asset
    {
        get
        {
            return Market.Quote_Asset;
        }
        set
        {
            Market.Quote_Asset = value;
            OnPropertyChanged("Quote_Asset");
        }
    }
    public double Price
    {
        get
        {
            return Market.Price;
        }
        set
        {
            Market.Price = value;
            OnPropertyChanged("Price");
        }
    }
    public double Price_Unconverted
    {
        get
        {
            return Market.Price_Unconverted;
        }
        set
        {
            Market.Price_Unconverted = value;
            OnPropertyChanged("Price_Unconverted");
        }
    }
    public double Volume_24h
    {
        get
        {
            return Market.Volume_24h;
        }
        set
        {
            Market.Volume_24h = value;
            OnPropertyChanged("Volume_24h");
        }
    }
    public double Change_24h
    {
        get
        {
            return Market.Change_24h;
        }
        set
        {
            Market.Change_24h = value;
            OnPropertyChanged("Change_24h");
        }
    }
    public double Spread
    {
        get
        {
            return Market.Spread;
        }
        set
        {
            Market.Spread = value;
            OnPropertyChanged("Spread");
        }
    }
    #endregion

    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}