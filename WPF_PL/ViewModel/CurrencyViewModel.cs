using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace APIParser.ViewModel
{
    public class CurrencyViewModel : INotifyPropertyChanged
    {
        private Currency currency;

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public Currency Currency
        {
            get
            {
                return currency;
            }
            set
            {
                currency = value;
                OnPropertyChanged("Asset_Id");
                OnPropertyChanged("Name");
                OnPropertyChanged("Description");
                OnPropertyChanged("Price");
                OnPropertyChanged("Volume_24h");
                OnPropertyChanged("Change_1h");
                OnPropertyChanged("Change_24h");
                OnPropertyChanged("Change_7d");
                OnPropertyChanged("Total_Supply");
                OnPropertyChanged("Circulating_Supply");
                OnPropertyChanged("Max_Supply");
                OnPropertyChanged("Fully_Diluted_Market_Cap");
                OnPropertyChanged("Status");
                OnPropertyChanged("Market_Cap");

            }
        }
        //property
        #region

        public string? Asset_Id
        {
            get
            {
                return Currency.Asset_Id;
            }
            set
            {
                Currency.Asset_Id = value;
                OnPropertyChanged("Asset_Id");
            }
        }
        public string? Name
        {
            get
            {
                return Currency.Name;
            }
            set
            {
                Currency.Name = value;
                OnPropertyChanged("Name");
            }
        }
        public string? Description
        {
            get
            {
                return Currency.Description;
            }
            set
            {
                Currency.Description = value;
                OnPropertyChanged("Description");
            }
        }
        public double Price
        {
            get
            {
                return Currency.Price;
            }
            set
            {
                Currency.Price = value;
                OnPropertyChanged("Price");
            }
        }
        public double Volume_24h
        {
            get
            {
                return Currency.Volume_24h;
            }
            set
            {
                Currency.Volume_24h = value;
                OnPropertyChanged("Volume_24h");
            }
        }
        public double Change_1h
        {
            get
            {
                return Currency.Change_1h;
            }
            set
            {
                Currency.Change_1h = value;
                OnPropertyChanged("Change_1h");
            }
        }
        public double Change_24h
        {
            get
            {
                return Currency.Change_24h;
            }
            set
            {
                Currency.Change_24h = value;
                OnPropertyChanged("Change_24h");
            }
        }
        public double Change_7d
        {
            get
            {
                return Currency.Change_7d;
            }
            set
            {
                Currency.Change_7d = value;
                OnPropertyChanged("Change_7d");
            }
        }
        public double Total_Supply
        {
            get
            {
                return Currency.Total_Supply;
            }
            set
            {
                Currency.Total_Supply = value;
                OnPropertyChanged("Total_Supply");
            }
        }
        public double Circulating_Supply
        {
            get
            {
                return Currency.Circulating_Supply;
            }
            set
            {
                Currency.Circulating_Supply = value;
                OnPropertyChanged("Circulating_Supply");
            }
        }
        public double Max_Supply
        {
            get
            {
                return Currency.Max_Supply;
            }
            set
            {
                Currency.Max_Supply = value;
                OnPropertyChanged("Max_Supply");
            }
        }
        public double Fully_Diluted_Market_Cap
        {
            get
            {
                return Currency.Fully_Diluted_Market_Cap;
            }
            set
            {
                Currency.Fully_Diluted_Market_Cap = value;
                OnPropertyChanged("Fully_Diluted_Market_Cap");
            }
        }
        public string? Status
        {
            get
            {
                return Currency.Status;
            }
            set
            {
                Currency.Status = value;
                OnPropertyChanged("Status");
            }
        }
        public double Market_Cap
        {
            get
            {
                return Currency.Market_Cap;
            }
            set
            {
                Currency.Market_Cap = value;
                OnPropertyChanged("Market_Cap");
            }
        }
        #endregion

        public string? Live_Data
        {
            get
            {
                return string.Format(new System.Globalization.CultureInfo("en-US"), "The {0} price today is {1:C8} USD with a 24-hour trading volume of {2:C} USD. {0} has changed for {3:0.##}% in the last 24 hours", Name, Price, Volume_24h, Change_24h);
            }
        }
        public CurrencyViewModel(Currency currencyToSet)
        {
            Currency = currencyToSet;
        }
        public CurrencyViewModel()
        {
            Currency = new Currency();
        }
    }
}
