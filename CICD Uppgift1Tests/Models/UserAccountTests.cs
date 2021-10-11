using NUnit.Framework;
using CICD_Uppgift1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CICD_Uppgift1.Models.Tests
{
    [TestFixture()]
    public class UserAccountTests
    {
        [TestCase("joakimandersson")]
        [TestCase("bobby1")]
        public void GetAccountDetailsTest(string userName)
        {
            var userAccount = new UserAccount();
            if(userName == "joakimandersson")
            {
                Assert.IsTrue(userAccount.GetAccountDetails(userName));
            }
            else
            {
                Assert.IsFalse(userAccount.GetAccountDetails(userName));
            }
            
        }

        [Test()]
        public void RequestSalaryChangeTest()
        {
            var userAccount = new UserAccount();
        }

        [Test()]
        public void RequestRoleChangeTest()
        {
            Assert.Fail();
        }

        [TestCase("joakimandersson","joakimandersson")]
        [TestCase("bob1","bobby123")]
        public void RemoveAccountTest(string userName, string password)
        {
            
        }
    }
}