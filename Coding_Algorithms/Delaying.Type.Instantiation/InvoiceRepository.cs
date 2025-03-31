public interface IInvoiceRepository
{
    void AddInvoiceCategory(string category);
}

public sealed class InvoiceRepository : IInvoiceRepository
{
    public InvoiceRepository()
    {
        Console.WriteLine("InvoiceRepository Instantiated.");
    }
    
    public void AddInvoiceCategory(string category)
    {
        Console.WriteLine($"for category: {category}");
    }
}