using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace HomeAccountancy.Model
{
    /// <summary>
    /// Класс рахунку
    /// </summary>
    [DataContract]
    public class Account : DataEntity<Account>, INotifyPropertyChanged, IComparable<Account>
    {
        /// <summary>
        /// Назва рахунку
        /// </summary>
        [DataMember]
        public string _Name;

        /// <summary>
        /// Id валюти рахунку
        /// </summary>
        [DataMember]
        public Guid _CurrencyId;

        /// <summary>
        /// початковий баланс рахунку
        /// </summary>
        [DataMember]
        public double _StartBalance;

        // Реалізація аксесорів доступу до полів даних
        // При зміні даних - повідомляє про це, генеруючи подію PropertyChanged
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }
        public Guid CurrencyId
        {
            get { return _CurrencyId; }
            set
            {
                _CurrencyId = value;
                OnPropertyChanged("CurrencyId");
            }
        }
        public double StartBalance
        {
            get { return _StartBalance; }
            set
            {
                _StartBalance = value;
                OnPropertyChanged("StartBalance");
                OnPropertyChanged("Rent");
            }
        }

        /// <summary>
        /// Залишок на рахунку
        /// </summary>
        public double Rent {
            get
            {
                double sum = _StartBalance;

                foreach (Transaction transaction in Transaction.Entities)
                {
                    if ((transaction is OutgoTransaction || transaction is IncomeTransaction) && transaction.FromAccountId == Id &&
                        transaction.Date <= DateTime.Today)
                        sum += transaction.Sum;
                }

                return sum;
            }
        }

        /// <summary>
        /// Валюта рахунку
        /// </summary>
        public Currency Currency
        {
            get
            {
                return Currency.GetById(CurrencyId);
            }
            set
            {
                _CurrencyId = value.Id;
                OnPropertyChanged("Currency");
            }
        }

        /// <summary>
        /// Конструювання об'єкту рахунку
        /// </summary>
        /// <param name="name"></param>
        /// <param name="currencyId"></param>
        /// <param name="startBalance"></param>
        public Account(string name, Guid currencyId, double startBalance) : base()
        {
            Name = name;
            CurrencyId = currencyId;
            StartBalance = startBalance;
        }

        /// <summary>
        /// Траннзації платежу
        /// </summary>
        public List<Transaction> Transactions
        {
            get
            {
                List<Transaction> transactions = new List<Transaction>();
                foreach (Transaction transaction in Transaction.Entities)
                {
                    if (transaction.FromAccountId == Id)
                        transactions.Add(transaction);
                }

                return transactions;
            }
        }

        /// <summary>
        /// Видалення рахунку. Каскадне видалення усіх платежів рахунку
        /// </summary>
        public override void Delete()
        {
            List<Transaction> delete = new List<Transaction>();
            foreach (Transaction transaction in Transaction.Entities)
            {
                if (transaction.FromAccountId == Id)
                    delete.Add(transaction);
            }
            foreach (Transaction transaction in delete)
                transaction.Delete();

            base.Delete();
        }

        /// <summary>
        /// Подія зміни параметру (INotifyPropertyChanged)
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        /// <summary>
        /// Репрезентація об'єкту
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} ({1} {2})", Name, Rent, Currency);
        }

        /// <summary>
        /// Порівняння рахунків (для сортування)
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Account other)
        {
            return _Name.CompareTo(other._Name);
        }
    }
}
