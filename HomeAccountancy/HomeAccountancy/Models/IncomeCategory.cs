using System.Runtime.Serialization;

namespace HomeAccountancy.Model
{
    [DataContract]
    public class IncomeCategory : Category
    {
        public IncomeCategory(string name, string description) : base(name, description)
        {
        }

        public override int GetTransactionSign()
        {
            return 1;
        }
    }
}
