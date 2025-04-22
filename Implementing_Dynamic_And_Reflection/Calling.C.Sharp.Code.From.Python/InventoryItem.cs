namespace Calling.C.Sharp.Code.From.Python
{
    public class InventoryItem
    {
        public InventoryItem(
            string partNumber, string description,
            int count, decimal itemPrice)
        {
            PartNumber = partNumber;
            Description = description;
            Count = count;
            ItemPrice = itemPrice;
        }

        [Column("Part #")]
        public string PartNumber { get; set; }


        [Column("Name")]
        public string Description { get; set; }


        [Column("Amount")]
        public int Count { get; set; }


        [Column("Price", Format = "{0:c}")]
        public decimal ItemPrice { get; set; }
    }
}
