using System;
using System.Data.SQLite;

namespace HomeAccountancy.Model
{
    class IncomeTransaction : Transaction
    {
        public IncomeTransaction(long id, long categoryId, long fromAccountId, double sum, DateTime date, string description) : 
            base(id, categoryId, fromAccountId, date, sum, description)
        {
        }

        public override bool ValidateSum()
        {
            throw new NotImplementedException();
        }
    }
}
