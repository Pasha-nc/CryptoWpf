using CryptoWpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoWpf.Services
{
    internal static class CoinDataLoader
    {
        public async static Task<Coin[]> LoadTop10Coins()
        {
            var client = new HttpClientService();
            var content = await client.GetData<Assets>("https://api.coincap.io/v2/assets?limit=10");

            return content.Data;
        }

        public async static Task<Coin[]> SearchCoinData(string name)
        {
            var client = new HttpClientService();
            var content = await client.GetData<Assets>("https://api.coincap.io/v2/assets?search=" + name);

            return content.Data;
        }

        public async static Task<CoinMarkets[]> LoadCoinMarkets(string name)
        {
            var client = new HttpClientService();
            var content = await client.GetData<AssetsMarket>("https://api.coincap.io/v2/assets/" + name + "/markets");

            return content.Data;
        }

        public async static Task<CoinCandles[]> LoadCoinCandles(string name)
        {
            string key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJjbHVlIjoiNjQxZDQyZDk0OThkNzVkYTM2Mjg5NGQxIiwiaWF0IjoxNjc5NjQxOTY0LCJleHAiOjMzMTg0MTA1OTY0fQ.Eo4VRIEkXhy_tafWbvM9wRMghjRmAGz-VCMoATryz20";
            //api.coincap.io/v2/candles?exchange=poloniex&interval=h1&baseId=ethereum&quoteId=bitcoin
            var client = new HttpClientService();
            //var content = await client.GetData<CoinCandlesDTO>("https://api.coincap.io/v2/candles?exchange=poloniex&interval=h1&baseId=" + name + "&quoteId=bitcoin");
            
            var content = await client.GetData<CoinCandles[]>("https://api.taapi.io/candles?secret=" + key + "&exchange=binance&symbol=BTC/USDT&interval=1h&period=100");

            return content;
        }
    }
}
