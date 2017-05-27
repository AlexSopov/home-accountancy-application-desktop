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
                OnPropertyChanged("Rent");
            }
        }

        public double Rent {
            get
            {
                double sum = _StartBalance;

                foreach (Transaction transaction in Transactions)
                    sum += transaction.Sum;

                return sum;
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
                List<Transaction> transactions = new List<Transaction>();
                foreach (Transaction transaction in Transaction.Entities)
                {
                    if (transaction.Id == Id)
                        transactions.Add(transaction);
                }

                return transactions;
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
