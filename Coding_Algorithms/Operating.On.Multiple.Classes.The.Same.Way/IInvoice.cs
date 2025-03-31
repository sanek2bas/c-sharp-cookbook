public interface IInvoice
{
    bool IsApproved();

    void PopulateLineItems();
    
    void CalculateBalance();
    
    void SetDueDate();
}