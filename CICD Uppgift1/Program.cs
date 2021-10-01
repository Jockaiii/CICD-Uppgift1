namespace CICD_Uppgift1
{
    internal static class Program
    {
        private static void Main()
        {
            Helpers.DatabaseBootstrapper.CheckTables();
            Views.ConsoleView.PromtLogin();
        }
    }
}