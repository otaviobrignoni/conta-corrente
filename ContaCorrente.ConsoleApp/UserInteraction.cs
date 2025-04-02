namespace ContaCorrente.ConsoleApp
{
    class UserInteraction
    {
        public static Account[] accounts = new Account[5];
        static Account activeAccount;
        public const int menuWidth = 30;
        static string[] menuOptions = { "Selecionar conta", "Sacar", "Depositar", "Transferência", "Histórico", "Sair" };
        static bool exitOptionSelected = false;

        public static void ShowMenu()
        {
            InitializeAccounts();
            int selectedOption = 0;
            while (!exitOptionSelected)
            {

                RenderMenu("Banco do Programador", menuOptions, selectedOption);
                Console.WriteLine();
                Console.WriteLine($"Conta selecioanda: Conta N° {activeAccount.accountNumber}");
                Console.WriteLine($"Saldo: R${activeAccount.balance}");
                switch (MenuNavigation(menuOptions.Length, ref selectedOption))
                {
                    case 0:
                        SelectAccount();
                        break;
                    case 1:
                        activeAccount.Withdrawal(100);
                        break;
                    case 2:
                        activeAccount.Deposit(100);
                        break;
                    case 3:
                        activeAccount.Transfer(100, activeAccount);
                        break;
                    case 4:
                        activeAccount.ShowAccountLog();
                        AnyKeyPrompt();
                        break;
                    case 5:
                        if (LeavePrompt())
                            exitOptionSelected = true;
                        break;
                }
            }
        }

        private static void InitializeAccounts()
        {
            for (int i = 0; i < accounts.Length; i++)
            {
                accounts[i] = new Account(i + 10 + i * 2);
            }
            activeAccount = accounts[0];
        }

        private static void SelectAccount()
        {
            int selectedOption = 0;
            bool optionSelected = false;
            string[] accountsNumber = new string[accounts.Length];
            for (int i = 0; i < accounts.Length; i++)
            {
                accountsNumber[i] = $"Conta N°{accounts[i].accountNumber}";
            }
            while (!optionSelected)
            {
                RenderMenu("Selecionar conta", accountsNumber, selectedOption);
                Console.WriteLine();
                switch (MenuNavigation(accounts.Length, ref selectedOption))
                {
                    case 0:
                        activeAccount = accounts[0];
                        Console.WriteLine($"Conta N°{accounts[0].accountNumber} selecionada");
                        AnyKeyPrompt();
                        optionSelected = true;
                        break;
                    case 1:
                        activeAccount = accounts[1];
                        Console.WriteLine($"Conta N°{accounts[1].accountNumber} selecionada");
                        AnyKeyPrompt();
                        optionSelected = true;
                        break;
                    case 2:
                        activeAccount = accounts[2];
                        Console.WriteLine($"Conta N°{accounts[2].accountNumber} selecionada");
                        AnyKeyPrompt();
                        optionSelected = true;
                        break;
                    case 3:
                        activeAccount = accounts[3];
                        Console.WriteLine($"Conta N°{accounts[3].accountNumber} selecionada");
                        AnyKeyPrompt();
                        optionSelected = true;
                        break;
                    case 4:
                        activeAccount = accounts[4];
                        Console.WriteLine($"Conta N°{accounts[5].accountNumber} selecionada");
                        AnyKeyPrompt();
                        optionSelected = true;
                        break;
                }
            }
        }

        public static void RenderMenu(string title, string[] options, int selectedOption)
        {
            Header(title);
            for (int i = 0; i < options.Length; i++)
            {
                string prefix = (i == selectedOption) ? "   >" : "    ";
                Console.WriteLine(prefix + options[i]);
            }
        }

        public static int MenuNavigation(int menuLength, ref int selectedOption)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.UpArrow)
                selectedOption = (selectedOption == 0) ? menuLength - 1 : selectedOption - 1;
            else if (key.Key == ConsoleKey.DownArrow)
                selectedOption = (selectedOption == menuLength - 1) ? 0 : selectedOption + 1;
            else if (key.Key == ConsoleKey.Enter)
                return selectedOption;
            return -1;
        }

        public static void Header(string title)
        {
            int padding = (menuWidth - title.Length) / 2;
            Console.Clear();
            Console.WriteLine("┌" + new string('─', menuWidth) + "┐");
            Console.WriteLine("│" + title.PadLeft(padding + title.Length).PadRight(menuWidth) + "│");
            Console.WriteLine("└" + new string('─', menuWidth) + "┘");
            Console.WriteLine();
        }

        public static void AnyKeyPrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public static bool LeavePrompt()
        {
            Console.Clear();
            Console.Write("Você realmente deseja sair? (S/N) -> ");
            string userInput = Console.ReadLine()!;
            while (userInput != "S" && userInput != "N" && userInput != "s" && userInput != "n" || (userInput == null))
            {
                Console.Write("Opção inválida, tente novamente -> ");
                userInput = Console.ReadLine()!;
            }
            return userInput.ToUpper()[0] == 'S';
        }

    }
}
