using CryptoWpf.Model;
using CryptoWpf.Services;
using FancyCandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoWpf.ViewModel
{
    internal class ChartViewModel : INotifyPropertyChanged
    {
        private string coin;
        public string Coin
        {
            get
            {
                return coin;
            }
            set
            {
                coin = value;
                NotifyPropertyChanged(nameof(Coin));
            }
        }
        public ChartViewModel(string coin)
        {           
            Coin = coin;

            CandlesInit();
        }

        private CandlesSource candles;
        public CandlesSource Candles { 
            get { return candles; }
            set 
            {
                candles = value; 
                NotifyPropertyChanged(nameof(Candles)); 
            }
        }    
        public async void CandlesInit()
        {
            FancyCandles.TimeFrame timeFrame = FancyCandles.TimeFrame.H1;
            CandlesSource myCandles = new CandlesSource(timeFrame);

            //DateTime t0 = new DateTime(2019, 6, 11, 23, 40, 0);
            //for (int i = 0; i < 250; i++)
            //{
            //    double p0 = Math.Round(Math.Sin(0.3 * i) + 0.1 * i, 3);
            //    double p1 = Math.Round(Math.Sin(0.3 * i + 1) + 0.1 * i, 3);
            //    myCandles.Add(new Candle(t0.AddMinutes(i * timeFrame.ToMinutes()),
            //                100 + p0, 101 + p0, 99 + p0, 100 + p1, i));
            //}
            
            var x = await CoinDataLoader.LoadCoinCandles(Coin);

            foreach (var item in x)
            {                
                myCandles.Add(new Candle(UnixTimeStampToDateTime.Convert(item.TimeStamp),
                    item.Open, item.High, item.Low, item.Close, item.Volume));
            }            

            Candles = myCandles;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
