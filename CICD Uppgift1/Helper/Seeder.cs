using System;
using System.Collections.Generic;
using System.Text;

namespace CICD_Uppgift1.Helper
{
    class Seeder
    {
        private static List<Models.AdminAccount> AdminAccounts = new List<Models.AdminAccount>
        {
            new Models.AdminAccount { UserName = "admin1", Password = "admin1234", Balance = 999999, Salary = 999999, Role = "Administrator"}
        };

        private static List<Models.UserAccount> userAccounts = new List<Models.UserAccount>
        {
            new Models.UserAccount { UserName = "Hej"}
        };
    }
}
