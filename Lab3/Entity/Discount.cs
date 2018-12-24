using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Entity
{
    public class Discount
    {
        public int Id { get; set; }
        public int Percent { get; set; }
        public DateTime Validity { get; set; }
        public int? ClientId { get; set; }
    }
}
