using CICD_Uppgift1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace CICD_Uppgift1.Database
{
    internal class MyDatabase : DbContext
    {
        private static string DatabaseFile { get; } = "SalarySystem.db"; //<-- The name of the database file.
        internal static MyDatabase Db { get; set; } = new MyDatabase(); // A global property for a instance of the databse (DbContext functions etc)
        internal DbSet<Models.UserAccount> UserAccounts { get; set; } // Used for EF to create UserAccounts table in the database.
        internal DbSet<Models.AdminAccount> AdminAccounts { get; set; } // Used for EF to create AdminAccounts table in the database.
        internal DbSet<Models.RequestPoll> RequestPolls { get; set; } // Used for EF to create RequestPolls table in the database.

        /// <summary>
        /// Method that handles the path to the database aswell as the data source
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); //<-- My documents
            path = Path.Combine(path, "VSDatabase");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, DatabaseFile);

            optionsBuilder.UseSqlite("Data Source = " + path + ";");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequestPoll>().HasKey(c => new { c.Username, c.Salary, c.Role });
        }
    }
}