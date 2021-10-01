using System.Linq;

namespace CICD_Uppgift1.Helpers
{
    internal static class DatabaseBootstrapper
    {
        /// <summary>
        /// Metod som kollar ifall alla tabeller är tomma när programmet startar. Och tillkallar metoderna som fyller på data till tabellerna ifall svaret är ja.
        /// </summary>
        internal static void CheckTables()
        {
            using var db = new Database.MyDatabase();

            if (!db.AdminAccounts.Any() && !db.UserAccounts.Any())
                Seeder.TablesInsert();
        }
    }
}
