using NUnit.Framework;
using CICD_Uppgift1.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CICD_Uppgift1.Controllers.Tests
{
    [TestFixture()]
    public class ConsoleControllerTests
    {
        [TestCase("joakimandersson")]
        [TestCase("admin1")]
        [TestCase("bob1")]
        public void UserNameInputTest(string userName)
        {
            if(userName == "joakimandersson" || userName == "admin1")
            {
                Assert.IsTrue(ConsoleController.UserNameInput(userName));
            }
            else
            {
                Assert.IsFalse(ConsoleController.UserNameInput(userName));
            }
        }

        [TestCase("joakimandersson")]
        [TestCase("admin1234")]
        [TestCase("bob1")]
        public void PasswordInputTest(string password)
        {

            if (password == "joakimandersson")
            {
                ConsoleController.UserNameInput("joakimandersson");
                Assert.IsTrue(ConsoleController.PasswordInput(password));
            }
            else if(password == "admin1234")
            {
                ConsoleController.UserNameInput("admin1");
                Assert.IsTrue(ConsoleController.PasswordInput(password));
            }
            else
            {
                ConsoleController.UserNameInput("bob1");
                Assert.IsFalse(ConsoleController.PasswordInput(password));
            }
        }
    }
}