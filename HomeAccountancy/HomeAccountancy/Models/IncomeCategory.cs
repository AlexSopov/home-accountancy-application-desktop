using System;
using System.Data.SQLite;

namespace HomeAccountancy.Model
{
    class IncomeCategory : Category
    {
        public IncomeCategory(long id, string name) : base(id, name)
        {
        }

        public override bool ValidateSum(double sum)
        {
            return sum >= 0;
        }
    }
}
