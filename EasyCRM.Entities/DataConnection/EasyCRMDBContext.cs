using EasyCRM.Entities.Employees;
using EasyCRM.Entities.Inventory;
using EasyCRM.Entities.Login;
using EasyCRM.Entities.Sales;
using EasyCRM.Entities.Service;
using EasyCRM.Entities.Settings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace EasyCRM.Entities.DataConnection
{
    public class EasyCRMDBContext : DbContext
    {
        public EasyCRMDBContext() : base("name=DbConnectionString")
        {
            Database.SetInitializer<EasyCRMDBContext>(new CreateDatabaseIfNotExists<EasyCRMDBContext>());
        }

        public DbSet<AspNetUser> AspNetUser { get; set; }

        public DbSet<Stocks> Stocks { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<InventoryItem> InventoryItem { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<CreateLineItems> LineItems { get; set; }

        public DbSet<CreateServices> Services { get; set; }

        public DbSet<Address> Address { get; set; }

    }
}
