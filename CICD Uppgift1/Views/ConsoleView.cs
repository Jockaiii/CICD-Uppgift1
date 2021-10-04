using System;

namespace CICD_Uppgift1.Views
{
    internal static class ConsoleView
    {
        internal static void PromtLogin()
        {
            do
            {
                Console.Write("UserName: ");
            } while (!Controllers.ConsoleController.UserNameInput());

            for (int i = 0; i < 3; i++)
            {
                Console.Write("Password: ");
                if (Controllers.ConsoleController.PasswordInput())
                {
                    if (Controllers.ConsoleController.UserAccount)
                    {
                        var signedInAccount = new Models.UserAccount();
                        signedInAccount.GetAccountDetails(Controllers.ConsoleController.UserName);
                        SignedInUserMenu(signedInAccount);
                    }
                    else
                    {
                        var signedInAccount = new Models.AdminAccount();
                        signedInAccount.GetAccountDetails(Controllers.ConsoleController.UserName);
                        SignedInAdminMenu(signedInAccount);
                    }
                    break;
                }
            }
            ThreeFailedAttemps();
        }

        internal static void UserNameNotFound(string username)
        {
            Console.Clear();
            Console.WriteLine($"No account with username: {username} could be found. Please try again");
        }

        internal static void IncorrectPassword()
        {
            Console.WriteLine("You have inputed an incorrect password");
        }

        internal static void ThreeFailedAttemps()
        {
            Console.Clear();
            Console.WriteLine("You have entered the incorrect password 3 times");
        }

        internal static void SignedInUserMenu(Models.UserAccount signedInAccount)
        {
            bool exit = false;
            while(!exit)
            {
                Console.Clear();
                Console.WriteLine("[1] check balance\n[2] check salary\n[3] check role\n[4] request salary change\n[5] request role change\n[6] remove account\n[0] Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine($"Your current balance is: {signedInAccount.Balance}\nContinue?");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine($"Your current salary is: {signedInAccount.Salary}\nContinue?");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine($"Your role is: {signedInAccount.Role}\nContinue?");
                        Console.ReadKey();
                        break;
                    case "4":
                        Models.UserAccount.RequestSalaryChange(signedInAccount.UserName);
                        break;
                    case "5":
                        Models.UserAccount.RequestRoleChange(signedInAccount.UserName);
                        break;
                    case "6":
                        Models.UserAccount.RemoveAccount(signedInAccount.UserName);
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Incorrect input, please try again");
                        break;
                }
            }
        }
        internal static void SignedInAdminMenu(Models.AdminAccount signedInAccount)
        {
            bool exit = false;
            while(!exit)
            {
                Console.Clear();
                Console.WriteLine("[1] check balance\n[2] check salary\n[3] check role\n[4] check accounts\n[5] check account requests\n[6] advance salary system\n[7] create local account\n[0] Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine($"Your current balance is: {signedInAccount.Balance}\nContinue?");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine($"Your current salary is: {signedInAccount.Salary}\nContinue?");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine($"Your role is: {signedInAccount.Role}\nContinue?");
                        Console.ReadKey();
                        break;
                    case "4":
                        Models.AdminAccount.CheckAccounts();
                        break;
                    case "5":
                        Models.AdminAccount.CheckAccountRequests();
                        break;
                    case "6":
                        Models.AdminAccount.AdvanceSalaraySystem();
                        break;
                    case "7":
                        Models.AdminAccount.CreateLocalAccount();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Incorrect input, please try again");
                        break;
                }
            }
        }
    }
}