using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    [TestFixture]
    public class CreateGroup : TestBase
    {
        [Test]
        public void TheCreateGroupTest()
        {
            OpenPage();
            loginLogoutHelper.Authorization(new AccountData("admin", "secret"));
            navigationHelper.OpenGroupPage();
            InitGroupCreation();
            fillingFormHelper.FillGroupForm(new GroupData("Evgenii","My group","Foote"));
            SubmitGroupCreation();
            navigationHelper.ReturnGroupPage();
            loginLogoutHelper.Logout();
        }
        private void SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }
        private void InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
        }
    }
}
