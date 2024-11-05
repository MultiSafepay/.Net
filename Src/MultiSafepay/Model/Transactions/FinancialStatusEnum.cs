namespace MultiSafepay.Model.Transactions
{
    public enum FinancialStatusEnum
    {
        completed, 
        created, 
        declined, 
        error, 
        expired, 
        initialized, 
        manual,
        @new, 
        refunded, 
        reserved, 
        uncleared,
        @void
    }
}
