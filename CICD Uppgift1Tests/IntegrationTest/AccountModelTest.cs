using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using CICD_Uppgift1.Models;
using CICD_Uppgift1.Database;
using System.Linq;

namespace CICD_Uppgift1Tests.IntegrationTest
{
    [TestFixture]
    public class AccountModelTest : DbContext
    {
        [Test()]
        public void TestAccountModel()
        {
            MyDatabase db = new MyDatabase();   
            AdminAccount admin = new AdminAccount();
            UserAccount account = new UserAccount {UserName = "bob", Password = "bob1", Balance = 100, Salary = 100, Role = "Bob" };
            admin.CreateLocalAccount(account.UserName, account.Password, account.Balance, account.Salary, account.Role);

            Assert.NotNull(db.UserAccounts);
            Assert.IsTrue(db.UserAccounts.Where(x=>x.UserName == account.UserName).ToList().Count>0);
            Assert.IsTrue(db.UserAccounts.Where(x=>x.Salary == account.Salary).ToList().Count>0);
        }
    }
}
