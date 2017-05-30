using HomeAccountancy.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace HomeAccountancy.ViewModels
{
    class TransactionsViewModel : INotifyPropertyChanged
    {
        private Transaction _SelectedTransaction;
        private double _CurrentRent;
        private double _ExpectedRent;

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

        public double CurrentRent
        {
            get
            {
                double total = 0;
                foreach (Account account in Account.Entities)
                    total += account.Rent;

                return total;
            }
            set
            {
                _CurrentRent = value;
                OnPropertyChanged("CurrentRent");
            }
        }
        public double ExpectedRent
        {
            get
            {
                double total = CurrentRent;

                // TODO Expecting
                total = total + 0;

                return total;
            }
            set
            {
                _ExpectedRent = value;
                OnPropertyChanged("ExpectedRent");
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
            Transactions = Transaction.Entities;
        }

        public void UpdateRentInfo()
        {
            OnPropertyChanged("CurrentRent");
            OnPropertyChanged("ExpectedRent");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
