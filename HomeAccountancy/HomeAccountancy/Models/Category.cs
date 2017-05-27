using System.ComponentModel;
using System.Runtime.Serialization;

namespace HomeAccountancy.Model
{
    [DataContract]
    [KnownType(typeof(OutgoCategory))]
    [KnownType(typeof(IncomeCategory))]
    abstract class Category : DataEntity<Category>, INotifyPropertyChanged
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

        public abstract bool ValidateSum(double sum);

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }


        public override string ToString()
        {
            return Name;
        }
    }
}
