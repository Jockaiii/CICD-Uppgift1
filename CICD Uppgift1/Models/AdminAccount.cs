using System;
using System.Collections.Generic;
using System.Linq;

namespace CICD_Uppgift1.Models
{
    class AdminAccount : Account
    {
        public override void GetAccountDetails(string userName)
        {
            List<Account> logList = new List<Account>();

            using var db = new Database.MyDatabase();
            var accountQuery = from l in db.AdminAccounts
                               where l.UserName == userName
                               select l;

            Console.WriteLine(accountQuery);
            //Balance = accountQuery.Balance;
            //Salary = accountQuery.Salary;
            //Role = accountQuery.Role;
        }

        public static void CheckAccounts()
        {
            List<Account> accountList = new List<Account>();

            using var db = new Database.MyDatabase();
            var accountQuery = from l in db.UserAccounts
                               where l.Balance == l.Balance
                               orderby l.UserName descending
                               select l;

            foreach (var log in accountQuery)
                accountList.Add(log);
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
