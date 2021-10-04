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
                Balance = accountQuery[0].Balance;
                Salary = accountQuery[0].Salary;
                Role = accountQuery[0].Role;
                return true;
            }
            return false;
        }

        public void RequestSalaryChange(string userName)
        {
        }

        public void RequestRoleChange(string userName)
        {
        }

        public void RemoveAccount(string userName)
        public void RemoveAccount(string userName)
        {
        }
    }
}
