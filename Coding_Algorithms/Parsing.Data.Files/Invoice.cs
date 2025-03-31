namespace Parsing.Data.Files
{
    public class Invoice
    {
        public string Customer { get; set; }

        public DateTime Created { get; set; }

        public IList<InvoiceItem> Items { get; set; }
    }
}
