using HomeAccountancy.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using static HomeAccountancy.Model.RegularTransaction;

namespace HomeAccountancy.ViewModels
{
    class RegularTransactionViewModel : INotifyPropertyChanged
    {
        private Transaction _SelectedTransaction;

        public ObservableCollection<Transaction> RegularTransactions { get; set; }
        public Transaction SelectedTransaction
        {
            get { return _SelectedTransaction; }
            set
            {
                _SelectedTransaction = value;
                OnPropertyChanged("SelectedTransaction");
            }
        }

        public RegularTransactionViewModel()
        {
            RegularTransactions = new ObservableCollection<Transaction>();
            foreach (Transaction transaction in Transaction.Entities)
            {
                if (transaction is RegularTransaction)
                    RegularTransactions.Add(transaction);
            }
        }

        private RelayCommand _AddNewCommand;
        public RelayCommand AddNewCommand
        {
            get
            {
                return _AddNewCommand ??
                  (_AddNewCommand = new RelayCommand(commandAgrument =>
                  {
                      Guid accountId = Account.Entities.Count > 0 ? Account.Entities[0].Id : Guid.Empty;
                      Guid categoryId = Category.Entities.Count > 0 ? Category.Entities[0].Id : Guid.Empty;

                      RegularTransaction regularTransaction = new RegularTransaction(categoryId, accountId, 0, DateTime.Today, "")
                      {
                          IsMonday = true,
                          IsThursday = true,
                          IsWednesday = true,
                          IsSaturday = true,
                          IsFriday = true,
                          IsSunday = true,
                          IsTuesday = true,
                          ExecutingDate = DateTime.Today.AddDays(1),
                          StartDate = DateTime.Today.AddDays(1),
                          EndDate = DateTime.Today.AddDays(1).AddMonths(1),
                          DayOfMonth = 1,
                          Strategy = ExecutingStrategy.MultyDay,
                          LastExecuteDayDate = DateTime.Today.AddDays(-1)
                      };

                      SelectedTransaction = regularTransaction;
                      RegularTransactions.Add(regularTransaction);
                      Transaction.Entities.Add(regularTransaction);
                  }));
            }
        }

        private RelayCommand _DeleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return _DeleteCommand ??
                  (_DeleteCommand = new RelayCommand(commandAgrument =>
                  {
                      Transaction transaction = commandAgrument as Transaction;

                      if (transaction != null)
                      {
                          RegularTransactions.Remove(transaction);
                          transaction.Delete();
                      }
                  },
                 (commandAgrument) => RegularTransactions.Count > 0 && SelectedTransaction != null));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
