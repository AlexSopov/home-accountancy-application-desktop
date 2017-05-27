using System;
using System.Runtime.Serialization;

namespace HomeAccountancy.Model
{
    [DataContract]
    class OutgoTransaction : Transaction
    {
        public OutgoTransaction(Guid categoryId, Guid fromAccountId, double sum, DateTime date, string description) :
            base(categoryId, fromAccountId, date, sum, description)
        {
        }

        public override bool ValidateSum()
        {
            throw new NotImplementedException();
        }
    }
}
