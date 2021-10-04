using System;
using System.Linq;

namespace CICD_Uppgift1.Models
{
    internal class AdminAccount : Account
    {
        protected internal override bool GetAccountDetails(string userName)
        {
            var accountQuery = Database.MyDatabase.Db.AdminAccounts.Where(w => w.UserName.Contains(userName)).ToList();

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
            var accountQuery = Database.MyDatabase.Db.UserAccounts.ToList();

            foreach (var account in accountQuery)
                Console.WriteLine(account);
        }

        public static void CheckAccountRequests()
        {
            foreach(var poll in Views.ConsoleView.RequestPolls)
                Console.WriteLine(poll);
        }

        public static void AdvanceSalarySystem()
        {
            foreach (var user in Database.MyDatabase.Db.UserAccounts)
                user.Balance += user.Salary;
            Database.MyDatabase.Db.SaveChanges();
        }

        public static void CreateLocalAccount(string username, string password, int balance, int salary, string role)
        {
            if(Database.MyDatabase.Db.UserAccounts.Where(x => x.UserName == username).ToList().Count>0)
            {
                Console.WriteLine("That Username already exists.");
            }
            else
            {
                Database.MyDatabase.Db.UserAccounts.AddRange(new UserAccount { UserName = username, Password = password, Balance = balance, Salary = salary, Role = role });
                Database.MyDatabase.Db.SaveChanges();
            }
        }
    }
}
