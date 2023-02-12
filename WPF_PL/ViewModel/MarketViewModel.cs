using APIParser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF_PL.ViewModel
{
    public class MarketViewModel
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public Market Market { get; set; }

        public MarketViewModel(Market marketToSet)
        {
            Market = marketToSet;
        }
        
        //Prop
        #region
        public string? Exchange_Id
        {
            get
            {
                return Market.Exchange_Id;
            }
            set
            {
                Market.Symbol = value;
                OnPropertyChanged("Exchange_Id");
            }
        }
        public string? Symbol
        {
            get
            {
                return Market.Symbol;
            }
            set
            {
                Market.Symbol = value;
                OnPropertyChanged("Symbol");
            }
        }
        public string? Base_Asset
        {
            get
            {
                return Market.Base_Asset;
            }
            set
            {
                Market.Base_Asset = value;
                OnPropertyChanged("Base_Asset");
            }
        }
        public string? Quote_Asset
        {
            get
            {
                return Market.Quote_Asset;
            }
            set
            {
                Market.Quote_Asset = value;
                OnPropertyChanged("Quote_Asset");
            }
        }
        public double Price
        {
            get
            {
                return Market.Price;
            }
            set
            {
                Market.Price = value;
                OnPropertyChanged("Price");
            }
        }
        public double Price_Unconverted
        {
            get
            {
                return Market.Price_Unconverted;
            }
            set
            {
                Market.Price_Unconverted = value;
                OnPropertyChanged("Price_Unconverted");
            }
        }
        public double Volume_24h
        {
            get
            {
                return Market.Volume_24h;
            }
            set
            {
                Market.Volume_24h = value;
                OnPropertyChanged("Volume_24h");
            }
        }
        public double Change_24h
        {
            get
            {
                return Market.Change_24h;
            }
            set
            {
                Market.Change_24h = value;
                OnPropertyChanged("Change_24h");
            }
        }
        public double Spread
        {
            get
            {
                return Market.Spread;
            }
            set
            {
                Market.Spread = value;
                OnPropertyChanged("Spread");
            }
        }
        #endregion

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
