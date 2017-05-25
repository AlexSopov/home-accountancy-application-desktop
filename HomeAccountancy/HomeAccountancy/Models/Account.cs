using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace HomeAccountancy.Model
{
    [DataContract]
    class Account : DataEntity<Account>, INotifyPropertyChanged
    {
        [DataMember]
        public string _Name;

        [DataMember]
        public Guid _CurrencyId;

        [DataMember]
        public double _StartBalance;

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }
        public Guid CurrencyId
        {
            get { return _CurrencyId; }
            set
            {
                _CurrencyId = value;
                OnPropertyChanged("CurrencyId");
            }
        }
        public double StartBalance
        {
            get { return _StartBalance; }
            set
            {
                _StartBalance = value;
                OnPropertyChanged("StartBalance");
            }
        }

        public double Rent {
            get
            {
                return 0;
            }
        }
        public Currency Currency
        {
            get
            {
                return Currency.GetById(CurrencyId);
            }
            set
            {
                _CurrencyId = value.Id;
                OnPropertyChanged("Currency");
            }
        }

        public Account(string name, Guid currencyId, double startBalance) : base()
        {
            Name = name;
            CurrencyId = currencyId;
            StartBalance = startBalance;
        }

        public List<Transaction> Transactions
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
