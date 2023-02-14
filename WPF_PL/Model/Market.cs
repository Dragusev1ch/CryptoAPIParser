using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIParser
{
    public class Market
    {
        public string? Exchange_Id { get; set; }
        public string? Symbol { get; set; }
        public string? Base_Asset { get; set; }
        public string? Quote_Asset { get; set; }
        public double Price { get; set; }
        public double Price_Unconverted { get; set; }
        public double Change_24h { get; set; }
        public double Spread { get; set; }
        public double Volume_24h { get; set; }
        public string? Status { get; set; }
        public string? Created_At { get; set; }
        public string? Updated_At { get; set; }

    }
}
