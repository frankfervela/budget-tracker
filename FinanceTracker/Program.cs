using FinanceTracker.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<CsvService>(x => new CsvService(@"C:\Users\fafv5\source\repos\FinanceTracker\FinanceTracker\csv files\debit_transactions.csv"));
builder.Services.AddScoped<TransactionsService>(sb => new TransactionsService(sb.GetRequiredService<CsvService>()));
builder.Services.AddScoped<CategoriesService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();