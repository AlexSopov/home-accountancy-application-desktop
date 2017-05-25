using System;
using System.Runtime.Serialization;

namespace HomeAccountancy.Model
{
    [DataContract]
    class TransferTransaction : Transaction
    {
        [DataMember]
        public Guid ToAccontId { get; private set; }

        public TransferTransaction(Guid categoryId, Guid fromAccountId, Guid toAccountId, double sum, DateTime date, string description) :
            base(categoryId, fromAccountId, date, sum, description)
        {
            ToAccontId = toAccountId;
        }

        public override bool ValidateSum()
        {
            return true;
        }
    }
}
