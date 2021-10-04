using System.Linq;

namespace CICD_Uppgift1.Models
{
    internal class AdminAccount : Account
    {
        /// <summary>
        ///  method responsible for gathering AccountData after sucessful login.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>True or false dependent on if account data was found or not.</returns>
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

        /// <summary>
        /// Method responsible for gathring the stored UserAccounts on the database. aswell as calling necessary method to output the useraccounts to the console.
        /// </summary>
        public static void CheckAccounts()
        {
            var accountQuery = Database.MyDatabase.Db.UserAccounts.ToList();
            Views.ConsoleView.OutputCheckAccounts(accountQuery);
        }

        /// <summary>
        /// Method responsible for gathering the stored AccountRequests on the database. aswell as calling necessary method to output the RequestPolls to the console.
        /// </summary>
        public static void CheckAccountRequests()
        {
            var requestQuery = Database.MyDatabase.Db.RequestPolls.ToList();
            Views.ConsoleView.OutputCheckPollRequests(requestQuery);
        }

        /// <summary>
        /// Method responsible for advancing the salary by one month for all useraccounts in the database.
        /// </summary>
        public static void AdvanceSalarySystem()
        {
            foreach (var user in Database.MyDatabase.Db.UserAccounts)
                user.Balance += user.Salary;
            Database.MyDatabase.Db.SaveChanges();
        }

        /// <summary>
        /// Method responsible for creating a local useraccount.
        /// </summary>
        /// <param name="username">name of the local account</param>
        /// <param name="password">password of the local account</param>
        /// <param name="balance">balance of the local account</param>
        /// <param name="salary">salary of the local account</param>
        /// <param name="role">role of the local account</param>
        public static void CreateLocalAccount(string username, string password, int balance, int salary, string role)
        {
            if(Database.MyDatabase.Db.UserAccounts.Where(x => x.UserName == username).ToList().Count>0)
                Views.ConsoleView.OutputString("That Username already exists.");
            else
            {
                Database.MyDatabase.Db.UserAccounts.AddRange(new UserAccount { UserName = username, Password = password, Balance = balance, Salary = salary, Role = role });
                Database.MyDatabase.Db.SaveChanges();
            }
        }
    }
}