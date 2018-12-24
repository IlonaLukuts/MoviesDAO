using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Entity;
using System.Data.Entity;

namespace Entity
{
    class Program
    {
        class DataContext : DbContext
        {
            public DataContext() : base("DBMovies")
            {

            }

            public DbSet<Administrator> Admins { get; set; }
            public DbSet<Client> Clients { get; set; }
            public DbSet<Comment> Comments { get; set; }
            public DbSet<Discount> Discounts { get; set; }
            public DbSet<Movie> Movies { get; set; }
            public DbSet<Order> Orders { get; set; }
        }
        static void Main(string[] args)
        {
            using (DataContext datacontext = new DataContext())
            {
                datacontext.Admins.ToList();
                datacontext.Clients.ToList();
                datacontext.Comments.ToList();
                datacontext.Discounts.ToList();
                datacontext.Movies.ToList();
                datacontext.Orders.ToList();
            }
        }
    }
}
