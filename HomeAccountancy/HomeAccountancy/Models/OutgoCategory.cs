using System.Runtime.Serialization;

namespace HomeAccountancy.Model
{
    [DataContract]
    public class OutgoCategory : Category
    {
        public OutgoCategory(string name, string description) : base(name, description)
        {
        }

        public override int GetTransactionSign()
        {
            return -1;
        }
    }
}
