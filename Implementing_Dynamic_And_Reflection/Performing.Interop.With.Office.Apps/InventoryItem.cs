﻿namespace Performing.Interop.With.Office.Apps
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
    }
}
