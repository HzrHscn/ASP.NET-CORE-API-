using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-5Q0ND8N;Database=apiDb;integrated security=true;Trusted_Connection=true;TrustServerCertificate=True");
        }

        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RepairRequest> RepairRequests { get; set; }

        // DbSet'e eklediğimiz metod
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<Product>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.GenerateBarcode();
                }
            }

            return base.SaveChanges();
        }

    }
}
