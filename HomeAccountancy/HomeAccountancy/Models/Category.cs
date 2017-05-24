using System;
using System.Data.SQLite;

namespace HomeAccountancy.Model
{
    abstract class Category : DataEntity<Category>
    {
        public string Name { get; private set; }

        public Category(long id, string name) : base(id)
        {
            Name = name;
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public abstract bool ValidateSum(double sum);

        public override string ToString()
        {
            return Name;
        }
    }
}
