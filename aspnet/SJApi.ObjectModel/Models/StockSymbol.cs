using System;

namespace SJApi.ObjectModel.Models
{
    public class Stock
    {
        public string Symbol { get; set; }
        public string exchange { get; set; }
        public string ExchangeSuffix { get; set; }
        public string Name { get; set; }
        public string ExchangeName { get; set; }
        public string Currency { get; set; }
        public DateTime date { get; set; }
        public string type { get; set; }        
        public string iexId { get; set; }
        public string region { get; set; }        
        public bool isEnabled { get; set; }
        public string figi { get; set; }
        public string cik { get; set; }
        public string lei { get; set; }
    }
}