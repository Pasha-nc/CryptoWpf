﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWpf.Model
{
    internal class AssetsMarket
    {
        public CoinMarkets[] Data { get; set; }
        public double TimeStamp { get; set; }
    }

    internal class CoinMarkets
    {
        public string ExchangeId { get; set; }
        public string BaseId { get; set; }
        public string QuoteId { get; set; }
        public string BaseSymbol { get; set; }
        public string QuoteSymbol { get; set; }
        public string VolumeUsd24hr { get; set; }
        public string PriceUsd { get; set; }
        public string VolumePercent { get; set; }        
    }
}
