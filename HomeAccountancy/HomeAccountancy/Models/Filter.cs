using HomeAccountancy.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace HomeAccountancy.Models
{
    public class Filter : INotifyPropertyChanged
    {
        private static Filter Instance;
        private bool _IsDatesFilter, _IsSumFilter, _IsAccountFilter, _IsCategoryFilter;
        private DateTime _FromDate, _ToDate;
        private double _MinSum, _MaxSum;
        public List<Category> EnabledCategories;
        public List<Account> EnabledAccounts;

        public ObservableCollection<Transaction> FilteredTransacrions { get; set; }

        public bool IsDatesFilter
        {
            get { return _IsDatesFilter; }
            set
            {
                _IsDatesFilter = value;
                OnPropertyChanged("IsDatesFilter");
            }
        }
        public bool IsSumFilter
        {
            get { return _IsSumFilter; }
            set
            {
                _IsSumFilter = value;
                OnPropertyChanged("IsSumFilter");
            }
        }
        public bool IsAccountFilter
        {
            get { return _IsAccountFilter; }
            set
            {
                _IsAccountFilter = value;
                OnPropertyChanged("IsAccountFilter");
            }
        }
        public bool IsCategoryFilter
        {
            get { return _IsCategoryFilter; }
            set
            {
                _IsCategoryFilter = value;
                OnPropertyChanged("IsCategoryFilter");
            }
        }

        public DateTime FromDate
        {
            get { return _FromDate; }
            set
            {
                _FromDate = value;
                OnPropertyChanged("FromDate");
            }
        }
        public DateTime ToDate
        {
            get { return _ToDate; }
            set
            {
                _ToDate = value;
                OnPropertyChanged("ToDate");
            }
        }
        public double MinSum
        {
            get { return _MinSum; }
            set
            {
                _MinSum = value;
                OnPropertyChanged("MinSum");
            }
        }
        public double MaxSum
        {
            get { return _MaxSum; }
            set
            {
                _MaxSum = value;
                OnPropertyChanged("MaxSum");
            }
        }

        private Filter()
        {
            FilteredTransacrions = new ObservableCollection<Transaction>();
            UpdateFilteredTransactions();

            _IsDatesFilter = false;
            _IsSumFilter = false;
            _IsAccountFilter = false;
            _IsCategoryFilter = false;

            FromDate = DateTime.Today;
            ToDate = DateTime.Today;

            EnabledCategories = new List<Category>();
            EnabledAccounts = new List<Account>();

            Transaction.Entities.CollectionChanged += (sender, e) => UpdateFilteredTransactions();
        }

        public static Filter GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Filter();
            }
            return Instance;
        }

        public List<Transaction> GetFilteredTransacrions()
        {
            List<Transaction> filteredTransactions = new List<Transaction>();
            foreach (Transaction transaction in Transaction.Entities)
            {
                if (!(transaction is IncomeTransaction) && !(transaction is OutgoTransaction))
                    continue;

                if (IsDatesFilter && (transaction.Date < FromDate || transaction.Date > ToDate))
                    continue;

                if (IsSumFilter && (transaction.Sum < MinSum || transaction.Sum > MaxSum))
                    continue;

                if (IsCategoryFilter && !EnabledCategories.Contains(Category.GetById(transaction.CategoryId)))
                    continue;

                if (IsAccountFilter && !EnabledAccounts.Contains(Account.GetById(transaction.FromAccountId)))
                    continue;

                filteredTransactions.Add(transaction);
            }

            return filteredTransactions;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler FilterChanged;
        public void OnPropertyChanged(string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
            FilterChanged?.Invoke(this, EventArgs.Empty);
        }

        public void UpdateFilteredTransactions()
        {
            FilteredTransacrions.Clear();
            foreach (var trans in GetFilteredTransacrions())
                FilteredTransacrions.Add(trans);
        }
    }
}