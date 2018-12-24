using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Kinotheatr { get; set; }
        public bool IsPayed { get; set; }
        public int? ClientId { get; set; }
        public int? MovieId { get; set; }
    }
}
