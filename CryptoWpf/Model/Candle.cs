﻿using FancyCandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWpf.Model
{
    internal class Candle : FancyCandles.ICandle
    {
        public DateTime t { get; set; }
        public double O { get; set; }
        public double H { get; set; }
        public double L { get; set; }
        public double C { get; set; }
        public double V { get; set; }

        public Candle(DateTime t, double O, double H, double L, double C, double V)
        {
            this.t = t;
            this.O = O;
            this.H = H;
            this.L = L;
            this.C = C;
            this.V = V;
        }
    }

    internal class CandlesSource :
            System.Collections.ObjectModel.ObservableCollection<ICandle>,
            FancyCandles.ICandlesSource
    {
        public CandlesSource(FancyCandles.TimeFrame timeFrame)
        {
            this.timeFrame = timeFrame;
        }

        private readonly FancyCandles.TimeFrame timeFrame;
        public FancyCandles.TimeFrame TimeFrame { get { return timeFrame; } }
    }
}
