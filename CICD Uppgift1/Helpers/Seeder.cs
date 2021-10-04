using System.Collections.Generic;
using System.Linq;

namespace CICD_Uppgift1.Helpers
{
    internal static class Seeder
    {
        /// <summary>
        /// Metod som lägger in data in databasens tables.
        /// </summary>
        public static void TablesInsert()
        {
            using var db = new Database.MyDatabase();
            if(!db.UserAccounts.Any())
            {
                db.UserAccounts.AddRange(userAccounts);
            }
            if(!db.AdminAccounts.Any())
            {
                db.AdminAccounts.AddRange(adminAccounts);
            }
            db.SaveChanges();
        }

        private static readonly List<Models.AdminAccount> adminAccounts = new List<Models.AdminAccount>
        {
            new Models.AdminAccount { UserName = "admin1", Password = "admin1234", Balance = 999999, Salary = 999999, Role = "Administrator"}
        };

        private static readonly List<Models.UserAccount> userAccounts = new List<Models.UserAccount>
        {
            new Models.UserAccount { UserName = "joakimandersson", Password = "joakimandersson", Balance = 1000000, Salary = 1000000, Role = "LiterallyAGod"},
            new Models.UserAccount { UserName = "rickardhallberg", Password = "rickardhallberg", Balance = 1000000, Salary = 1000000, Role = "LiterallyAGod"},
        };
    }
}
