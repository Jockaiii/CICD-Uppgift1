using System.Collections.Generic;
using System.Linq;

namespace CICD_Uppgift1.Models
{
    class UserAccount : Account
    {
        public override bool GetAccountDetails(string userName)
        {
            using var db = new Database.MyDatabase();

            var accountQuery = db.UserAccounts.Where(w => w.UserName.Contains(userName)).ToList();

            if (accountQuery.Count > 0)
            {
                Balance = accountQuery[0].Balance;
                Salary = accountQuery[0].Salary;
                Role = accountQuery[0].Role;
                return true;
            }
            return false;
        }

        public static void RequestSalaryChange()
        {
        }

        public static void RequestRoleChange()
        {
        }

        public static void RemoveAccount()
        {
        }
    }
}
