namespace ContaCorrente.ConsoleApp
{
    class Account
    {
        public int accountNumber { get; private set; }
        Queue<string> accountLog = new Queue<string>();
        public decimal balance { get; private set; }
        decimal withdrawalLimit = -500.00m;

        public Account(int accountNumber)
        {
            this.accountNumber = accountNumber;
            balance = 1000.00m;
        }

        public void Deposit(decimal amount)
        {
            balance += amount;
            AddLogEntry($"Depósito: +R${amount}");
        }

        public void Withdrawal(decimal amount)
        {
            if (balance - amount < withdrawalLimit)
                Console.WriteLine("Saldo insuficiente");
            else
            {
                balance -= amount;
                AddLogEntry($"Saque: +R${amount}");
            }
        }

        public void Transfer(decimal amount, Account account)
        {
            if (balance - amount < withdrawalLimit)
                Console.WriteLine("Saldo insuficiente");
            else
            {
                balance -= amount;
                AddLogEntry($"Transfêrencia: -R${amount} p/ Conta N°{account.accountNumber}");
                account.Deposit(amount);
                account.AddLogEntry($"Transfêrencia: +R${amount} da Conta N°{accountNumber}");
            }
        }

        public void ShowCurrentBalance()
        {          
            Console.WriteLine($"Conta N°{accountNumber}: Saldo atual: R${balance:F2}");
        }

        public void ShowAccountLog()
        {
            Console.Clear();
            Console.WriteLine(new string('─', UserInteraction.menuWidth + 2));
            Console.WriteLine($"Conta N°{accountNumber}: Histórico");
            Console.WriteLine(new string('─', UserInteraction.menuWidth + 2));
            foreach (string entry in accountLog)
            {
                Console.WriteLine(entry);
            }
        }

        public void AddLogEntry(string record)
        {
            if (accountLog.Count >= 20)
            {
                accountLog.Dequeue();
            }
            accountLog.Enqueue(record);
        }
    }
}
