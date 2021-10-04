using System;
using System.Linq;

namespace CICD_Uppgift1.Models
{
    internal class UserAccount : Account
    {
        protected internal override bool GetAccountDetails(string userName)
        {
            using var db = new Database.MyDatabase();
            var accountQuery = db.UserAccounts.Where(w => w.UserName.Contains(userName)).ToList();

            if (accountQuery.Count > 0)
            {
                UserName = accountQuery[0].UserName;
                Password = accountQuery[0].Password;
                Balance = accountQuery[0].Balance;
                Salary = accountQuery[0].Salary;
                Role = accountQuery[0].Role;
                return true;
            }
            return false;
        }

        public static void RequestSalaryChange(string userName, int salary, int oldSalary)
        {
            Views.ConsoleView.RequestPolls.Add(new RequestPoll(userName, salary, oldSalary));
        }

        public static void RequestRoleChange(string userName, string role, string oldRole)
        {
            Views.ConsoleView.RequestPolls.Add(new RequestPoll(userName, role, oldRole));
        }

        public static void RemoveAccount(string userName)
        {
            using var db = new Database.MyDatabase();

            var x = db.UserAccounts.Select(p => p.UserName);
            foreach( var item in x)
            {
                var y = db.UserAccounts.Where(p => p.UserName == userName).FirstOrDefault();
                if(y != null)
                {
                    db.UserAccounts.Remove(y);
                    db.SaveChanges();
                }
            }
        }
    }
}