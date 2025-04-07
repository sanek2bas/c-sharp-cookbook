using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instantiating.Type.Members.With.Reflection
{
    public class InventoryItem
    {
        [Column("Part #")]
        public string PartNumber { get; set; }

        [Column("Name")]
        public string Description { get; set; }

        [Column("Amount")]
        public int Count { get; set; }

        [Column("Price")]
        public decimal ItemPrice { get; set; }

        [Column("Total")]
        public decimal CalculateTotal()
        {
            return ItemPrice * Count;
        }
    }
}
