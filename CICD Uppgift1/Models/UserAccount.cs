using System.Linq;

namespace CICD_Uppgift1.Models
{
    class UserAccount : Account
    {
        public override void GetAccountDetails(string userName)
        {
            using var db = new Database.MyDatabase();

            var accountQuery = db.UserAccounts.Where(w => w.UserName.Contains(userName)).ToList();

            Balance = accountQuery[0].Balance;
            Salary = accountQuery[0].Salary;
            Role = accountQuery[0].Role;
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
