using APIParser.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace WPF_PL.View
{
    /// <summary>
    /// Interaction logic for CurrenciesList.xaml
    /// </summary>
    public partial class CurrenciesList : UserControl
    {
        public event EventHandler CurrencySelected;

        public static readonly DependencyProperty CurrenciesProperty = DependencyProperty.Register("Currencies", typeof(ObservableCollection<CurrencyViewModel>), typeof(CurrenciesList));
        public ObservableCollection<CurrencyViewModel> Currencies
        {
            get
            {
                return (ObservableCollection<CurrencyViewModel>)GetValue(CurrenciesProperty);
            }
            set
            {
                SetValue(CurrenciesProperty, value);
            }
        }
        public CurrenciesList()
        {
            InitializeComponent();
        }

        private void ButtonCurrency_Click(object sender, RoutedEventArgs e)
        {
            CurrencyViewModel currency = (sender as Button).DataContext as CurrencyViewModel;
            CurrencySelected?.Invoke(currency, EventArgs.Empty);
        }
    }
}
