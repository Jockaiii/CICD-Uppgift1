using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CICD_Uppgift1.Models
{
    class UserAccount : Account
    {
        public override void GetAccountDetails(string userName)
        {
            List<Account> logList = new List<Account>();

            using var db = new Database.MyDatabase();
            var accountQuery = from l in db.UserAccounts.Include("Username").Include("Balance").Include("Salary").Include("Role")
                               where l.UserName == userName
                               select l;

            foreach (var data in accountQuery)
                logList.Add(data);

            foreach (var log in logList)

                Console.WriteLine($"Username: {log.UserName}\nBalance: {log.Balance}\nSalary: {log.Salary}\nRole: {log.Role}");
            //Balance = accountQuery.Balance;
            //Salary = accountQuery.Salary;
            //Role = accountQuery.Role;
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
