using APIParser;
using APIParser.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_PL.ViewModel
{
    public class CurrencyDetailsViewModel : CurrencyViewModel
    {
        int marketNextPageStartId = 0;
        public ObservableCollection<MarketViewModel> MarketViewModels { get; set; }
        public CurrencyDetailsViewModel(Currency currencyToSet) : base(currencyToSet)
        {
            List<MarketViewModel> marketsList = HttpService.GetExchangeMarkets(currencyToSet.Asset_Id, out marketNextPageStartId).Select(m => new MarketViewModel(m)).ToList();
            MarketViewModels = new ObservableCollection<MarketViewModel>(marketsList);
        }
        internal bool LoadMoreMarkets()
        {
            List<MarketViewModel> moreMarkets = HttpService.GetExchangeMarkets(Asset_Id, out marketNextPageStartId, marketNextPageStartId).Select(m => new MarketViewModel(m)).ToList();
            if(moreMarkets.Any() == false)
            {
                return false;
            }
            foreach(MarketViewModel market in moreMarkets)
            {
                MarketViewModels.Add(market);
            }
            return true;
        }

        public void LinkToMarket(MarketViewModel? marketViewModel)
        {
            string url = String.Empty;
            switch (marketViewModel.Exchange_Id)
            {
                case "BINANCE":
                    url = $"https://www.binance.com/en/trade/";
                    break;
                case "KRAKEN":
                    url = $"https://www.kraken.com/";
                    break;
                case "COINBASE":
                    url = $"https://www.coinbase.com/";
                    break;
                case "HUOBIGLOBAL":
                    url = $"https://www.huobi.com/en-us/";
                    break;
                case "BITFINEX":
                    url = $"https://trading.bitfinex.com/t/";
                    break;
                case "POLONIEX":
                    url = $"https://poloniex.com/spot/";
                    break;
            }
            if(url == String.Empty) { return; }
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
        }
    }
}
