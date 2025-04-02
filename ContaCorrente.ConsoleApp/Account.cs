namespace ContaCorrente.ConsoleApp
{
    class Account
    {
        int accountNumber;
        Queue<string> accountLog = new Queue<string>();
        decimal balance;
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
            {
                Console.WriteLine();
                Console.WriteLine($"Conta N°{accountNumber}: Saldo insuficiente");
                Console.WriteLine();
            }
            else
            {
                balance -= amount;
                AddLogEntry($"Saque: -R${amount}");
            }
        }

        public void TransferBalance(decimal amount, Account account)
        {
            if (balance - amount < withdrawalLimit)
            {
                Console.WriteLine();
                Console.WriteLine($"Conta N°{accountNumber}: Saldo insuficiente");
                Console.WriteLine();
            }
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
            Console.WriteLine();
            Console.WriteLine($"Conta N°{accountNumber}: Saldo atual: R${balance:F2}");
            Console.WriteLine();
        }

        public void ShowAccountLog()
        {
            Console.WriteLine();
            Console.WriteLine($"Conta N°{accountNumber}: Histórico");
            foreach (string entry in accountLog)
            {
                Console.WriteLine(entry);
            }
            Console.WriteLine();
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
