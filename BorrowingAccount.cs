
public abstract class BorrowingAccount : Account
{
    public abstract decimal BorrowingRate { get; set; }

    public BorrowingAccount(string accountNumber, decimal currentBalance, string accountHolder, decimal interestRate, decimal borrowingRate)
    :base (accountNumber, currentBalance, accountHolder, interestRate)
    {
        BorrowingRate = borrowingRate;
    }
    public override decimal CalculateMonthlyInterests(decimal borrowingRate)
    {
        if (CurrentBalance < 0)
        {
            return Math.Round(CurrentBalance * BorrowingRate / 12, 2);
        }
        return base.CalculateMonthlyInterests(BorrowingRate); 
    }
}