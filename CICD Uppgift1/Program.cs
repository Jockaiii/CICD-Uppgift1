using System;

namespace CICD_Uppgift1
{
    class Program
    {
        static void Main()
        {
            Helpers.DatabaseBootstrapper.CheckTables();
            var userAccount = new Models.UserAccount();
            userAccount.GetAccountDetails("joakimandersson");
            Views.ConsoleView.PromtLogin();
        }
    }
}