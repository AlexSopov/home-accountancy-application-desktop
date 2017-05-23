using System;

namespace HomeAccountancy.Data
{
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
