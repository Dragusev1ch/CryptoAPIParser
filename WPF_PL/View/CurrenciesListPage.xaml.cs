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
    /// Interaction logic for CurrenciesListPage.xaml
    /// </summary>
    public partial class CurrenciesListPage : UserControl
    {
        public event EventHandler CurrencySelected;

        CurrencyListPageViewModel viewModel;

        public CurrenciesListPage()
        {
            viewModel = new CurrencyListPageViewModel();
            InitializeComponent();
            scrollViewer.MaxHeight = SystemParameters.WorkArea.Height;
            currenciesList.CurrencySelected += CurrenciesList_CurrencySelected;
            DataContext = viewModel;
        }

        private void CurrenciesList_CurrencySelected(object? sender, EventArgs e)
        {
            CurrencyViewModel currency = sender as CurrencyViewModel;
            CurrencySelected?.Invoke(currency, EventArgs.Empty);
        }
        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            viewModel.PerformSearch(textBoxSearch.Text);
        }

        private void buttonLoadMoreCurrencies_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.LoadMoreCurrencies() == false)
            {
                MessageBox.Show("Can't load more currencies");
            }
        }
    }
}
