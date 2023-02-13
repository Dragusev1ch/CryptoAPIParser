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

namespace WPF_PL.View
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        const int pageIndex = 1;
        MainPage mainPage { get; set; }
        CurrencyDetailsPage currencyDetailsPage { get; set; }
        CurrenciesListPage currenciesListPage { get; set; }
        ConvertCurrenciesPage convertCurrenciesPage { get; set; }

        public MainMenu()
        {
            InitializeComponent();
            radioButtonMainPage.IsChecked = true;
        }
        private void radioButtonMainPage_Checked(object sender, RoutedEventArgs e)
        {
            if (grid.Children.Count > 1)
            {
                grid.Children.RemoveAt(pageIndex);
            }
            mainPage = new MainPage();
            mainPage.CurrencySelected += MainPage_CurrencySelected;
            Grid.SetColumn(mainPage, 1);
            grid.Children.Add(mainPage);
        }

        private void MainPage_CurrencySelected(object? sender, EventArgs e)
        {
            radioButtonMainPage.IsChecked = false;
            CurrencyViewModel currency = sender as CurrencyViewModel;
            if (grid.Children.Count > 1)
            {
                grid.Children.RemoveAt(pageIndex);
            }
            currencyDetailsPage = new CurrencyDetailsPage(currency.Currency);
            Grid.SetColumn(currencyDetailsPage, 1);
            grid.Children.Add(currencyDetailsPage);
        }

        private void radioButtonCurrenciesList_Checked(object sender, RoutedEventArgs e)
        {
            if (grid.Children.Count > 1)
            {
                grid.Children.RemoveAt(pageIndex);
            }
            currenciesListPage = new CurrenciesListPage();
            currenciesListPage.CurrencySelected += CurrenciesListPage_CurrencySelected;
            Grid.SetColumn(currenciesListPage, 1);
            grid.Children.Add(currenciesListPage);
        }

        private void CurrenciesListPage_CurrencySelected(object? sender, EventArgs e)
        {
            radioButtonCurrenciesList.IsChecked = false;
            CurrencyViewModel currency = sender as CurrencyViewModel;
            if (grid.Children.Count > 1)
            {
                grid.Children.RemoveAt(pageIndex);
            }
            currencyDetailsPage = new CurrencyDetailsPage(currency.Currency);
            Grid.SetColumn(currencyDetailsPage, 1);
            grid.Children.Add(currencyDetailsPage);
        }

        private void radioButtonCurrenciesConverter_Checked(object sender, RoutedEventArgs e)
        {
            if (grid.Children.Count > 1)
            {
                grid.Children.RemoveAt(pageIndex);
            }
            convertCurrenciesPage = new ConvertCurrenciesPage();
            Grid.SetColumn(convertCurrenciesPage, 1);
            grid.Children.Add(convertCurrenciesPage);
        }
    }
}
