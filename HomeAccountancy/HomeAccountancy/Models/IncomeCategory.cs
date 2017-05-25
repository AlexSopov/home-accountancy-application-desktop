using System;
using System.Data.SQLite;
using System.Runtime.Serialization;

namespace HomeAccountancy.Model
{
    [DataContract]
    class IncomeCategory : Category
    {
        public IncomeCategory(string name) : base(name)
        {
        }

        public override bool ValidateSum(double sum)
        {
            return sum >= 0;
        }
    }
}
