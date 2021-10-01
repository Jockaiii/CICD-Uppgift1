using System;
using System.Linq;

namespace CICD_Uppgift1.Controllers
{
    internal static class ConsoleController
    {
        internal static string UserName = string.Empty;

        internal static Database.MyDatabase db = new Database.MyDatabase();

        internal static bool UserNameInput()
        {
            var input = Console.ReadLine();
            var accountQuery = db.UserAccounts.Where(w => w.UserName.Contains(input)).ToList();

            if (accountQuery.Count > 0)
            {
                UserName = input;
                return true;
            }

            Views.ConsoleView.UserNameNotFound(input);
            return false;
        }

        internal static bool PasswordInput()
        {
            var input = Console.ReadLine();
            var accountQuery = db.UserAccounts.Where(w => w.UserName.Contains(UserName)).ToList();

            if (input == accountQuery[0].Password)
                return true;
            else
            {
                Views.ConsoleView.IncorrectPassword();
                return false;
            }
        }
    }
}