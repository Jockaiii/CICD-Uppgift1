using System.Collections.Generic;

namespace CICD_Uppgift1.Helpers
{
    class Seeder
    {
        /// <summary>
        /// Metod som lägger in data in databasens tables.
        /// </summary>
        public static void TablesInsert()
        {
            using var db = new Database.MyDatabase();
            db.UserAccounts.AddRange(userAccounts);
            db.AdminAccounts.AddRange(adminAccounts);
            db.SaveChanges();
        }

        private static List<Models.AdminAccount> adminAccounts = new List<Models.AdminAccount>
        {
            new Models.AdminAccount { UserName = "admin1", Password = "admin1234", Balance = 999999, Salary = 999999, Role = "Administrator"}
        };

        private static List<Models.UserAccount> userAccounts = new List<Models.UserAccount>
        {
            new Models.UserAccount { UserName = "joakimandersson", Password = "joakimandersson", Balance = 1000000, Salary = 1000000, Role = "LiterallyAGod"},
            new Models.UserAccount { UserName = "rickardhallberg", Password = "rickardhallberg", Balance = 1000000, Salary = 1000000, Role = "LiterallyAGod"},
        };
    }
}
