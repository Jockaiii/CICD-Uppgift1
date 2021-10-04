namespace CICD_Uppgift1
{
    internal static class Program
    {
        /// <summary>
        /// Main() Instance method for the project. Calls necessary methods to ensure the program runs as intended.
        /// </summary>
        private static void Main()
        {
            Helpers.DatabaseBootstrapper.CheckTables();
            Views.ConsoleView.PromtLogin();
        }
    }
}