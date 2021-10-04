using System;
using System.Linq;

namespace CICD_Uppgift1.Controllers
{
    internal static class ConsoleController
    {
        internal static string UserName = string.Empty;
        internal static bool UserAccount { get; set; }

        internal static bool UserNameInput()
        {
            var input = Console.ReadLine();

            if (Database.MyDatabase.Db.UserAccounts.Where(w => w.UserName.Contains(input)).ToList().Count > 0)
            {
                UserName = input;
                UserAccount = true;
                return true;
            }
            else if (Database.MyDatabase.Db.AdminAccounts.Where(w => w.UserName.Contains(input)).ToList().Count > 0)
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
                var accountQuery = Database.MyDatabase.Db.UserAccounts.Where(w => w.UserName.Contains(UserName)).ToList();
                tempPassword = accountQuery[0].Password;
            }
            else
            {
                var accountQuery = Database.MyDatabase.Db.AdminAccounts.Where(w => w.UserName.Contains(UserName)).ToList();
                tempPassword = accountQuery[0].Password;
            }

            if (input == tempPassword)
                return true;
            else
            {
                Views.ConsoleView.OutputString("You have inputed an incorrect password");
                return false;
            }
        }
    }
}