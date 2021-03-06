﻿using HomeAccountancy.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace HomeAccountancy.ViewModels
{
    class RateViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Currency> Currencies { get; set; }

        private Currency _SelectedCurrency1;
        private Currency _SelectedCurrency2;
        private Rate _SelectedRate;
        private double _RateValue;

        public Currency SelectedCurrency1
        {
            get { return _SelectedCurrency1; }
            set
            {
                _SelectedCurrency1 = value;
                OnPropertyChanged("SelectedCurrency1");
                OnPropertyChanged("SelectedRate");
                OnPropertyChanged("RateValue");
            }
        }
        public Currency SelectedCurrency2
        {
            get { return _SelectedCurrency2; }
            set
            {
                _SelectedCurrency2 = value;
                OnPropertyChanged("SelectedCurrency2");
                OnPropertyChanged("SelectedRate");
                OnPropertyChanged("RateValue");
            }
        }
        public Rate SelectedRate
        {
            get
            {
                if (_SelectedCurrency1 == null || _SelectedCurrency2 == null)
                    return null;

                foreach (Rate rate in Rate.Entities)
                {
                    if (rate.CurrencyFromId == _SelectedCurrency1.Id && rate.CurrencyToId == _SelectedCurrency2.Id)
                        return rate;
                }

                return _SelectedRate;
            }
            set
            {
                _SelectedRate = value;
                OnPropertyChanged("SelectedRate");
            }
        }
        public double RateValue
        {
            get
            {
                if (SelectedRate != null)
                    return SelectedRate.RateFromTo;

                return 1;
            }
            set
            {
                _RateValue = value;

                if (SelectedRate == null)
                    return;

                SelectedRate.RateFromTo = value;

                foreach (Rate rate in Rate.Entities)
                {
                    if (rate.CurrencyFromId == SelectedRate.CurrencyToId && rate.CurrencyToId == SelectedRate.CurrencyFromId)
                    {
                        if (value != 0)
                            rate.RateFromTo = 1 / value;
                        else
                            rate.RateFromTo = 1;
                    }
                }

                OnPropertyChanged("RateValue");
            }
        }

        private RelayCommand _AddNewCommand;
        private RelayCommand _DeleteCommand;
        public RelayCommand AddNewCommand
        {
            get
            {
                return _AddNewCommand ??
                  (_AddNewCommand = new RelayCommand(commandAgrument =>
                  {
                      Currency currency = new Currency("Нова валюта", "");
                      SelectedCurrency1 = currency;
                      SelectedCurrency2 = currency;

                      OnPropertyChanged("SelectedRate");
                  }));
            }
        }
        public RelayCommand DeleteCommand
        {
            get
            {
                return _DeleteCommand ??
                  (_DeleteCommand = new RelayCommand(commandAgrument =>
                  {
                      Currency currency = commandAgrument as Currency;
                      currency.Delete();
                  },
                 (commandAgrument) => Currencies.Count > 0 && SelectedCurrency1 != null));
            }
        }

        public RateViewModel()
        {
            Currencies = Currency.Entities;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
