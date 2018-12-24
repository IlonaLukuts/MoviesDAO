using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Entity
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Producer { get; set; }
        public string Genre { get; set; }
        public string Actors { get; set; }
        public int Duration { get; set; }
    }
}
