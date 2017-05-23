using System;

namespace HomeAccountancy.Data
{
    abstract class Category : DataEntity<Category>
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            Name = name;
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override Category GetById()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public abstract bool ValidateSum(double sum);
    }
}
