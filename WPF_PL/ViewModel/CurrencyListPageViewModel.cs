using APIParser;
using APIParser.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_PL.ViewModel
{
    public class CurrencyListPageViewModel
    {
        public ObservableCollection<CurrencyViewModel> Currencies { get; set; }
        private string SearchText { get; set; }
        private int next;

        public CurrencyListPageViewModel()
        {
            Currencies = new ObservableCollection<CurrencyViewModel>(HttpService.GetCryptocurrencies(out next).Select(c => new CurrencyViewModel(c)).ToList());
        }

        public void PerformSearch(string searchText)
        {
            SearchText = searchText;
            if (String.IsNullOrWhiteSpace(searchText))
            {
                Currencies.Clear();
                List<CurrencyViewModel> currencyViewModels = HttpService.GetCryptocurrencies(out next).Select(c => new CurrencyViewModel(c)).ToList();
                foreach (CurrencyViewModel c in currencyViewModels)
                {
                    Currencies.Add(c);
                }
                return;
            }
            Currency currency = HttpService.GetCurrency(searchText);
            Currencies.Clear();
            if (currency != null)
            {
                Currencies.Add(new CurrencyViewModel(currency));
            }
        }

        internal bool LoadMoreCurrencies()
        {
            if (String.IsNullOrWhiteSpace(SearchText) == false) //can't load more
            {
                return false;
            }
            List<Currency> currencies = HttpService.GetCryptocurrencies(out next, next);
            if (currencies.Count == 0)
            {
                return false;
            }
            foreach (Currency cur in currencies)
            {
                Currencies.Add(new CurrencyViewModel(cur));
            }

            return true;
        }
    }
}
