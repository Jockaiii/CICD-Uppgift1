using System;
using System.Collections.Generic;
using System.Linq;

namespace CICD_Uppgift1.Models
{
    class AdminAccount : Account
    {
        public override void GetAccountDetails(string userName)
        {
            using var db = new Database.MyDatabase();

            var accountQuery = db.AdminAccounts.Where(w => w.UserName.Contains(userName)).ToList();

            Balance = accountQuery[0].Balance;
            Salary = accountQuery[0].Salary;
            Role = accountQuery[0].Role;
        }

        public static void CheckAccounts()
        {
            using var db = new Database.MyDatabase();

            var accountQuery = db.UserAccounts.ToList();

            foreach (var account in accountQuery)
                Console.WriteLine(account);
        }

        public static void CheckAccountRequests()
        {
        }

        public static void AdvanceSalaraySystem()
        {
        }

        public static void CreateLocalAccount()
        {
        }
    }
}
