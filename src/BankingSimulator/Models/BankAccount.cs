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
}
