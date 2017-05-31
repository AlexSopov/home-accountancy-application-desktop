using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace HomeAccountancy.Model
{
    [DataContract]
    public class Rate : DataEntity<Rate>, INotifyPropertyChanged
    {
        [DataMember]
        private Guid _CurrencyFromId;

        [DataMember]
        private Guid _CurrencyToId;

        [DataMember]
        private double _RateFromTo;

        public Guid CurrencyFromId
        {
            get { return _CurrencyFromId; }
            set
            {
                _CurrencyFromId = value;
                OnPropertyChanged("CurrencyFromId");
            }
        }
        public Guid CurrencyToId
        {
            get { return _CurrencyToId; }
            set
            {
                _CurrencyToId = value;
                OnPropertyChanged("CurrencyToId");
            }
        }
        public double RateFromTo
        {
            get { return _RateFromTo; }
            set
            {
                _RateFromTo = value;
                OnPropertyChanged("RateFromTo");
            }
        }
        public double RateToFrom
        {
            get
            {
                try
                {
                    return 1 / RateFromTo;
                }
                catch { }

                return 1;
            }
        }

        public Rate(Guid currencyFromId, Guid currencyToId, double rateFromTo) : base()
        {
            _CurrencyFromId = currencyFromId;
            _CurrencyToId = currencyToId;
            _RateFromTo = rateFromTo;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public override string ToString()
        {
            return Currency.GetById(_CurrencyFromId).ShortageName + " - " + Currency.GetById(_CurrencyToId).ShortageName;
        }
    }
}
