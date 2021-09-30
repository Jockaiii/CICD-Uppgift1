using System;
using System.Collections.Generic;
using System.Text;

namespace CICD_Uppgift1.Helpers
{
    class Seeder
    {
        /// <summary>
        /// Metod som lägger in objekt (data) in i tabellen AdminAccounts.
        /// </summary>
        public static Database.MyDatabase db = new Database.MyDatabase();
        public static void AdminAccountsInsert()
        {
            db.UserAccounts.AddRange(userAccounts);
        }

        /// <summary>
        /// Metod som lägger in objekt (data) in i tabellen UserAccounts.
        /// </summary>
        public static void UserAccountsInsert()
        {
            db.AdminAccounts.AddRange(AdminAccounts);
        }

        private static List<Models.AdminAccount> AdminAccounts = new List<Models.AdminAccount>
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
