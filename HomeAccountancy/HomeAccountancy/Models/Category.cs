using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace HomeAccountancy.Model
{
    [DataContract]
    [KnownType(typeof(OutgoCategory))]
    [KnownType(typeof(IncomeCategory))]
    public abstract class Category : DataEntity<Category>, INotifyPropertyChanged, IComparable<Category>
    {
        [DataMember]
        private string _Name;

        [DataMember]
        public string _Description;

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

        public Category(string name, string description) : base()
        {
            Name = name;
            Description = description;
        }

        public abstract int GetTransactionSign();
        public override void Delete()
        {
            for (int i = 0; i < Transaction.Entities.Count; i++)
            {
                if (Transaction.Entities[i].CategoryId == Id)
                    Transaction.Entities[i].Delete();
            }
            base.Delete();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(Category other)
        {
            return _Name.CompareTo(other._Name);
        }
    }
}
