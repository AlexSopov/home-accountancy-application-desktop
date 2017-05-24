using System;

namespace HomeAccountancy.Model
{
    class TransferTransaction : Transaction
    {
        public long ToAccontId { get; private set; }

        public TransferTransaction(long id, long categoryId, long fromAccountId, long toAccountId, double sum, DateTime date, string description) :
            base(id, categoryId, fromAccountId, date, sum, description)
        {
            ToAccontId = toAccountId;
        }

        public override bool ValidateSum()
        {
            return true;
        }
    }
}
