Console.OutputEncoding = System.Text.Encoding.Default;
var accounts = File.ReadAllLines(args[0]);
var transactions = File.ReadAllLines(args[1]);

var accountDict = new Dictionary<string, Account>();

var myTransactions = new Transaction[transactions.Length - 1];

for (int i = 1; i < accounts.Length; i++)
{
    var infosAccount = accounts[i].Split(";");
    var accountType = infosAccount[0].ToLower();
    var accountNumber = infosAccount[1];
    var accountHolder = infosAccount[2];
    var currentBalance = decimal.Parse(infosAccount[3]);

    switch (accountType)
    {
        case "c": accountDict.Add(accountNumber, new CheckingAccount(accountNumber, currentBalance, accountHolder, 0, 0)); break;
        case "b": accountDict.Add(accountNumber, new BusinessAccount(accountNumber, currentBalance, accountHolder, 0, 0)); break;
        case "s": accountDict.Add(accountNumber, new SavingAccount(accountNumber, currentBalance, accountHolder, 0)); break;
        case "f": 
            var openingDate = DateOnly.Parse(infosAccount[4]);
            var fixedUntil = DateOnly.Parse(infosAccount[5]);
            accountDict.Add(accountNumber, new FixedDeposit(accountNumber, currentBalance, accountHolder, openingDate, fixedUntil, 0)); 
            break;
        default: throw new Exception("Invalid account type");
    };
}
for (int i = 1; i < transactions.Length; i++)
{
    var infosTransactions = transactions[i].Split(";");
    var transactionAccountNumber = infosTransactions[0];
    var transactionDescription = infosTransactions[1];
    var transactionAmount = decimal.Parse(infosTransactions[2]);
    var transactionDate = DateTime.Parse(infosTransactions[3]);

    var myTransaction = new Transaction(transactionAccountNumber, transactionDescription, transactionAmount, transactionDate);
    myTransactions[i - 1] = myTransaction;
}

foreach (var transaction in myTransactions)
{
    var account = accountDict[transaction.AccountNumber];
    if (!account.TryExecute(transaction))
    {
        Console.WriteLine($"Transaction with description {transaction.Description} on {transaction.Timestamp} failed");
        break;
    }
}
