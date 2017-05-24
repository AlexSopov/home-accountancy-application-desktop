using System;
using System.ComponentModel;

namespace HomeAccountancy.Model
{
    abstract class Transaction : DataEntity<Transaction>, INotifyPropertyChanged
    {
        private long _CategoryId;
        private long _FromAccountId;
        private double _Sum;
        private string _Description;
        private DateTime _Date;
        private double _Rest;

        public long CategoryId
        {
            get { return _CategoryId; }
            set
            {
                _CategoryId = value;
                OnPropertyChanged("Category");
            }
        }
        public long FromAccountId
        {
            get { return _FromAccountId; }
            set
            {
                _FromAccountId = value;
                OnPropertyChanged("Account");
            }
        }
        public double Sum
        {
            get { return _Sum; }
            set
            {
                Sum = value;
                OnPropertyChanged("Sum");
            }
        }
        public string Description
        {
            get { return _Description; }
            set
            {
                Description = value;
                OnPropertyChanged("Description");
            }
        }
        public DateTime Date
        {
            get { return _Date; }
            set { Date = value; OnPropertyChanged("Date"); }
        }
        public double Rest
        {
            get { return _Rest; }
            set { Rest = value; OnPropertyChanged("Rest"); }
        }

        public Category TransactionCategory
        {
            get
            {
                return Category.GetById(_CategoryId);
            }
        }
        public Account TransactionAccount
        {
            get
            {
                return Account.GetById(_FromAccountId);
            }
        }
        public Currency TransactionCurrency
        {
            get
            {
                return Currency.GetById(TransactionAccount.CurrencyId);
            }
        }

        public Transaction(long id, long categoryId, long fromAccountId, DateTime date, double sum, string description) : base(id)
        {
            _CategoryId = categoryId;
            _Description = description;
            _FromAccountId = fromAccountId;
            _Sum = sum;
            _Date = date;
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }
        public override void Save()
        {
            throw new NotImplementedException();
        }

        public abstract bool ValidateSum();

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}