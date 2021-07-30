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
    public class NavigationHelper : HelperBase
    {
        private IWebDriver driver;
        public NavigationHelper(IWebDriver driver) : base(driver) // используем базовый конструктор класса HelperBase
        {
        }
        public void OpenGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void OpenAddNewContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
        public void ReturnToHomepage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }
        public void ReturnGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

    }
}
