using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CICD_Uppgift1.Models
{
    public class AdminAccount : Account
    {
        public static void CheckAccounts()
        {
            List<Account> accountList = new List<Account>();

            using var db = new Database.Database();
            var accountQuery = from l in db.UserAccount.Include("UserName").Include("Balance").Include("Salary").Include("Role")
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
