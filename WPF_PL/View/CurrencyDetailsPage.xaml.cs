using APIParser;
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
    /// Interaction logic for CurrencyDetailsPage.xaml
    /// </summary>
    public partial class CurrencyDetailsPage : UserControl
    {
        public CurrencyDetailsViewModel CurrencyDetailsViewModel { get; set; }
        public CurrencyDetailsPage(Currency currencyToSet)
        {
            InitializeComponent();
            scrollViewer.MaxHeight = SystemParameters.WorkArea.Height;
            CurrencyDetailsViewModel = new CurrencyDetailsViewModel(currencyToSet);
            DataContext = CurrencyDetailsViewModel;
        }

        private void buttonLoadMoreMarkets_Click(object sender, RoutedEventArgs e)
        {
            if (CurrencyDetailsViewModel.LoadMoreMarkets() == false)
            {
                MessageBox.Show("Can't load more markets");
            }
        }

        private void ButtonMarket_Click(object sender, RoutedEventArgs e)
        {
            MarketViewModel marketViewModel = (sender as Button).DataContext as MarketViewModel;
            CurrencyDetailsViewModel.LinkToMarket(marketViewModel);

        }
    }
}
