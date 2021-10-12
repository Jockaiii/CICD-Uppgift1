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
    }
}