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
    /// Interaction logic for ConvertCurrenciesPage.xaml
    /// </summary>
    public partial class ConvertCurrenciesPage : UserControl
    {
        ConvertCurrenciesPageViewModel viewModel;

        public ConvertCurrenciesPage()
        {
            viewModel = new ConvertCurrenciesPageViewModel();
            InitializeComponent();
            DataContext = viewModel;
        }
        private void textBoxFirstCurrencyAmount_KeyUp(object sender, KeyEventArgs e)
        {
            viewModel.FirstCurrencyUpdated();

        }

        private void textBoxSecondCurrencyAmount_KeyUp(object sender, KeyEventArgs e)
        {
            viewModel.SecondCurrencyUpdated();

        }
    }
}
