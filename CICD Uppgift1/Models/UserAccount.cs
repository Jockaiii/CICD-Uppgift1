using System.Linq;

namespace CICD_Uppgift1.Models
{
    internal class UserAccount : Account
    {
        /// <summary>
        ///  method responsible for gathering AccountData after sucessful login.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>True or false dependent on if account data was found or not.</returns>
        protected internal override bool GetAccountDetails(string userName)
        {
            var accountQuery = Database.MyDatabase.Db.UserAccounts.Where(w => w.UserName.Contains(userName)).ToList();

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

        /// <summary>
        /// Method responsible for creating and adding a salary requestpoll to the database.
        /// </summary>
        /// <param name="userName">username of the account with the request</param>
        /// <param name="salary">the salary of which the user wants to request</param>
        /// <param name="oldSalary">the current salary the user has</param>
        public static void RequestSalaryChange(string userName, int salary, int oldSalary)
        {
            Database.MyDatabase.Db.RequestPolls.Add(new RequestPoll(userName, salary, oldSalary, "",""));
            Database.MyDatabase.Db.SaveChanges();
        }

        /// <summary>
        /// Method responsible for creating and adding a role requestpoll to the database.
        /// </summary>
        /// <param name="userName">username of the account with the request</param>
        /// <param name="role">the role of which the user wants to request</param>
        /// <param name="oldRole">the current role the user has</param>
        public static void RequestRoleChange(string userName, string role, string oldRole)
        {
            Database.MyDatabase.Db.RequestPolls.Add(new RequestPoll(userName, 0, 0, role, oldRole));
        }

        /// <summary>
        /// Method responsible for removing the users account from the database.
        /// </summary>
        /// <param name="userName">the username of the account to be deleted</param>
        public static void RemoveAccount(string userName, string password)
        {
            var accountQuery = Database.MyDatabase.Db.UserAccounts.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
            if(accountQuery != null)
            {
                Database.MyDatabase.Db.UserAccounts.Remove(accountQuery);
                Database.MyDatabase.Db.SaveChanges();
            }
            else
                Views.ConsoleView.OutputString($"There is no account with the username: {userName} and password: {password}");
        }
    }
}