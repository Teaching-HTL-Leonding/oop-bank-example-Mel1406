
public abstract class Account
{
    public abstract decimal minBalance { get; }
    public abstract decimal maxBalance { get; }
    public string AccountNumber { get; set; } = "";
    public decimal CurrentBalance { get; set; } = 0;
    public string AccountHolder { get; set; } = "";
    public decimal InterestRate { get; set; } = 0.0M;

    public Account(string accountNumber, decimal currentBalance, string accountHolder, decimal interestRate)
    {
        AccountNumber = accountNumber;
        CurrentBalance = currentBalance;
        AccountHolder = accountHolder;
        InterestRate = interestRate;
    }

    public virtual bool IsAllowed(Transaction transaction)
    {
        return transaction.AccountNumber == AccountNumber;
    }
    public bool TryExecute(Transaction transaction)
    {
        if (IsAllowed(transaction))
        {
            CurrentBalance += transaction.Amount;
            return true;
        }
        return false;
    }
    public virtual decimal CalculateMonthlyInterests(decimal borrowingRate)
    {
        return Math.Round(CurrentBalance * InterestRate / 12, 2);
    }
}
