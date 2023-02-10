using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIParser
{
    public class Currency
    {
        public string? Asset_Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public double Volume_24h { get; set; }
        public double Change_1h { get; set; }
        public double Change_24h { get; set; }
        public double Change_7d { get; set; }
        public double Total_Supply { get; set; }
        public double Circulating_Supply { get; set; }
        public double Max_Supply { get; set; }
        public double Fully_Diluted_Market_Cap { get; set; }
        public string? Status { get; set; }
        public string? Created_At { get; set; }
        public string? Updated_At { get; set; }
        public double Market_Cap { get; set; }
    }
}
