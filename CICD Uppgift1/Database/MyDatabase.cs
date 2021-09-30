using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace CICD_Uppgift1.Database
{
    class MyDatabase : DbContext
    {
        private static string DatabaseFile { get; } = "SalarySystem.db"; //<-- databasens namn

        public DbSet<Models.UserAccount> UserAccounts { get; set; }
        public DbSet<Models.AdminAccount> AdminAccounts { get; set; }

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
