using System;

namespace CICD_Uppgift1.Views
{
    class ConsoleView
    {
        public static void PromtLogin()
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
                    var signedInAccount = new Models.UserAccount();
                    signedInAccount.GetAccountDetails(Controllers.ConsoleController.UserName);
                    SignedInMenu();
                    break;
                }
                ThreeFailedAttemps();
            }
            
        }

        public static void UserNameNotFound(string username)
        {
            Console.Clear();
            Console.WriteLine($"No account with username: {username} could be found. Please try again");
        }

        public static void IncorrectPassword()
        {
            Console.WriteLine("You have inputed an incorrect password");
        }

        public static void ThreeFailedAttemps()
        {
            Console.Clear();
            Console.WriteLine("You have entered the incorrect password 3 times");
        }

        public static void SignedInMenu()
        {
            bool exit = false;
            while(!exit)
            {
                Console.Clear();
                Console.WriteLine("[1] check balance\n[2] check salary\n[3] check role\n[4] request salary change\n[5] request role change\n[6] remove account");
                switch (Console.ReadLine())
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
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