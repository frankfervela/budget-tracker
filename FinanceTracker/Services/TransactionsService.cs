using FinanceTracker.Models;

namespace FinanceTracker.Services;

public class TransactionsService
{
    public List<DebitCardTransaction>? transactions { get; set; }
    public List<UserTransaction>? userInputTransactions { get; set; }
    
    public TransactionsService(CsvService csvService)
    {
        transactions = Task.Run(csvService.GetDebitCardTransactionsAsync).Result;
        userInputTransactions = new List<UserTransaction>();
    }
    
    
}