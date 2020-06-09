using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consomi.Domain.Entities;
using System.Data.Entity;
using Consomi.Domain;

namespace Consomi.Data
{
    public class ConsomiContext : DbContext

    {


        public DbSet<Product> Products { get; set; }
        public DbSet<CartLine> CartLines { get; set; }
        public DbSet<Facture> Facture { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Livreur> Livreur { get; set; }
        public DbSet<Livraison> Livraison { get; set; }

        public ConsomiContext() : base("Name = DefaultConnection")
        { }
    }
}
