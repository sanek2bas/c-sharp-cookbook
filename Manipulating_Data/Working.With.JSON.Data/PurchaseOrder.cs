namespace Working.With.JSON.Data
{
    public class PurchaseOrder
    {
        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Terms { get; set; }

        public string POC { get; set; }

        public PurchaseOrderStatus Status { get; set; }

        public Dictionary<string, string> AdditionalInfo { get; set; }

        public List<PurchaseItem> Items { get; set; }
    }
}
