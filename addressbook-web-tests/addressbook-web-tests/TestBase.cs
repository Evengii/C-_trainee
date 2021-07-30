using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class TestBase
    {
        protected IWebDriver driver;
        private StringBuilder verificationErrors;
        protected string baseURL;

        protected LoginLogoutHelper loginLogoutHelper;
        protected NavigationHelper navigationHelper;
        protected FillingFormHelper fillingFormHelper;
        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/addressbook/";
            verificationErrors = new StringBuilder();

            loginLogoutHelper = new LoginLogoutHelper(driver); // добавили помощника для разгрузки TestBase
            navigationHelper = new NavigationHelper(driver);
            fillingFormHelper = new FillingFormHelper(driver);
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        protected void OpenPage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

    }
}
