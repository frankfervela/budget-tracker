namespace FinanceTracker.Services;

public class CategoriesService
{
    public List<string> CategoryList { get; set; } = new()
    {
        "Groceries",
        "Restaurants",
        "Gas",
        "Entertainment",
        "Clothing",
        "Home",
        "Health",
        "Miscellaneous"
    };
}