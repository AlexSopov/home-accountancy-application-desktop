using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace HomeAccountancy.Model
{
    /// <summary>
    /// Клас категорії платежу
    /// </summary>
    [DataContract]
    [KnownType(typeof(OutgoCategory))]
    [KnownType(typeof(IncomeCategory))]
    public abstract class Category : DataEntity<Category>, INotifyPropertyChanged, IComparable<Category>
    {
        /// <summary>
        /// Назва категорії
        /// </summary>
        [DataMember]
        private string _Name;

        /// <summary>
        /// Опис категорії
        /// </summary>
        [DataMember]
        public string _Description;

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
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
                OnPropertyChanged("Description");
            }
        }

        /// <summary>
        /// Конструювання категорії
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public Category(string name, string description) : base()
        {
            Name = name;
            Description = description;
        }

        /// <summary>
        /// Отримати знаку категорії: -1 - витрата, 1 - поповнення
        /// </summary>
        /// <returns></returns>
        public abstract int GetTransactionSign();

        /// <summary>
        /// Видалення категорії: виделення транзакцій, пов'язаних з цією категорією
        /// </summary>
        public override void Delete()
        {
            List<Transaction> delete = new List<Transaction>();
            foreach (Transaction transaction in Transaction.Entities)
            {
                if (transaction.CategoryId == Id)
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
            return Name;
        }

        /// <summary>
        /// Порівняння двох категорій(для сортування)
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Category other)
        {
            return _Name.CompareTo(other._Name);
        }
    }
}
