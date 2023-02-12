using APIParser;
using APIParser.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_PL.ViewModel
{
    public class CurrencyDetailsViewModel : CurrencyViewModel
    {
        public CurrencyDetailsViewModel(Currency currencyToSet) : base(currencyToSet)
        {
        }
    }
}
