using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace CICD_Uppgift1.Database
{
    internal class MyDatabase : DbContext
    {
        private static string DatabaseFile { get; } = "SalarySystem.db"; //<-- databasens namn
        internal static MyDatabase Db { get; set; } = new MyDatabase();
        internal DbSet<Models.UserAccount> UserAccounts { get; set; } // Eventuellt flytta in i en tabell? och sedan kolla ifall UserName == admin1 osv.
        internal DbSet<Models.AdminAccount> AdminAccounts { get; set; }
        internal DbSet<Models.RequestPoll> RequestPolls { get; set; }

        /// <summary>
        /// Metod som hanterar path till databasen samt data source
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
    }
}