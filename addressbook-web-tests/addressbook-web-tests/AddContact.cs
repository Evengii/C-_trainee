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
    public class AddContact : TestBase
    { 
        [Test]
        public void TheAddContactTest()
        {
            OpenPage();
            loginLogoutHelper.Authorization(new AccountData("admin", "secret"));
            navigationHelper.OpenAddNewContactPage();
            fillingFormHelper.FillInfoForms();
            SubmitCreating();
            navigationHelper.ReturnToHomepage();
            loginLogoutHelper.Logout();
        }
     
        private void SubmitCreating()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
        }
    }
}
