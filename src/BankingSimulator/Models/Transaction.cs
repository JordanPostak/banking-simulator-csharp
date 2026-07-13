namespace BankingSimulator.Models;

public class Transaction
{
    public Transaction(string type, decimal amount, DateTime timestamp, decimal balanceAfterTransaction)
    {
        Type = type;
        Amount = amount;
        Timestamp = timestamp;
        BalanceAfterTransaction = balanceAfterTransaction;
    }

    public string Type { get; }
    public decimal Amount { get; }
    public DateTime Date { get; }
    public decimal BalanceAfterTransaction { get; }
}
