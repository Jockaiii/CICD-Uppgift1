using System;
using System.Linq;

namespace CICD_Uppgift1.Controllers
{
    internal static class ConsoleController
    {
        internal static string UserName = string.Empty; // the inputed username
        internal static bool UserAccount { get; set; } // bool to determine if the signed in account is a admin account or not.

        /// <summary>
        /// Method that validates the username input and stores the username for password check if the answer is yes.
        /// Else outputs failure to user.
        /// </summary>
        /// <returns> a true or false bool for promtLogin to give the user another try or proceed to password validation.</returns>
        internal static bool UserNameInput()
        {
            var input = Console.ReadLine();

            if (Database.MyDatabase.Db.UserAccounts.Where(w => w.UserName == input).ToList().Count > 0)
            {
                UserName = input;
                UserAccount = true;
                return true;
            }
            else if (Database.MyDatabase.Db.AdminAccounts.Where(w => w.UserName == input).ToList().Count > 0)
            {
                UserName = input;
                UserAccount = false;
                return true;
            }

            Views.ConsoleView.UserNameNotFound(input);
            return false;
        }

        /// <summary>
        /// Method that validates the users inputed password.
        /// </summary>
        /// <returns>true or false to either call method for userAccountDetails or give the user another try (maximum 3) to type in the password</returns>
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

        /// <summary>
        /// Method responsible for taking in user input.
        /// </summary>
        /// <returns>the input inputed by the user.</returns>
        internal static string ConsoleInput()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Method responsible for handling correct integer input from user.
        /// </summary>
        /// <returns>An integer if input is valid</returns>
        internal static int IntTryParseConsoleInput()
        {
            if (int.TryParse(Console.ReadLine(), out int result))
                return result;
            else
            {
                Views.ConsoleView.OutputString("Incorrect value, please try again");
                IntTryParseConsoleInput();
            }
            return 0;
        }
    }
}