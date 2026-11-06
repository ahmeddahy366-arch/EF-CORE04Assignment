using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE04Assignment.Model
{
    public class BankDbcontext:DbContext
    {
        public DbSet<customer> customers { get; set; }
        public DbSet<account> accounts { get; set; }
        public DbSet<transaction> transactions { get; set; }
        public DbSet<manager> managers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<AccountCustomer> AccountCustomers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=National_Bank;Trusted_Connection=true;trustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
