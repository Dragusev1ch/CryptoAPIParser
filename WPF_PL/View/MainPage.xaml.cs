using APIParser.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_PL.ViewModel;

namespace WPF_PL.View
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        public event EventHandler CurrencySelected;
        MainPageViewModel mainPageViewModel { get; set; } = new MainPageViewModel();

        public MainPage()
        {
            InitializeComponent();
            DataContext = mainPageViewModel;
            currenciesList.CurrencySelected += CurrenciesList_CurrencySelected;
        }

        private void CurrenciesList_CurrencySelected(object? sender, EventArgs e)
        {
            CurrencyViewModel currency = sender as CurrencyViewModel;
            CurrencySelected?.Invoke(currency, EventArgs.Empty);
        }
    }
}
