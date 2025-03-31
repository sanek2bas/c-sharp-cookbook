public sealed class BankInvoice : IInvoice
{
    public void CalculateBalance()
    {
        Console.WriteLine("Calculating balance for BankInvoice.");
    }
    
    public bool IsApproved()
    {
        Console.WriteLine("Checking approval for BankInvoice.");
        return true;
    }

    public void PopulateLineItems()
    {
        Console.WriteLine("Populating items for BankInvoice.");
    }

    public void SetDueDate()
    {
        Console.WriteLine("Setting due date for BankInvoice.");
    }
}