namespace HomeAccountancy.Data
{
    class TransferTransaction : Transaction
    {
        public long ToAccontId { get; private set; }

        public TransferTransaction(long categoryId, long fromAccountId, long toAccontId ,double sum) : base(categoryId, fromAccountId, sum)
        {
            ToAccontId = toAccontId;
        }

        public override bool ValidateSum()
        {
            return true;
        }
    }
}
