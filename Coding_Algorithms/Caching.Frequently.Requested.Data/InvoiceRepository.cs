public interface IInvoiceRepository
{
    IList<InvoiceCategory> GetInvoiceCategories();
}

public class InvoiceRepository : IInvoiceRepository
{
    private static IList<InvoiceCategory> invoiceCategories;

    public IList<InvoiceCategory> GetInvoiceCategories()
    {
        if (invoiceCategories == null)
            invoiceCategories = GetInvoiceCategoriesFromDB();
        return invoiceCategories;
    }
    
    private IList<InvoiceCategory> GetInvoiceCategoriesFromDB()
    {
        return new List<InvoiceCategory>
        {
            new InvoiceCategory { ID = 1, Name = "Government" },
            new InvoiceCategory { ID = 2, Name = "Financial" },
            new InvoiceCategory { ID = 3, Name = "Enterprise" }
        };
    }
}