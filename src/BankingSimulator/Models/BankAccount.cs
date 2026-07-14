using System.Collections.Generic;

namespace BankingSimulator.Models;

public class BankAccount
{
    private readonly List<Transaction> _transactions = new();

    public BankAccount(string ownerName, string accountNumber)
    {
        if (string.IsNullOrWhiteSpace(ownerName))
        {
            throw new ArgumentException("Owner name is required.", nameof(ownerName));
        }

        if (string.IsNullOrWhiteSpace(accountNumber))
        {
            throw new ArgumentException("Account number is required.", nameof(accountNumber));
        }

        OwnerName = ownerName;
        AccountNumber = accountNumber;
    }

    public string OwnerName { get; }
    public string AccountNumber { get; }
    public decimal Balance { get; private set; }
    public IReadOnlyList<Transaction> Transactions => _transactions;

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be greater than zero.");
        }

        Balance += amount;
        _transactions.Add(new Transaction("Deposit", amount, DateTime.UtcNow, Balance));
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be greater than zero.");
        }

        if (amount > Balance)
        {
            return false;
        }

        Balance -= amount;
        _transactions.Add(new Transaction("Withdrawal", amount, DateTime.UtcNow, Balance));
        return true;
    }
}
