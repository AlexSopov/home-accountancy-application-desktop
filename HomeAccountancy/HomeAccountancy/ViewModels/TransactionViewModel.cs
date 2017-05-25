using HomeAccountancy.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace HomeAccountancy.ViewModels
{
    class TransactionViewModel : INotifyPropertyChanged
    {
        private Transaction _SelectedTransaction;

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

        public TransactionViewModel()
        {
            Transactions = Transaction.Entities;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
