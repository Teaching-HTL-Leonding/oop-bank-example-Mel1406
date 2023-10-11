
public class SavingAccount : Account
{
    public override decimal minBalance => 0;
    public override decimal maxBalance => 100_000_000;

    public SavingAccount(string accountNumber, decimal currentBalance, string accountHolder, decimal interestRate)
    : base(accountNumber, currentBalance, accountHolder, interestRate)
    {
    }

    public override bool IsAllowed(Transaction transaction) => (CurrentBalance + transaction.Amount < maxBalance) 
                                                            && (CurrentBalance + transaction.Amount > minBalance) 
                                                            && base.IsAllowed(transaction);
                                                    
}