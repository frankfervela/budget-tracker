using System.Globalization;
using System.Text.RegularExpressions;
using CsvHelper;
using CsvHelper.Configuration;
using FinanceTracker.Models;

namespace FinanceTracker.Services;

public class CsvService
{
    private string PathToCsvFile { get; set; }
    public CsvService(string pathToCsvFile)
    {
        PathToCsvFile = pathToCsvFile;
    }
    
    public async Task<List<DebitCardTransaction>> GetDebitCardTransactionsAsync()
    {
       //read the csv file using the path
         //parse the csv file into a list of DebitCardTransaction objects
            //return the list
        var transactions = new List<DebitCardTransaction>();
        using var reader = new StreamReader(PathToCsvFile);
        while (!reader.EndOfStream)
        {
            var line = await reader.ReadLineAsync();

            if (line is not null && line.StartsWith("Details"))
            {
                continue;
            }

            line = line?.Replace(",,", "");
            
            var regex = new Regex("\\\"(.*?)\\\"");
            var output = regex.Replace(line, m => m.Value.Replace(',',' '));
            
            var values = output.Split(',');

            var transactionDetail = values[0];
            var transactionPostingDate = DateTime.Parse(values[1]);
            var transactionDescription = values[2].Equals("") ? "" : values[2].Replace("\"", "");
            var transactionAmount = values[3].Equals("") ? 0 : decimal.Parse(values[3], NumberStyles.Currency);
            var transactionType = values[4].Equals("") ? "" : values[4];
            var transactionBalance = values[5].Equals(" ") ? 0 : decimal.Parse(values[5], NumberStyles.Currency);
            
            transactions.Add(new DebitCardTransaction
            {
                Detail = transactionDetail,
                PostingDate = transactionPostingDate,
                Description = transactionDescription,
                Amount = transactionAmount,
                Type = transactionType,
                Balance = transactionBalance
            });    
            
            
            
        }
        return transactions;
    }

}