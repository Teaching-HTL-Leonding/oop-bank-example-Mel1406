
public class FixedDeposit : Account
{
    public override decimal minBalance => 0;
    public override decimal maxBalance => 10_000_000;

    public DateOnly OpeningDate { get; set; }
    public DateOnly FixedUntil { get; set; }

    public FixedDeposit(string accountNumber, decimal currentBalance, string accountHolder, DateOnly openingDate, DateOnly fixedUntil, decimal interestRate)
    : base(accountNumber, currentBalance, accountHolder, interestRate)
    {
        OpeningDate = openingDate;
        FixedUntil = fixedUntil;
    }

    public override bool IsAllowed(Transaction transaction)
    {
        if (DateOnly.FromDateTime(transaction.Timestamp) == OpeningDate)
        {
            return (transaction.Amount > 0) 
                    && (CurrentBalance + transaction.Amount < maxBalance)
                    && (CurrentBalance + transaction.Amount > minBalance)
                    && base.IsAllowed(transaction);
        }
        else if (DateOnly.FromDateTime(transaction.Timestamp) >= FixedUntil)
        {
            return (transaction.Amount < 0) 
                    && (CurrentBalance + transaction.Amount < maxBalance)
                    && (CurrentBalance + transaction.Amount > minBalance)
                    && base.IsAllowed(transaction);
        }
        else
        {
            return false;
        }
        
    }
}