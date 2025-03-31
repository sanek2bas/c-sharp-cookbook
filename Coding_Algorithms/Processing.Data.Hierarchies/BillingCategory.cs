public class BillingCategory
{
    public int ID { get; set; }
    
    public string Name { get; set; }
    
    public int? Parent { get; set; } = 0;
}