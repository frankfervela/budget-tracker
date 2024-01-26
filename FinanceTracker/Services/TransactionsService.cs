using FinanceTracker.Models;

namespace FinanceTracker.Services;

public class TransactionsService
{
    public List<DebitCardTransaction>? transactions { get; set; }
    
    public TransactionsService(CsvService csvService)
    {
        transactions = Task.Run(csvService.GetDebitCardTransactionsAsync).Result;
    }
    
    
}