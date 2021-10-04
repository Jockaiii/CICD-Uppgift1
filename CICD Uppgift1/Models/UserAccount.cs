using System.Linq;

namespace CICD_Uppgift1.Models
{
    internal class UserAccount : Account
    {
        protected internal override bool GetAccountDetails(string userName)
        {
            var accountQuery = Database.MyDatabase.Db.UserAccounts.Where(w => w.UserName.Contains(userName)).ToList();

            if (accountQuery.Count > 0)
            {
                Balance = accountQuery[0].Balance;
                Salary = accountQuery[0].Salary;
                Role = accountQuery[0].Role;
                return true;
            }
            return false;
        }

        public static void RequestSalaryChange(string userName, int salary)
        {
            Views.ConsoleView.RequestPolls.Add(new RequestPoll { Username = userName, Salary = salary });
        }

        public static void RequestRoleChange(string userName, string role)
        {
            Views.ConsoleView.RequestPolls.Add(new RequestPoll { Username = userName, Role = role });
        }

        public static void RemoveAccount(string userName)
        {
        }
    }
}
