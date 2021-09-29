using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace CICD_Uppgift1.Database
{
    class Database : DbContext
    {
        private static string DatabaseFile { get; } = "SalarySystem.db"; //<-- databasens namn

        public DbSet<Models.Account> UserAccount { get; set; }
        public DbSet<Models.AdminAccount> AdminAccount { get; set; }

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
