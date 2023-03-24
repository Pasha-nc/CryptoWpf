using CryptoWpf.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWpf.Model
{
    internal class Assets
    {
        public Coin[] Data { get; set; }
        public double TimeStamp { get; set; }
    }

    internal class Coin 
    {
        public string Id { get; set; }
        public string Rank { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Supply { get; set; }
        public string MaxSupply { get; set; }
        public string MarketCapUsd { get; set; }
        public string VolumeUsd24Hr { get; set; }
        public string PriceUsd { get; set; }
        public string ChangePercent24Hr { get; set; }
        public string Vwap24Hr { get; set; }
    }
}

