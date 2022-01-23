using Business.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class Context : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Law> Laws { get; set; }
        public DbSet<PaymentDoс> PaymentDoсs { get; set; }
        public DbSet<Service> Services { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureSchema(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureSchema(ModelBuilder modelBuilder)
        {
            ConfigureUnits(modelBuilder);
        }

        private void ConfigureUnits(ModelBuilder modelBuilder)
        {
        }
    }
}
