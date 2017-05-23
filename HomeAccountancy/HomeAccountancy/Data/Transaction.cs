using System;

namespace HomeAccountancy.Data
{
    abstract class Transaction : DataEntity<Transaction>
    {
        public long CategoryId { get; private set; }
        public long FromAccountId { get; private set; }
        public double Sum { get; private set; }

        public Transaction(long categoryId, long fromAccountId, double sum)
        {
            CategoryId = categoryId;
            FromAccountId = fromAccountId;
            Sum = sum;
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }
        public override Transaction GetById()
        {
            throw new NotImplementedException();
        }
        public override void Save()
        {
            throw new NotImplementedException();
        }

        public abstract bool ValidateSum();
    }
}
