using System;
using System.Collections.Generic;

namespace CICD_Uppgift1.Views
{
    internal static class ConsoleView
    {
        internal static List<Models.RequestPoll> RequestPolls { get; set; } = new List<Models.RequestPoll>();
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
            OutputStringWithConsoleClear("You have entered the incorrect password 3 times");
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
                        Console.WriteLine("What salary do you want?");
                        var salary = Convert.ToInt32(Console.ReadLine());
                        Models.UserAccount.RequestSalaryChange(signedInAccount.UserName, salary);
                        break;
                    case "5":
                        Console.WriteLine("What role you want to change to?");
                        var role = Console.ReadLine();
                        Models.UserAccount.RequestRoleChange(signedInAccount.UserName, role);
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
            using var db = new Database.MyDatabase();
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
                        Models.AdminAccount.AdvanceSalarySystem();
                        break;
                    case "7":
                        Console.WriteLine("Create a new Username:");
                        var username = Console.ReadLine();
                        Console.WriteLine("Create a new Password:");
                        var password = Console.ReadLine();
                        Console.WriteLine("Give the account a bank account balance:");
                        var balance = Console.ReadLine();
                        Console.WriteLine("Give the account a salary:");
                        var salary = Console.ReadLine();
                        Console.WriteLine("Give the account a role:");
                        var role = Console.ReadLine();
                        Models.AdminAccount.CreateLocalAccount(username, password, Convert.ToInt32(balance), Convert.ToInt32(salary), role);
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

        internal static void UserNameNotFound(string username)
        {
            Console.Clear();
            Console.WriteLine($"No account with username: {username} could be found. Please try again");
        }

        internal static void OutputCheckAccounts(List<Models.UserAccount> userAccounts)
        {
            foreach (var account in userAccounts)
                Console.WriteLine($"UserName: {account.UserName} Password: {account.Password}");
        }

        internal static void OutputCheckPollRequests()
        {
            foreach (var poll in RequestPolls)
                Console.WriteLine(poll);
        }

        internal static void OutputString(string output)
        {
            Console.WriteLine(output);
        }
        internal static void OutputStringWithConsoleClear(string output)
        {
            Console.Clear();
            Console.WriteLine(output);
        }
    }
}