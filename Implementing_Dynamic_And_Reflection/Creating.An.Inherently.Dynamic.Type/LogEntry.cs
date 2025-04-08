using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creating.An.Inherently.Dynamic.Type
{
    public class LogEntry
    {
        [Column("Log Date", Format = "{0:yyyy-MM-dd hh:mm}")]
        public DateTime CreatedAt { get; set; }

        [Column("Severity")]
        public string Type { get; set; }

        [Column("Location")]
        public string Where { get; set; }

        [Column("Message")]
        public string Description { get; set; }
    }
}
