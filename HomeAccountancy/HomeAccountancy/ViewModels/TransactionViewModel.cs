using HomeAccountancy.Model;
using HomeAccountancy.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;

namespace HomeAccountancy.ViewModels
{
    class TransactionsViewModel : INotifyPropertyChanged
    {
        private Transaction _SelectedTransaction;
        private Account _SelectedAccount;

        private double _CurrentRent;
        private double _ExpectedRent;
        private double _ExIncomes, _ExOuntgoes;

        public ObservableCollection<Transaction> Transactions { get; set; }
        public Transaction SelectedTransaction
        {
            get { return _SelectedTransaction; }
            set
            {
                _SelectedTransaction = value;
                OnPropertyChanged("SelectedTransaction");
            }
        }
        public Account SelectedAccount
        {
            get
            {
                return _SelectedAccount;
            }
            set
            {
                _SelectedAccount = value;

                Filter filter = Filter.GetInstance();
                filter.IsAccountFilter = true;
                filter.EnabledAccounts.Clear();
                filter.EnabledAccounts.Add(SelectedAccount);

                filter.UpdateFilteredTransactions();
                Transactions = filter.FilteredTransacrions;


                OnPropertyChanged("SelectedAccount");
            }
        }

        public SolidColorBrush CurrentRentColor
        {
            get
            {
                if (CurrentRent >= 0)
                    return (SolidColorBrush)(new BrushConverter().ConvertFrom("#81C784"));
                else
                    return (SolidColorBrush)(new BrushConverter().ConvertFrom("#E57373"));
            }
        }
        public SolidColorBrush ExpectedRentColor
        {
            get
            {
                if (ExpectedRent >= 0)
                    return (SolidColorBrush)(new BrushConverter().ConvertFrom("#81C784"));
                else
                    return (SolidColorBrush)(new BrushConverter().ConvertFrom("#E57373"));
            }
        }

        public double CurrentRent
        {
            get
            {
                if (SelectedAccount == null)
                    return 0;
                return SelectedAccount.Rent;
            }
            set
            {
                _CurrentRent = value;
                OnPropertyChanged("CurrentRent");
                OnPropertyChanged("CurrentRentColor");
            }
        }
        public double ExpectedRent
        {
            get
            {
                if (SelectedAccount == null)
                    return 0;

                double outgo, income;
                RegularTransaction.GetRegularSumToAccount(
                    SelectedAccount,
                    new DateTime(DateTime.Today.Year, DateTime.Today.Month, 
                    DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month)),
                    out income, out outgo);

                ExIncomes = income;
                ExOuntgoes = outgo;
                return SelectedAccount.Rent - Math.Abs(outgo) + Math.Abs(income);
            }
            set
            {
                _ExpectedRent = value;
                OnPropertyChanged("ExpectedRent");
                OnPropertyChanged("ExpectedRentColor");
            }
        }
        public double ExIncomes
        {
            get { return _ExIncomes; }
            set
            {
                _ExIncomes = value;
                OnPropertyChanged("ExIncomes");
            }
        }
        public double ExOuntgoes
        {
            get { return _ExOuntgoes; }
            set
            {
                _ExOuntgoes = value;
                OnPropertyChanged("ExOuntgoes");
            }
        }

        private RelayCommand _DeleteCommand;
        private RelayCommand _ChangeCommand;

        public RelayCommand DeleteCommand
        {
            get
            {
                return _DeleteCommand ??
                  (_DeleteCommand = new RelayCommand(commandAgrument =>
                  {
                      Transaction transaction = commandAgrument as Transaction;

                      if (transaction != null)
                          transaction.Delete();
                  },
                 (commandAgrument) => Transactions.Count > 0 && SelectedTransaction != null));
            }
        }
        public RelayCommand ChangeCommand
        {
            get
            {
                return _ChangeCommand ??
                  (_ChangeCommand = new RelayCommand(commandAgrument =>
                  {
                      Transaction transaction = commandAgrument as Transaction;
                      SingleTransactionWindow stw = new SingleTransactionWindow();
                      stw.MainData.DataContext = transaction;

                      stw.ShowDialog();
                  },
                 (commandAgrument) => Transactions.Count > 0 && SelectedTransaction != null));
            }
        }

        public TransactionsViewModel()
        {
            Transactions = Filter.GetInstance().FilteredTransacrions;

            if (Account.Entities.Count > 0)
                SelectedAccount = Account.Entities[0];

            Transactions.CollectionChanged += (sender, e) => UpdateRentInfo();
        }

        public void UpdateRentInfo()
        {
            OnPropertyChanged("CurrentRent");
            OnPropertyChanged("ExpectedRent");
            OnPropertyChanged("ExpectedRentColor");
            OnPropertyChanged("CurrentRentColor");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
