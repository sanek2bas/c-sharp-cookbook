using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producing.XML
{
    public class PurchaseItem
    {
        public string SerialNumber { get; set; }

        public string Description { get; set; }

        public float Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
