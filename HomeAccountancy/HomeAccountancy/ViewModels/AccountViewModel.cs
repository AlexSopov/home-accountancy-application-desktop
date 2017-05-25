using HomeAccountancy.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace HomeAccountancy.ViewModels
{
    class AccountViewModel : INotifyPropertyChanged
    {
        private Account selectedPhone;

        public ObservableCollection<Account> Accounts { get; set; }
        public Account SelectedAccount
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                OnPropertyChanged("SelectedAccount");
            }
        }

        public AccountViewModel()
        {
            Accounts = Account.Entities;

            if (Accounts.Count > 0)
                SelectedAccount = Accounts[0];
        }

        private RelayCommand _AddNewCommand;
        private RelayCommand _DeleteCommand;
        public RelayCommand AddNewCommand
        {
            get
            {
                return _AddNewCommand ??
                  (_AddNewCommand = new RelayCommand(obj =>
                  {
                      Account account = new Account("Новий рахунок", Guid.Empty, 0);
                      SelectedAccount = account;
                  }));
            }
        }
        public RelayCommand DeleteCommand
        {
            get
            {
                return _DeleteCommand ??
                  (_DeleteCommand = new RelayCommand(commandAgrument =>
                  {
                      Account account = commandAgrument as Account;
                      for (int i = 0; i < Transaction.Entities.Count; i++)
                      {
                          if (Transaction.Entities[i].FromAccountId == account.Id)
                              Transaction.Entities.Remove(Transaction.Entities[i]);
                      }

                      if (account != null)
                          Accounts.Remove(account);
                  },
                 (commandAgrument) => Accounts.Count > 0));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
