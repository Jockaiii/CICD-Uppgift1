using System;

namespace CICD_Uppgift1.View
{
    class ConsoleView
    {
        public static void PromtLogin()
        {
            Console.Write("UserName: ");
            Controllers.ConsoleController.UserNameInput();
            Console.Write("Password: ");
            Controllers.ConsoleController.PasswordInput();
        }
    }
}
