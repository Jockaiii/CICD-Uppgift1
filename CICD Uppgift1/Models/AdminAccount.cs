using System;
using System.Collections.Generic;
using System.Linq;

namespace CICD_Uppgift1.Models
{
    internal class AdminAccount : Account
    {
        protected internal override bool GetAccountDetails(string userName)
        {
            using var db = new Database.MyDatabase();

            var accountQuery = db.AdminAccounts.Where(w => w.UserName.Contains(userName)).ToList();

            if (accountQuery.Count > 0)
            {
                Balance = accountQuery[0].Balance;
                Salary = accountQuery[0].Salary;
                Role = accountQuery[0].Role;
                return true;
            }
            return false;
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
            foreach(var item in Views.ConsoleView.RequestPolls)
            {
                Console.WriteLine(item);
            }
        }

        public static void AdvanceSalarySystem()
        {
            using var db = new Database.MyDatabase();
            foreach (var user in db.UserAccounts)
            {
                user.Balance += user.Salary;
            }
            db.SaveChanges();
        }

        public static void CreateLocalAccount(string username, string password, int balance, int salary, string role)
        {
            using var db = new Database.MyDatabase();
            if(db.UserAccounts.Where(x => x.UserName == username).ToList().Count>0)
            {
                Console.WriteLine("That Username already exists.");
            }
            else
            {
                db.UserAccounts.AddRange(new UserAccount { UserName = username, Password = password, Balance = balance, Salary = salary, Role = role });
                db.SaveChanges();
            }
        }
    }
}
