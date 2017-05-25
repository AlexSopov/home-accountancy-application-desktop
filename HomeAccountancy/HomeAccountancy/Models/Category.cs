using System;
using System.Data.SQLite;
using System.Runtime.Serialization;

namespace HomeAccountancy.Model
{
    [DataContract]
    [KnownType(typeof(OutgoCategory))]
    [KnownType(typeof(IncomeCategory))]
    abstract class Category : DataEntity<Category>
    {
        [DataMember]
        public string Name { get; private set; }

        public Category(string name) : base()
        {
            Name = name;
        }

        public abstract bool ValidateSum(double sum);

        public override string ToString()
        {
            return Name;
        }
    }
}
