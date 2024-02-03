namespace FinanceTracker.Models;

public class UserTransaction
{
    public UserTransaction(string transactionName, double amount, bool isRecurrent, DateTime? recurrentDate, string category)
    {
        TransactionName = transactionName;
        Amount = amount;
        IsRecurrent = isRecurrent;
        RecurrentDate = recurrentDate;
        Category = category;
    }

    public string TransactionName { get; set; }

    public double Amount { get; set; }
    public bool IsRecurrent { get; set; }
    public DateTime? RecurrentDate { get; set; }
    public string Category { get; set; }
}