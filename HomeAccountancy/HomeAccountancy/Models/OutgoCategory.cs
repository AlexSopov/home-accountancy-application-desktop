using System.Runtime.Serialization;

namespace HomeAccountancy.Model
{
    [DataContract]
    class OutgoCategory : Category
    {
        public OutgoCategory(string name, string description) : base(name, description)
        {
        }

        public override bool ValidateSum(double sum)
        {
            return sum <= 0;
        }
    }
}
