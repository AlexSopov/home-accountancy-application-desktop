namespace HomeAccountancy.Data
{
    class OutgoTransaction : Transaction
    {
        public OutgoTransaction(long categoryId, long fromAccountId, double sum) : base(categoryId, fromAccountId, sum)
        {
        }

        public override bool ValidateSum()
        {
            return Sum <= 0;
        }
    }
}
