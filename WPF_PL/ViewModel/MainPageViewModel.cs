using APIParser.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_PL.ViewModel
{
    internal class MainPageViewModel
    {
        public ObservableCollection<CurrencyViewModel> Currencies { get; set; }
        public MainPageViewModel()
        {
            Currencies = new ObservableCollection<CurrencyViewModel>(HttpService.GetCryptocurrencies(out int next).Select(c => new CurrencyViewModel(c)).ToList());
        }
    }
}
