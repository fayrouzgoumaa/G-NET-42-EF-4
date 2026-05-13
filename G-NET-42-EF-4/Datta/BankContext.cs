using G_NET_42_EF_4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace G_NET_42_EF_4.Datta
{
    internal class BankContext:DbContext
    {
        public DbSet<Branch> Branches { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<AccountCustomer> AccountCustomers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=FAYROUZGOUMAA;Database=BankSystemDB;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One-To-One
            // Branch -> Manager

            modelBuilder.Entity<Branch>()
                .HasOne(b => b.Manager)
                .WithOne(m => m.Branch)
                .HasForeignKey<Manager>(m => m.BranchCode);

            // One-To-Many
            // Branch -> Accounts

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Branch)
                .WithMany(b => b.Accounts)
                .HasForeignKey(a => a.BranchCode);

            // One-To-Many
            // Account -> Transactions

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Account)
                .WithMany(a => a.Transactions)
                .HasForeignKey(t => t.AccountNumber);

            // Composite Primary Key

            modelBuilder.Entity<AccountCustomer>()
                .HasKey(ac => new
                {
                    ac.AccountNumber,
                    ac.CustomerId
                });

            // AccountCustomer -> Account

            modelBuilder.Entity<AccountCustomer>()
                .HasOne(ac => ac.Account)
                .WithMany(a => a.AccountCustomers)
                .HasForeignKey(ac => ac.AccountNumber);

            // AccountCustomer -> Customer

            modelBuilder.Entity<AccountCustomer>()
                .HasOne(ac => ac.Customer)
                .WithMany(c => c.AccountCustomers)
                .HasForeignKey(ac => ac.CustomerId);

            // Seed Data

            modelBuilder.Entity<Branch>().HasData(

                new Branch
                {
                    Code = 1,
                    Name = "Cairo Branch",
                    Address = "Nasr City",
                    PhoneNumber = "01123450001"
                },

                new Branch
                {
                    Code = 2,
                    Name = "Alex Branch",
                    Address = "Smouha",
                    PhoneNumber = "01123456782"
                }

            );

            modelBuilder.Entity<Manager>().HasData(

                new Manager
                {
                    Id = 1,
                    FullName = "Fayrouz Goumaa",
                    Email = "Fayrouz@bank.com",
                    PhoneNumber = "01111111111",
                    HireDate = new DateTime(2020, 1, 1),
                    BranchCode = 1
                },

                new Manager
                {
                    Id = 2,
                    FullName = "Faten Goumaa",
                    Email = "Faten@bank.com",
                    PhoneNumber = "01222222222",
                    HireDate = new DateTime(2021, 5, 10),
                    BranchCode = 2
                }

            );
        }
        }
}
