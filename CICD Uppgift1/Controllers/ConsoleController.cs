using System;
using System.Linq;

namespace CICD_Uppgift1.Controllers
{
    internal static class ConsoleController
    {
        internal static string UserName = string.Empty;
        internal static bool UserAccount { get; set; }
        internal static Database.MyDatabase db = new Database.MyDatabase();

        internal static bool UserNameInput()
        {
            var input = Console.ReadLine();

            if (db.UserAccounts.Where(w => w.UserName.Contains(input)).ToList().Count > 0)
            {
                UserName = input;
                UserAccount = true;
                return true;
            }
            else if (db.AdminAccounts.Where(w => w.UserName.Contains(input)).ToList().Count > 0)
            {
                UserName = input;
                UserAccount = false;
                return true;
            }

            Views.ConsoleView.UserNameNotFound(input);
            return false;
        }

        internal static bool PasswordInput()
        {
            var input = Console.ReadLine();
            string tempPassword;

            if (UserAccount)
            {
                var accountQuery = db.UserAccounts.Where(w => w.UserName.Contains(UserName)).ToList();
                tempPassword = accountQuery[0].Password;
            }
            else
            {
                var accountQuery = db.AdminAccounts.Where(w => w.UserName.Contains(UserName)).ToList();
                tempPassword = accountQuery[0].Password;
            }

            if (input == tempPassword)
                return true;
            else
            {
                Views.ConsoleView.IncorrectPassword();
                return false;
            }
        }
    }
}