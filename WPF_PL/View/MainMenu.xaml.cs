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

        public MainMenu()
        {
            InitializeComponent();
            radioButtonMainPage.IsChecked = true;
        }
        private void radioButtonMainPage_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void MainPage_CurrencySelected(object? sender, EventArgs e)
        {
           
        }

        private void radioButtonCurrenciesList_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void CurrenciesListPage_CurrencySelected(object? sender, EventArgs e)
        {
            
        }

        private void radioButtonCurrenciesConverter_Checked(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
