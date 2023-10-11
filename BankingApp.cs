
Console.OutputEncoding = System.Text.Encoding.Default;
var openingDate = new DateOnly();
var fixedUntil = new DateOnly();

Console.Write("What kind of account do you have? (c)hecking, (b)usiness, (s)avings or (f)ixed deposite? ");
var accountType = Console.ReadLine()!.ToLower();

Console.Write("Please enter the account number: ");
var accountNumber = Console.ReadLine()!;

Console.Write("Please enter the holders name: ");
var accountHolder = Console.ReadLine()!;

Console.Write("Please enter your current balance: ");
var currentBalance = decimal.Parse(Console.ReadLine()!);

if(accountType == "f")
{
    Console.Write("Please enter the opening date: ");
    openingDate = DateOnly.Parse(Console.ReadLine()!);
    Console.Write("Please enter the date until it is fixed: ");
    fixedUntil = DateOnly.Parse(Console.ReadLine()!);
}

Account myAccount = accountType switch{
    "c" => new CheckingAccount(accountNumber, currentBalance, accountHolder, 0, 0),
    "b" => new BusinessAccount(accountNumber, currentBalance, accountHolder, 0, 0),
    "s" => new SavingAccount(accountNumber, currentBalance, accountHolder, 0),
    "f" => new FixedDeposit(accountNumber, currentBalance, accountHolder, openingDate, fixedUntil, 0),
    _ => throw new Exception("Invalid account type")
};

Console.Write("Please enter the account number of the transaction: ");
var transactionAccountNumber = Console.ReadLine()!;

Console.Write("Please enter the description of the transaction: ");
var transactionDescription = Console.ReadLine()!;

Console.Write("Please enter the amount of the transaction: ");
var transactionAmount = decimal.Parse(Console.ReadLine()!);

Console.Write("Please enter the date of the transaction: ");
var transactionDate = DateTime.Parse(Console.ReadLine()!);

Transaction myTransaction = new Transaction(transactionAccountNumber, transactionDescription, transactionAmount, transactionDate);

if (myAccount.TryExecute(myTransaction))
{
    Console.WriteLine($"Transaction successful. New balance is {myAccount.CurrentBalance}€");
}