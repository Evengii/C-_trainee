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
    public class DeleteGroup : TestBase
    {
        [Test]
        public void TheDeleteGroupTest()
        {
            OpenPage();
            loginLogoutHelper.Authorization(new AccountData("admin", "secret"));
            navigationHelper.OpenGroupPage();
            SelectingGroup(1);
            RemoveGroup();
            navigationHelper.ReturnGroupPage();
            loginLogoutHelper.Logout();
        }

        private void RemoveGroup()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[5]")).Click();
        }

        private void SelectingGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
        }
    }
}
