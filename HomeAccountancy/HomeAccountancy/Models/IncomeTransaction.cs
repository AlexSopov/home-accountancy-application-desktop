using System;
using System.Data.SQLite;
using System.Runtime.Serialization;

namespace HomeAccountancy.Model
{
    [DataContract]
    class IncomeTransaction : Transaction
    {
        public IncomeTransaction(Guid
            categoryId, Guid fromAccountId, double sum, DateTime date, string description) : 
            base(categoryId, fromAccountId, date, sum, description)
        {
        }

        public override bool ValidateSum()
        {
            throw new NotImplementedException();
        }
    }
}
