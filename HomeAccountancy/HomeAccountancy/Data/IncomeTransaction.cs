namespace HomeAccountancy.Data
{
    class IncomeTransaction : Transaction
    {
        public IncomeTransaction(long categoryId, long fromAccountId, double sum) : base(categoryId, fromAccountId, sum)
        {
        }

        public override bool ValidateSum()
        {
            return Sum >= 0;
        }
    }
}
