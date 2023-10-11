
public class BusinessAccount : BorrowingAccount
{
    public override decimal minBalance => -1_000_000;
    public override decimal maxBalance => 100_000_000;
    public const decimal maxTransactionValue = 100_000;
    public override decimal BorrowingRate { get; set; }

    public BusinessAccount(string accountNumber, decimal currentBalance, string accountHolder, decimal interestRate, decimal borrowingRate)
    : base(accountNumber, currentBalance, accountHolder, interestRate, borrowingRate)
    {
    }

    override public bool IsAllowed(Transaction transaction) => !(Math.Abs(transaction.Amount) > maxTransactionValue) 
                                                            && !(CurrentBalance + transaction.Amount > maxBalance) 
                                                            && !(CurrentBalance + transaction.Amount < minBalance) 
                                                            && base.IsAllowed(transaction);
}