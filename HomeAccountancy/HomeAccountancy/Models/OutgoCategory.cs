using System;
using System.Data.SQLite;

namespace HomeAccountancy.Model
{
    class OutgoCategory : Category
    {
        public OutgoCategory(long id, string name) : base(id, name)
        {
        }

        public override bool ValidateSum(double sum)
        {
            return sum <= 0;
        }
    }
}
