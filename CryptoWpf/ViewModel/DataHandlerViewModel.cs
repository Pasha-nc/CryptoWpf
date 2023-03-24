using CryptoWpf.Model;
using CryptoWpf.Services;
using CryptoWpf.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CryptoWpf.ViewModel
{
    internal class DataHandlerViewModel : INotifyPropertyChanged
    {
        public TabItem SelectedTabItem { get; set; }

        #region Top10Coins
        private Coin selectedCoin;

        public Coin SelectedCoin
        {
            get { return selectedCoin; }
            set
            {
                selectedCoin = value;
                NotifyPropertyChanged(nameof(SelectedCoin));
            }
        }

        private Coin[] coins;
        public Coin[] Coins
        {
            get
            {
                return coins;
            }
            set
            {
                coins = value;
                NotifyPropertyChanged(nameof(Coins));
            }
        }
        #endregion

        #region SearchCoin
        private Coin searchSelectedCoin;

        public Coin SearchSelectedCoin
        {
            get { return searchSelectedCoin; }
            set
            {
                searchSelectedCoin = value;
                NotifyPropertyChanged(nameof(SearchSelectedCoin));
            }
        }

        private Coin[] searchCoins;
        public Coin[] SearchCoins
        {
            get
            {
                return searchCoins;
            }
            set
            {
                searchCoins = value;
                NotifyPropertyChanged(nameof(SearchCoins));
            }
        }

        private string searchFilter;
        public string SearchFilter
        {
            get
            {
                return searchFilter;
            }
            set
            {
                searchFilter = value;

                NotifyPropertyChanged(nameof(SearchFilter));
            }
        }

        private async void SearchCoin()
        {
            SearchCoins = await CoinDataLoader.SearchCoinData(SearchFilter);
        }
        #endregion

        #region CoinMarkets
        private CoinMarkets[] coinMarketsData;

        public CoinMarkets[] CoinMarketsData
        {
            get { return coinMarketsData; }
            set
            {
                coinMarketsData = value;
                NotifyPropertyChanged(nameof(CoinMarketsData));
            }
        }


        private async void SearchCoinMarketsData()
        {
            CoinMarketsData = await CoinDataLoader.LoadCoinMarkets(SearchSelectedCoin?.Id);
        }
        #endregion

        #region Init
        public DataHandlerViewModel()
        {
            LoadCoins();

            this.PropertyChanged += MyViewModel_PropertyChanged;
        }

        private async void LoadCoins()
        {
            Coins = await CoinDataLoader.LoadTop10Coins();
        }
        #endregion

        #region Commands

        private RelayCommand changeCoinCmd;
        public RelayCommand ChangeCoinCmd
        {
            get
            {
                return changeCoinCmd ?? new RelayCommand(
                    obj => { ChangeCoin(); }
                    );
            }
            set
            {

            }
        }

        private async void ChangeCoin()
        {
            Coins = await CoinDataLoader.LoadTop10Coins();
        }

        private RelayCommand searchCoinCmd;
        public RelayCommand SearchCoinCmd
        {
            get
            {
                return searchCoinCmd ?? new RelayCommand(
                    obj => { SearchCoin(); }
                    );
            }
            set
            {

            }
        }
        #endregion

        #region COMMANDS TO OPEN WINDOWS
        private RelayCommand openChartCmd;
        public RelayCommand OpenChartCmd
        {
            get
            {
                return openChartCmd ?? new RelayCommand(obj =>
                {
                    OpenChartWindowMethod();
                }
                    );
            }
        }
        private void OpenChartWindowMethod()
        {
            Chart newDepartmentWindow = new Chart(SearchSelectedCoin?.Id ?? "bitcoin");
            SetCenterPositionAndOpen(newDepartmentWindow);

        }

        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        #endregion

        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        void MyViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(SearchSelectedCoin):
                    SearchCoinMarketsData();
                    break;
            }
        }
        #endregion
    }
}
