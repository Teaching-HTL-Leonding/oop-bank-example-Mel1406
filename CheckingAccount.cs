
public class CheckingAccount : BorrowingAccount
{
    public override decimal minBalance => -10_000;
    
    public override decimal maxBalance => 10_000_000;

    public override decimal BorrowingRate { get; set; }

    public const decimal maxTransactionValue = 10_000;

    public CheckingAccount(string accountNumber, decimal currentBalance, string accountHolder, decimal interestRate, decimal borrowingRate)
    : base(accountNumber, currentBalance, accountHolder, interestRate, borrowingRate)
    {
    }
    public override bool IsAllowed(Transaction transaction) => !(Math.Abs(transaction.Amount) > maxTransactionValue) 
                                                            && !(CurrentBalance + transaction.Amount > maxBalance) 
                                                            && !(CurrentBalance + transaction.Amount < minBalance) 
                                                            && base.IsAllowed(transaction);
}