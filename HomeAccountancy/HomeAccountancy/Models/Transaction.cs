using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace HomeAccountancy.Model
{
    [DataContract]
    [KnownType(typeof(IncomeTransaction))]
    [KnownType(typeof(OutgoTransaction))]
    [KnownType(typeof(TransferTransaction))]
    abstract class Transaction : DataEntity<Transaction>, INotifyPropertyChanged
    {
        [DataMember]
        private Guid _CategoryId;

        [DataMember]
        private Guid _FromAccountId;

        [DataMember]
        private double _Sum;

        [DataMember]
        private string _Description;

        [DataMember]
        private DateTime _Date;

        private double _Rest;

        public Guid CategoryId
        {
            get { return _CategoryId; }
            set
            {
                _CategoryId = value;
                OnPropertyChanged("Category");
            }
        }
        public Guid FromAccountId
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
                _Sum = value;
                OnPropertyChanged("Sum");
            }
        }
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
                OnPropertyChanged("Description");
            }
        }
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; OnPropertyChanged("Date"); }
        }
        public double Rest
        {
            get { return _Rest; }
            set { _Rest = value; OnPropertyChanged("Rest"); }
        }

        Category _TransactionCategory;
        Account _TransactionAccount;
        Currency _TransactionCurrency;
        public Category TransactionCategory
        {
            get
            {
                if (_TransactionCategory == null)
                    _TransactionCategory = Category.GetById(_CategoryId);

                return _TransactionCategory;
            }
            set
            {
                _TransactionCategory = value;
                _CategoryId = _TransactionCategory.Id;
                OnPropertyChanged("TransactionCategory");
            }
        }
        public Account TransactionAccount
        {
            get
            {
                if (_TransactionAccount == null)
                    _TransactionAccount = Account.GetById(_FromAccountId);

                return _TransactionAccount;
            }
            set
            {
                _TransactionAccount = value;
                _FromAccountId = _TransactionAccount.Id;
                OnPropertyChanged("TransactionAccount");
            }
        }
        public Currency TransactionCurrency
        {
            get
            {
                if (_TransactionCurrency == null && TransactionAccount != null)
                    _TransactionCurrency = Currency.GetById(TransactionAccount.CurrencyId);

                return _TransactionCurrency;
            }
            set
            {
                _TransactionCurrency = value;
            }
        }

        public Transaction(Guid categoryId, Guid fromAccountId, DateTime date, double sum, string description) : base()
        {
            _CategoryId = categoryId;
            _Description = description;
            _FromAccountId = fromAccountId;
            _Sum = sum;
            _Date = date;
        }

        public abstract bool ValidateSum();

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}