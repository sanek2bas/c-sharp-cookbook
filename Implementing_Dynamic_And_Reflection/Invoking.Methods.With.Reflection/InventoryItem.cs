namespace Invoking.Methods.With.Reflection
{
    public class InventoryItem
    {
        [Column("Part #")]
        public string PartNumber { get; set; }

        [Column("Name")]
        public string Description { get; set; }

        [Column("Amount")]
        public int Count { get; set; }

        [Column("Price", Format = "{0:c}")]
        public decimal ItemPrice { get; set; }

        [Column("Total", Format = "{0:c}")]
        public decimal CalculateTotal()
        {
            return ItemPrice * Count;
        }
    }
}
