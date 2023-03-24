using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWpf.Model
{
    internal class CoinCandlesDTO
    {
        public CoinCandles[] Candles { get; set; }
        public long Last_update { get; set; }
    }
    internal class CoinCandles
    {
        public string TimeStampHuman { get; set; }
        public long TimeStamp { get; set; }
        public double Open { get; set; }        
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }                
        public double Volume { get; set; }
    }
}
