namespace ContaCorrente.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        Account account1 = new Account(10);
        Account account2 = new Account(11);
        Account account3 = new Account(12);

        account1.ShowCurrentBalance();
        account2.ShowCurrentBalance();
        account3.ShowCurrentBalance();

        account1.Deposit(1000);
        account1.TransferBalance(500, account2);
        account3.Withdrawal(1400);
        account3.TransferBalance(1000, account1);

        account1.ShowAccountLog();
        account2.ShowAccountLog();
        account3.ShowAccountLog();

        account1.ShowCurrentBalance();
        account2.ShowCurrentBalance();
        account3.ShowCurrentBalance();

        Console.ReadKey();
    }
}
