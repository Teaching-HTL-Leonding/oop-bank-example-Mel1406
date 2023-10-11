Console.OutputEncoding = System.Text.Encoding.Default;
var openingDate = new DateOnly();
var fixedUntil = new DateOnly();
var interesRate = 0M;
var borrowingRate = 0M;

Console.Write("What kind of account do you have? (c)hecking, (b)usiness, (s)avings or (f)ixed deposite? ");
var accountType = Console.ReadLine()!.ToLower();

Console.Write("Please enter the account number: ");
var accountNumber = Console.ReadLine()!;

Console.Write("Please enter the holders name: ");
var accountHolder = Console.ReadLine()!;

Console.Write("Please enter your current balance: ");
var currentBalance = decimal.Parse(Console.ReadLine()!);

if (accountType == "f")
{
    Console.Write("Please enter the opening date: ");
    openingDate = DateOnly.Parse(Console.ReadLine()!);
    Console.Write("Please enter the date until it is fixed: ");
    fixedUntil = DateOnly.Parse(Console.ReadLine()!);
}
if (currentBalance > 0)
{
    Console.Write("Please enter the interest rate: ");
    interesRate = decimal.Parse(Console.ReadLine()!);
}
else if (accountType is "c" or "b" && currentBalance < 0)
{
    Console.Write("Please enter the borrowing rate: ");
    borrowingRate = decimal.Parse(Console.ReadLine()!);
}

Account myAccount = accountType switch
{
    "c" => new CheckingAccount(accountNumber, currentBalance, accountHolder, interesRate, borrowingRate),
    "b" => new BusinessAccount(accountNumber, currentBalance, accountHolder, interesRate, borrowingRate),
    "s" => new SavingAccount(accountNumber, currentBalance, accountHolder, interesRate),
    "f" => new FixedDeposit(accountNumber, currentBalance, accountHolder, openingDate, fixedUntil, interesRate),
    _ => throw new Exception("Invalid account type")
};

Console.WriteLine($"The monthly interest is {myAccount.CalculateMonthlyInterests(borrowingRate)}€");
