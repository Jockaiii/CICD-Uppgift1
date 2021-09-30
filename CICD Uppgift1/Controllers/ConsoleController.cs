using System;

namespace CICD_Uppgift1.Controllers
{
    class ConsoleController
    {
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static void UserNameInput()
        {
            var input = Console.ReadLine();
            UserName = input;
        }
        public static void PasswordInput()
        {
            var input = Console.ReadLine();
            Password = input;
        }
    }
}
