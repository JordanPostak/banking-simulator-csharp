using BankingSimulator.Models;

namespace BankingSimulator.UI;

public class ConsoleMenu
{
    private readonly BankAccount _account;

    public ConsoleMenu(BankAccount account)
    {
        _account = account;
    }

    public void Run()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("=================================");
            Console.WriteLine("      Banking Simulator");
            Console.WriteLine("=================================");
            Console.WriteLine();
            Console.WriteLine($"Account: {_account.OwnerName}");
            Console.WriteLine($"Balance: {_account.Balance:C}");
            Console.WriteLine();
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. View Balance");
            Console.WriteLine("4. View Transaction History");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
            Console.Write("Select an option: ");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    HandleDeposit();
                    break;
                case "2":
                    HandleWithdraw();
                    break;
                case "3":
                    HandleViewBalance();
                    break;
                case "4":
                    HandleViewTransactionHistory();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private void HandleDeposit()
    {
        Console.Write("Enter amount to deposit: ");
        var input = Console.ReadLine();

        try
        {
            if (decimal.TryParse(input, out var amount))
            {
                _account.Deposit(amount);
                Console.WriteLine("Deposit successful.");
            }
            else
            {
                Console.WriteLine("Invalid amount.");
            }
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine();
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    private void HandleWithdraw()
    {
        Console.Write("Enter withdrawal amount: ");

        try
        {
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.WriteLine("Invalid amount.");
            }
            else
            {
                bool success = _account.Withdraw(amount);

                if (success)
                {
                    Console.WriteLine("Withdrawal successful!");
                    Console.WriteLine($"New Balance: {_account.Balance:C}");
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                }
            }
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine();
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    private void HandleViewBalance()
    {
        Console.WriteLine();
        Console.WriteLine($"Account: {_account.OwnerName}");
        Console.WriteLine($"Account Number: {_account.AccountNumber}");
        Console.WriteLine($"Current Balance: {_account.Balance:C}");

        Console.WriteLine();
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    private void HandleViewTransactionHistory()
    {
        Console.WriteLine();
        Console.WriteLine("Transaction History");
        Console.WriteLine("-------------------");

        if (_account.Transactions.Count == 0)
        {
            Console.WriteLine("No transactions found.");
        }
        else
        {
            foreach (var transaction in _account.Transactions)
            {
                Console.WriteLine(
                    $"{transaction.Date:g} | " +
                    $"{transaction.Type,-10} | " +
                    $"{transaction.Amount,10:C} | " +
                    $"Balance: {transaction.BalanceAfterTransaction:C}");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}