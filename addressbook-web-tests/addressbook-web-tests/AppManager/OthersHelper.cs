using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests {
    public class OthersHelper : HelperBase
    {
        private string baseURL;
        public OthersHelper(IWebDriver driver, string baseURL) : base(driver) // используем базовый конструктор класса HelperBase
        {
            this.baseURL = baseURL;
        }
        public void SubmitCreating()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
        }

        public void InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
        }
        public void UpdateGroup()
        {
            driver.FindElement(By.Name("update")).Click();
        }
        public void OpenPage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
        public void RemoveGroup()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[5]")).Click();
        }

        public void SelectingGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
        }
        public void SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }
        public void InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
        }
    }
}
