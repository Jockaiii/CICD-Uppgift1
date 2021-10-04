using System;
using System.Collections.Generic;
using System.Linq;

namespace CICD_Uppgift1.Views
{
    internal static class ConsoleView
    {
        /// <summary>
        /// Method that promts the login view for the user. aswell as calling the necessary methods for checking if the input is valid or not. and the corresponding output.
        /// </summary>
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
                        var signedInAccount = new Models.UserAccount(); // Creates an instance of UserAccount to store and access UserAccount methods and properties.
                        signedInAccount.GetAccountDetails(Controllers.ConsoleController.UserName);
                        SignedInUserMenu(signedInAccount);
                    }
                    else
                    {
                        var signedInAccount = new Models.AdminAccount(); // Creates an instance of AdminAccount to store and access AdminAccount methods and properties.
                        signedInAccount.GetAccountDetails(Controllers.ConsoleController.UserName);
                        SignedInAdminMenu(signedInAccount);
                    }
                    if (i == 2)
                        OutputStringWithConsoleClear("You have entered the incorrect password 3 times");
                    break;
                }
            }
        }

        /// <summary>
        /// Method responsible for display the signed in menu for UserAccounts. aswell as calling the necessary methods or exiting the application or outputing data dependant on the users choice.
        /// </summary>
        /// <param name="signedInAccount">a locally stored UserAccount for output and project purposes.</param>
        internal static void SignedInUserMenu(Models.UserAccount signedInAccount)
        {
            bool exit = false;
            while(!exit)
            {
                Console.Clear();
                Console.WriteLine("[1] check balance\n[2] check salary\n[3] check role\n[4] request salary change\n[5] request role change\n[6] remove account\n[7] sign out\n[0] Exit");
                switch (Controllers.ConsoleController.ConsoleInput())
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
                        var salary = Controllers.ConsoleController.IntTryParseConsoleInput();
                        signedInAccount.RequestSalaryChange(signedInAccount.UserName, salary, signedInAccount.Salary);
                        break;
                    case "5":
                        Console.WriteLine("What role you want to change to?");
                        var role = Controllers.ConsoleController.ConsoleInput();
                        signedInAccount.RequestRoleChange(signedInAccount.UserName, role, signedInAccount.Role);
                        break;
                    case "6":
                        OutputString("Please enter your username: ");
                        string username = Controllers.ConsoleController.ConsoleInput();
                        OutputString("Please enter your password: ");
                        string password = Controllers.ConsoleController.ConsoleInput();
                        signedInAccount.RemoveAccount(username, password);
                        OutputString("Continue?");
                        Console.ReadKey();
                        break;
                    case "7":
                        Console.Clear();
                        PromtLogin();
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

        /// <summary>
        /// Method responsible for display the signed in menu for AdminAccounts. aswell as calling the necessary methods or exiting the application or outputing data dependant on the users choice.
        /// </summary>
        /// <param name="signedInAccount">a locally stored UserAccount for output and project purposes.</param>
        internal static void SignedInAdminMenu(Models.AdminAccount signedInAccount)
        {
            bool exit = false;
            while(!exit)
            {
                Console.Clear();
                Console.WriteLine("[1] check balance\n[2] check salary\n[3] check role\n[4] check accounts\n[5] check account requests\n[6] advance salary system\n[7] create local account\n[8] delete user account\n[9] sign out\n[0] Exit");
                switch (Controllers.ConsoleController.ConsoleInput())
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
                        signedInAccount.CheckAccounts();
                        break;
                    case "5":
                        signedInAccount.CheckAccountRequests();
                        break;
                    case "6":
                        signedInAccount.AdvanceSalarySystem();
                        break;
                    case "7":
                        Console.WriteLine("Create a new Username:");
                        var username = Controllers.ConsoleController.ConsoleInput();
                        Console.WriteLine("Create a new Password:");
                        var password = Controllers.ConsoleController.ConsoleInput();
                        Console.WriteLine("Give the account a bank account balance:");
                        var balance = Controllers.ConsoleController.IntTryParseConsoleInput();
                        Console.WriteLine("Give the account a salary:");
                        var salary = Controllers.ConsoleController.IntTryParseConsoleInput();
                        Console.WriteLine("Give the account a role:");
                        var role = Controllers.ConsoleController.ConsoleInput();
                        signedInAccount.CreateLocalAccount(username, password, balance, salary, role);
                        break;
                    case "8":
                        OutputString("Please enter your username: ");
                        string username2 = Controllers.ConsoleController.ConsoleInput();
                        OutputString("Please enter your password: ");
                        string password2 = Controllers.ConsoleController.ConsoleInput();
                        signedInAccount.RemoveUserAccount(username2, password2);
                        OutputString("Continue?");
                        Console.ReadKey();
                        break;
                    case "9":
                        Console.Clear();
                        PromtLogin();
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

        /// <summary>
        /// Method responsible for outputing username not found to console.
        /// </summary>
        /// <param name="username">the inputed username from user</param>
        internal static void UserNameNotFound(string username)
        {
            Console.Clear();
            Console.WriteLine($"No account with username: {username} could be found. Please try again");
        }

        /// <summary>
        /// Method responsible for outputting stored UserAccounts in the database.
        /// </summary>
        /// <param name="userAccounts">The stored UserAccounts in the database</param>
        internal static void OutputCheckAccounts(List<Models.UserAccount> userAccounts)
        {
            foreach (var account in userAccounts)
                Console.WriteLine($"UserName: {account.UserName} Password: {account.Password}");
        }

        /// <summary>
        /// Method responsible for outputting stored pollrequests in the database. aswell as updating necessary database tables.
        /// </summary>
        /// <param name="requestPolls">the stored requestpolls in the database</param>
        internal static void OutputCheckPollRequests(List<Models.RequestPoll> requestPolls)
        {
            for (int i = 0; i < requestPolls.Count; i++)
            {
                var accountQuery = Database.MyDatabase.Db.UserAccounts.Where(x => x.UserName == requestPolls[i].Username).FirstOrDefault();
                var requestPollQuery = Database.MyDatabase.Db.RequestPolls.Where(x => x.Username == requestPolls[i].Username).FirstOrDefault();

                if (requestPolls[i].Role != "")
                {
                    Console.WriteLine($"[{i}] {requestPolls[i].Username} has requested to change their role from {requestPolls[i].OldRole} to {requestPolls[i].Role}\nDo you want to accept this request?\n [1] Yes\n [2] No");
                    switch (Controllers.ConsoleController.ConsoleInput())
                    {
                        case "1":
                            if(accountQuery != null)
                            {
                                accountQuery.Role = requestPolls[i].Username;
                                Database.MyDatabase.Db.UserAccounts.Update(accountQuery);
                            }
                            Database.MyDatabase.Db.RequestPolls.Remove(requestPollQuery);
                            Database.MyDatabase.Db.SaveChanges();
                            break;
                        case "2":
                            Database.MyDatabase.Db.RequestPolls.Remove(requestPollQuery);
                            Database.MyDatabase.Db.SaveChanges();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Incorrect input Please try again");
                            OutputCheckPollRequests(requestPolls);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"[{i}] {requestPolls[i].Username} has requested to change their Salary from {requestPolls[i].OldSalary} to {requestPolls[i].Salary}");
                    Console.WriteLine("Do you want to accept this request?\n [1] Yes\n [2] No");
                    switch (Controllers.ConsoleController.ConsoleInput())
                    {
                        case "1":
                            if (accountQuery != null)
                            {
                                accountQuery.Salary = requestPolls[i].Salary;
                                Database.MyDatabase.Db.UserAccounts.Update(accountQuery);
                            }
                            Database.MyDatabase.Db.RequestPolls.Remove(requestPollQuery);
                            Database.MyDatabase.Db.SaveChanges();
                            break;
                        case "2":
                            Database.MyDatabase.Db.RequestPolls.Remove(requestPollQuery);
                            Database.MyDatabase.Db.SaveChanges();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Incorrect input Please try again");
                            OutputCheckPollRequests(requestPolls);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Method responsible for outputting simple strings to the console.
        /// </summary>
        /// <param name="output">the string to be outputted</param>
        internal static void OutputString(string output)
        {
            Console.WriteLine(output);
        }

        /// <summary>
        /// Method responsible for outputting simple strings to the console but clearing the console from text beforehand.
        /// </summary>
        /// <param name="output">the string to be outputted</param>
        internal static void OutputStringWithConsoleClear(string output)
        {
            Console.Clear();
            Console.WriteLine(output);
        }
    }
}