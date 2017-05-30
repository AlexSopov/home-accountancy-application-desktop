using HomeAccountancy.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace HomeAccountancy.ViewModels
{
    class AccountViewModel : INotifyPropertyChanged
    {
        private Account _SelectedAccount;

        public ObservableCollection<Account> Accounts { get; set; }
        public Account SelectedAccount
        {
            get { return _SelectedAccount; }
            set
            {
                _SelectedAccount = value;
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
                  (_AddNewCommand = new RelayCommand(commandAgrument =>
                  {
                      Guid currencyId = Currency.Entities.Count > 0 ? Currency.Entities[0].Id : Guid.Empty;
                      Account account = new Account("Новий рахунок", currencyId, 0);
                      SelectedAccount = account;
                      account.Commit();
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
                      account.Delete();
                  },
                 (commandAgrument) => Accounts.Count > 0 && SelectedAccount != null));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
