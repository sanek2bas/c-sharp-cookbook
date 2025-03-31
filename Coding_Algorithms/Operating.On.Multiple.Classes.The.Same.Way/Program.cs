internal class Program
{
    private static void Main(string[] args)
    {
        var invoices = GetInvoices();
        foreach (var invoice in invoices)
        {
            if(!invoice.IsApproved())
                continue;
            invoice.CalculateBalance();
            invoice.PopulateLineItems();
            invoice.SetDueDate();
        }
    }

    private static IEnumerable<IInvoice> GetInvoices()
    {
        return new List<IInvoice>
        {
            new BankInvoice(),
            new EnterpriseInvoice(),
            new GovernmentInvoice()
        };
    }
}