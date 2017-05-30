using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace HomeAccountancy.Model
{

    /// <summary>
    /// Клас транзацкції (платежу)
    /// </summary>
    [DataContract]
    [KnownType(typeof(IncomeTransaction))]
    [KnownType(typeof(OutgoTransaction))]
    [KnownType(typeof(TransferTransaction))]
    [KnownType(typeof(RegularTransaction))]
    public abstract class Transaction : DataEntity<Transaction>, INotifyPropertyChanged, IComparable<Transaction>
    {
        /// <summary>
        /// Id Категорії платежу
        /// </summary>
        [DataMember]
        private Guid _CategoryId;

        /// <summary>
        /// Id Аккаунту платежу
        /// </summary>
        [DataMember]
        private Guid _FromAccountId;

        /// <summary>
        /// Сума платежу
        /// </summary>
        [DataMember]
        private double _Sum;

        /// <summary>
        /// Опис платежу
        /// </summary>
        [DataMember]
        private string _Description;

        /// <summary>
        /// Дата створення платежу
        /// </summary>
        [DataMember]
        private DateTime _Date;

        private double _Rest;

        // Реалізація аксесорів доступу до полів даних
        // При зміні даних - повідомляє про це, генеруючи подію PropertyChanged
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

        /// <summary>
        /// Категорія платежу
        /// </summary>
        private Category _TransactionCategory;

        /// <summary>
        /// Рахунок платежу
        /// </summary>
        private Account _TransactionAccount;

        /// <summary>
        /// Валюта платежу
        /// </summary>
        private Currency _TransactionCurrency;

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

        /// <summary>
        /// Конструктор класу
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="fromAccountId"></param>
        /// <param name="date"></param>
        /// <param name="sum"></param>
        /// <param name="description"></param>
        public Transaction(Guid categoryId, Guid fromAccountId, DateTime date, double sum, string description) : base()
        {
            _CategoryId = categoryId;
            _Description = description;
            _FromAccountId = fromAccountId;
            _Sum = sum;
            _Date = date;
        }

        public abstract bool ValidateSum();


        /// <summary>
        /// Подія зміни параметру (INotifyPropertyChanged)
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        /// <summary>
        /// Порівняння двох платежів (для сортування)
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Transaction other)
        {
            return _Date.CompareTo(other._Date);
        }
    }
}